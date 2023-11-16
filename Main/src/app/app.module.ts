import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { TeamMembersComponent } from './components/team-members/team-members.component';
import { MainComponent } from './components/main/main.component';
import { HttpClientModule } from '@angular/common/http';
import { PublicHolidayComponent } from './components/public-holiday/public-holiday.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SprintComponent } from './components/sprint/sprint.component';
import { BacklogComponent } from './components/backlog/backlog.component';
import { TeamVelocityComponent } from './components/team-velocity/team-velocity.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TeamMembersComponent,
    MainComponent,
    PublicHolidayComponent,
    SprintComponent,
    BacklogComponent,
    TeamVelocityComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
