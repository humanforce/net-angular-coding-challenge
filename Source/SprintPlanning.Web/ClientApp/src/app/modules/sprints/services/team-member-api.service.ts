import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SprintItem } from '../models/sprint-item.model';
import { PublicHolidayItem } from '../models/public-holiday-item.model';
import { TeamVelocity } from '../models/team-velocity.model';
import { TeamCapacity } from '../models/team-capacity.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeamMemberApiService {

  private baseUrl = 'https://localhost:7070/api/team-members';

  constructor(private http: HttpClient) {}

  public getPublicHolidays(
    sprint: SprintItem
  ): Observable<PublicHolidayItem[]> {
    return this.http.post<PublicHolidayItem[]>(
      `${this.baseUrl}/holidays`,
      sprint
    );
  }

  public getTeamVelocity(sprint: SprintItem): Observable<TeamVelocity> {
    return this.http.post<TeamVelocity>(
      `${this.baseUrl}/velocity`,
      sprint
    );
  }

  public getTeamCapacity(sprint: SprintItem): Observable<TeamCapacity[]> {
    return this.http.post<TeamCapacity[]>(
      `${this.baseUrl}/capacity`,
      sprint
    );
  }
}

