import { Component, Input, OnInit } from '@angular/core';
import { PublicHolidayItem } from 'src/app/modules/sprints/models/public-holiday-item.model';
import { SprintItem } from 'src/app/modules/sprints/models/sprint-item.model';
import { TeamMemberApiService } from 'src/app/modules/sprints/services/team-member-api.service';

@Component({
  selector: 'app-public-holiday-list',
  templateUrl: './public-holiday-list.component.html',
  styleUrls: ['./public-holiday-list.component.scss'],
})
export class PublicHolidayListComponent implements OnInit {
  @Input() public sprint: SprintItem;

  public isLoading = false;
  public publicHolidayItems: PublicHolidayItem[] = [];

  constructor(private teamMemberApiService: TeamMemberApiService) {}

  ngOnInit(): void {
    if (this.sprint) this.loadPublicHolidays();
  }

  public loadPublicHolidays() {
    this.isLoading = true;
    this.teamMemberApiService.getPublicHolidays(this.sprint).subscribe({
      next: (response: PublicHolidayItem[]) => {
        this.publicHolidayItems = response;
      },
      error: (error) => {
        console.log('Error Getting  Public holiday ', error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
