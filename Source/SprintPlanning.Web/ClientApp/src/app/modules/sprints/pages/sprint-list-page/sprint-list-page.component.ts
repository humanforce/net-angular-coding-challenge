import { Component, OnInit } from '@angular/core';
import { SprintApiService } from '../../services/sprint-api.service';
import { SprintItem } from '../../models/sprint-item.model';
@Component({
  selector: 'app-sprint-list-page',
  templateUrl: './sprint-list-page.component.html',
  styleUrls: ['./sprint-list-page.component.scss'],
})
export class SprintListPageComponent implements OnInit {
  public isLoading = false;
  public sprintItems: SprintItem[] = [];
  constructor(private sprintApiService: SprintApiService) {}

  ngOnInit(): void {
    this.loadSprintList();
  }
  public loadSprintList() {
    this.isLoading = true;
    this.sprintApiService.getSprints().subscribe({
      next: (response: SprintItem[]) => {
        this.sprintItems = response;
            },
      error: (error) => {
        console.log('Error Getting Sprint Items: ', error);
        this.sprintItems = [];
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
 }
