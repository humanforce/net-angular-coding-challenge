import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { BacklogService } from 'src/app/services/backlog.service';
import { SprintService } from 'src/app/services/sprint.service';

@Component({
    selector: 'app-team-velocity',
    templateUrl: './team-velocity.component.html',
    styleUrls: ['./team-velocity.component.css']
})
export class TeamVelocityComponent implements OnInit {
    public sprints: any = [];
    public velocitySprints: any = [];
    public averageVelocity: number = 0;
    public totalCompletedStory: number = 0;

    public selectedSprintFrom: any = {
        id: 1,
        name: 'SCRUM Sprint 1'
    };
    public selectedSprintTo: any = {
        id: 3,
        name: 'SCRUM Sprint 3'
    }

    constructor(private sprintService: SprintService, private backlogService: BacklogService) { }

    ngOnInit(): void {
        this.sprintService.getAll().subscribe(sprints => {
            console.log("sprints", sprints);
            const observables = sprints.map(sprint => this.backlogService.getBySprintId(sprint.id));

            forkJoin(observables).subscribe(backlogsArray => {
                this.sprints = this.calculateTotalCompletedStoryPoints(sprints, backlogsArray);
                this.velocitySprints = this.sprints.filter((c: { id: number; }) => c.id >= this.selectedSprintFrom.id && c.id <= this.selectedSprintTo.id);
                this.computeVelocity();
            });
        });
    }

    private calculateTotalCompletedStoryPoints(sprints: any[], backlogsArray: any[][]): any[] {
        return sprints.map((sprint, index) => {
            const backlogs = backlogsArray[index];
            console.log("backlogs", backlogs);
            sprint.backlogs = backlogs;
            sprint.totalCompletedStoryPoints = sprint.backlogs
                .filter((backlog: { fields: { status: { statusCategory: { id: number; }; }; }; }) => backlog.fields.status.statusCategory.id === 3)
                .reduce((sum: any, backlog: { fields: { customfield_10016: any; } }) => {
                    const backlogPoints = parseFloat(backlog.fields.customfield_10016);
    
                    if (!isNaN(backlogPoints)) {
                        return sum + backlogPoints;
                    } else return sum;
                }, 0);
    
            return sprint;
        });
    }

    dropdownSelectedSprintFrom(selectedSprint: any) {
        this.selectedSprintFrom = selectedSprint;
        this.computeVelocity();
    }

    dropdownSelectedSprintTo(selectedSprint: any) {
        this.selectedSprintTo = selectedSprint;
        this.computeVelocity();
    }

    computeVelocity() {
        if (this.selectedSprintTo.id >= this.selectedSprintFrom.id) {
            this.velocitySprints = this.sprints.filter((c: { id: number; }) => c.id >= this.selectedSprintFrom.id && c.id <= this.selectedSprintTo.id);

            if (this.velocitySprints) {
                this.totalCompletedStory = this.velocitySprints.reduce((sum: any, sprint: { totalCompletedStoryPoints: any; }) => {
                    const completedPoints = parseFloat(sprint.totalCompletedStoryPoints);
                    if (!isNaN(completedPoints)) {
                        return sum + completedPoints;
                    } else return sum;
                }, 0);
                this.averageVelocity = this.totalCompletedStory / this.velocitySprints.length;
            }
        }
    }
}
