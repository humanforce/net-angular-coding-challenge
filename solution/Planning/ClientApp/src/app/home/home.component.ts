import { Component, inject } from '@angular/core';
import { SprintService } from './sprint.service';
import { Sprint } from '../app';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private sprintService = inject(SprintService);
  public sprints: Sprint[] = [];

  constructor() {
    (async () => {
      this.sprints = await this.sprintService.getCachedSprints();
    })();
  }
}
