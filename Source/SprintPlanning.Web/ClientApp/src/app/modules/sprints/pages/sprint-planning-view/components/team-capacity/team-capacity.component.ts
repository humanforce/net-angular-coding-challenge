import { Component, Input, OnInit } from '@angular/core';
import { SprintItem } from 'src/app/modules/sprints/models/sprint-item.model';
import { TeamCapacity } from 'src/app/modules/sprints/models/team-capacity.model';
import { TeamMemberApiService } from 'src/app/modules/sprints/services/team-member-api.service';

@Component({
  selector: 'app-team-capacity',
  templateUrl: './team-capacity.component.html',
  styleUrls: ['./team-capacity.component.scss']
})
export class TeamCapacityComponent  implements OnInit {
  @Input() public sprint: SprintItem;

  public isLoading = false;
  public teamMembers: TeamCapacity[]=[];

  constructor(private teamMemberApiService: TeamMemberApiService) {}

  ngOnInit(): void {
    if (this.sprint) this.loadTeamCapacity();
  }

  public loadTeamCapacity() {
    this.isLoading = true;
    this.teamMemberApiService.getTeamCapacity(this.sprint).subscribe({
      next: (response: TeamCapacity[]) => {
        this.teamMembers = response;
      },
      error: (error) => {
        console.log('Error Getting  Team Members ', error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}

