import { AfterContentInit, AfterViewInit, Component, OnChanges, OnInit } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { SprintService } from 'src/app/services/sprint.service';
import { BacklogComponent } from '../backlog/backlog.component';
import { BacklogService } from 'src/app/services/backlog.service';
import { forkJoin } from 'rxjs';

@Component({
    selector: 'app-sprint',
    templateUrl: './sprint.component.html',
    styleUrls: ['./sprint.component.css']
})
export class SprintComponent implements OnInit {
    public sprints: any = [];
    public selectedSprint: any;

    constructor(public sprintService: SprintService, private backlogService: BacklogService, private modalService: NgbModal) { }
    ngOnInit(): void {
        this.sprintService.getAll().subscribe(sprints => {
            console.log("sprints", sprints);
            const observables = sprints.map(sprint => this.backlogService.getBySprintId(sprint.id));

            forkJoin(observables).subscribe(backlogsArray => {
                this.sprints = this.calculateTotalStoryPoints(sprints, backlogsArray);
            });
        });
    }

    private calculateTotalStoryPoints(sprints: any[], backlogsArray: any[][]): any[] {
        return sprints.map((sprint, index) => {
            const backlogs = backlogsArray[index];
            console.log("backlogs", backlogs);
            sprint.backlogs = backlogs;
            sprint.totalStoryPoints = sprint.backlogs.reduce((sum: any, backlog: { fields: { customfield_10016: any; } }) => {
                const backlogPoints = parseFloat(backlog.fields.customfield_10016);
    
                if (!isNaN(backlogPoints)) {
                    return sum + backlogPoints;
                } else return sum;
            }, 0);
    
            return sprint;
        });
    }

    openModal(sprint: any): void {
        const modalOptions: NgbModalOptions = {
            size: 'lg',
        };
        this.selectedSprint = sprint;
        const modalRef = this.modalService.open(BacklogComponent, modalOptions);
        modalRef.componentInstance.selectedSprint = this.selectedSprint;
    }
}
