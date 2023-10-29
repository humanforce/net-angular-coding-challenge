import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SprintPlanningViewComponent } from './modules/sprints/pages/sprint-planning-view/sprint-planning-view.component';
import { SprintListPageComponent } from './modules/sprints/pages/sprint-list-page/sprint-list-page.component';
import { HttpClientModule } from '@angular/common/http';
import { TicketListComponent } from './modules/sprints/pages/sprint-planning-view/components/ticket-list/ticket-list.component';
import { TeamCapacityComponent } from './modules/sprints/pages/sprint-planning-view/components/team-capacity/team-capacity.component';
import { TeamVelocityComponent } from './modules/sprints/pages/sprint-planning-view/components/team-velocity/team-velocity.component';
import { PublicHolidayListComponent } from './modules/sprints/pages/sprint-planning-view/components/public-holiday-list/public-holiday-list.component';
import { SpinnerComponent } from './modules/shared/component/spinner/spinner.component';

@NgModule({
  declarations: [
    AppComponent,
    SprintPlanningViewComponent,
    SprintListPageComponent,
    TicketListComponent,
    TeamCapacityComponent,
    TeamVelocityComponent,
    PublicHolidayListComponent,
    SpinnerComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
