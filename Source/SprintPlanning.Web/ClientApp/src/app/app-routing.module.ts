import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SprintListPageComponent } from './modules/sprints/pages/sprint-list-page/sprint-list-page.component';
import { SprintPlanningViewComponent } from './modules/sprints/pages/sprint-planning-view/sprint-planning-view.component';

const routes: Routes = [{ path: '', component: SprintListPageComponent },
{ path: 'show/:sprintId', component: SprintPlanningViewComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
