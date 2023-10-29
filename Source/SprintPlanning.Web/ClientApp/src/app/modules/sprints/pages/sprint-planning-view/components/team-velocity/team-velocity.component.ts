import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { SprintItem } from 'src/app/modules/sprints/models/sprint-item.model';
import { TeamVelocity } from 'src/app/modules/sprints/models/team-velocity.model';
import { TeamMemberApiService } from 'src/app/modules/sprints/services/team-member-api.service';

@Component({
  selector: 'app-team-velocity',
  templateUrl: './team-velocity.component.html',
  styleUrls: ['./team-velocity.component.scss'],
})
export class TeamVelocityComponent implements OnInit {
  @Input() public sprint: SprintItem;

  public isLoading = false;
  public teamVelocity: TeamVelocity;

  constructor(private teamMemberApiService: TeamMemberApiService) {}

  ngOnInit(): void {
    if (this.sprint) this.loadTeamCapacity();
  }

  public loadTeamCapacity() {
    this.isLoading = true;
    this.teamMemberApiService.getTeamVelocity(this.sprint).subscribe({
      next: (response: TeamVelocity) => {
        this.teamVelocity = response;
      },
      error: (error) => {
        console.log('Error Getting  Team Velocity ', error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
