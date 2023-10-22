import { Component, inject } from '@angular/core';
import { Sprint } from '../app';
import { ActivatedRoute } from '@angular/router';
import { SprintService } from '../home/sprint.service';

@Component({
  selector: 'sprint-details',
  templateUrl: './details.component.html'
})
export class SprintDetailsComponent {
  private route: ActivatedRoute = inject(ActivatedRoute);
  private sprintService = inject(SprintService);
  public sprint: Sprint = {} as Sprint;

  constructor() {
    const id = Number(this.route.snapshot.params['id']);
    (async () => {
      this.sprint = await this.sprintService.getSprintById(id);
    })();
  }
}
