import { Component, Input, OnInit } from '@angular/core';
import { TicketItem } from 'src/app/modules/sprints/models/ticket-item.model';
import { SprintApiService } from 'src/app/modules/sprints/services/sprint-api.service';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.scss'],
})
export class TicketListComponent implements OnInit {
  @Input() public sprintId: number;

  public isLoading = false;
  public tickets: TicketItem[]=[];

  constructor(private sprintApiService: SprintApiService) {}

  ngOnInit(): void {
    if (this.sprintId) this.loadTickets();
  }

  public loadTickets() {
    this.isLoading = true;
    this.sprintApiService.getSprintTickets(this.sprintId).subscribe({
      next: (response: TicketItem[]) => {
        this.tickets = response;
      },
      error: (error) => {
        console.log('Error Getting  Tickets ', error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
