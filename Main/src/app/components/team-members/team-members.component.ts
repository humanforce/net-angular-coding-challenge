import { Component, OnInit } from '@angular/core';
import { TeamMembersService } from 'src/app/services/team-members.service';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { PublicHolidayComponent } from '../public-holiday/public-holiday.component';
import { SprintService } from 'src/app/services/sprint.service';
import { PublicHolidayService } from 'src/app/services/public-holiday.service';
import { Observable, forkJoin, of } from 'rxjs';

@Component({
    selector: 'app-team-members',
    templateUrl: './team-members.component.html',
    styleUrls: ['./team-members.component.css']
})

export class TeamMembersComponent implements OnInit {
    public teamMembers: any = [];
    public sprints: any = [];
    public totalAbsencesInDays: number = 0;
    public totalAbsencesInHours: number = 0;
    public totalTeamCapacityInDays: number = 0;
    public totalTeamCapacityInHours: number = 0;

    public selectedSprint: any = {
        id: 1,
        name: 'SCRUM Sprint 1',
        "startDate": "2022-12-31T14:00:00.000Z",
        "endDate": "2023-01-14T14:00:00.000Z",
    };
    public selectedTeamMember: any;

    constructor(private teamMembersService: TeamMembersService, private sprintService: SprintService, private publicHolidayService: PublicHolidayService, private modalService: NgbModal) { }

    ngOnInit(): void {
        this.getTeamMembers();

        this.sprintService.getAll().subscribe(sprints => {
            console.log("sprints", sprints);
            this.sprints = sprints
        });
    }

    getTeamMembers() {
        this.teamMembersService.getAll().subscribe(members => {
            console.log("team members", members);
            const observables = members.map(member => this.publicHolidayService.getByCountryName(member.location.country));

            forkJoin(observables).subscribe(publicHolidaysArray => {
                this.teamMembers = this.calculateHolidays(members, publicHolidaysArray);
                this.calculateAbsences();
            });
        });
    }

    calculateHolidays(members: any[], publicHolidaysArray: any) {
        return members.map((member, index) => {
            const publicHolidays = publicHolidaysArray[index];

            member.publicHolidays = publicHolidays;
            member.publicHolidays.items.forEach((publicHoliday: { end: { date: string | number | Date; }; }) => {
                publicHoliday.end.date = new Date(publicHoliday.end?.date);
                publicHoliday.end.date.setDate(publicHoliday.end?.date.getDate() - 1);
            });
            member.publicHolidaysWithinSprint = member.publicHolidays;
            member.publicHolidaysWithinSprint.items = member.publicHolidays.items
                .filter((publicHoliday: { start: { date: any }, end: { date: any }; }) =>
                    new Date(publicHoliday.start.date) >= new Date(this.selectedSprint.startDate) &&
                    new Date(publicHoliday.end.date) <= new Date(this.selectedSprint.endDate));

            return member;
        });
    }

    calculateAbsences() {
        this.totalAbsencesInDays = this.teamMembers.reduce((sum: any, teamMember: { publicHolidaysWithinSprint: { items: any } }) => {
            const absences = parseFloat(teamMember.publicHolidaysWithinSprint.items.length);
            if (!isNaN(absences)) {
                return sum + absences;
            } else return sum;
        }, 0);

        this.totalAbsencesInHours = this.totalAbsencesInDays * 8;
        this.totalTeamCapacityInDays = Math.max(10 - this.totalAbsencesInDays, 0);
        this.totalTeamCapacityInHours = this.totalTeamCapacityInDays * 8;
    }   

    openModal(teamMember: any, isWithinSprint: boolean = false): void {
        const modalOptions: NgbModalOptions = {
            size: 'lg',
        };

        this.selectedTeamMember = teamMember;
        const modalRef = this.modalService.open(PublicHolidayComponent, modalOptions);
        modalRef.componentInstance.countryName = this.selectedTeamMember.location.country;
        this.getHolidays(teamMember, isWithinSprint).subscribe((holidays) => {
            modalRef.componentInstance.publicHolidays = holidays;
        });
    }

    dropdownSelectedSprint(selectedSprint: any) {
        this.selectedSprint = selectedSprint;
        this.getTeamMembers();
    }

    getHolidays(teamMember: any, isWithinSprint: boolean = false): Observable<any> {
        if (isWithinSprint) {
            return of(teamMember.publicHolidaysWithinSprint);
        } else {
            return this.publicHolidayService.getByCountryName(teamMember.location.country ?? "");
        }
    }
}
