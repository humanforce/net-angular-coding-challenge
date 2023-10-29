import { Component, OnInit } from '@angular/core';
import { SprintApiService } from '../../services/sprint-api.service';
import { SprintItem } from '../../models/sprint-item.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sprint-planning-view',
  templateUrl: './sprint-planning-view.component.html',
  styleUrls: ['./sprint-planning-view.component.scss'],
})
export class SprintPlanningViewComponent implements OnInit {
  public isLoading = false;
  public sprintId: number;
  public sprintDetails: SprintItem;
  constructor(
    private route: ActivatedRoute,
    private sprintApiService: SprintApiService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      const sprintId = p.get('sprintId');
      if (sprintId) {
        this.sprintId = parseInt(sprintId);
        this.loadSprintDetails();
      } 
    });
  }

  public loadSprintDetails() {
    this.isLoading = true;
    this.sprintApiService.getSprintDetails(this.sprintId).subscribe({
      next: (response: SprintItem) => {
        this.sprintDetails = response;
      },
      error: (error) => {
        console.log('Error Getting Sprint Deatils ', error);
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
}
