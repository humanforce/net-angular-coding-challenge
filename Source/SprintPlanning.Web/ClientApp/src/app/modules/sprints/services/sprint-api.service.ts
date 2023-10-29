import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SprintItem } from '../models/sprint-item.model';
import { Observable } from 'rxjs';
import { TicketItem } from '../models/ticket-item.model';

@Injectable({
  providedIn: 'root',
})
export class SprintApiService {
  private baseUrl = 'https://localhost:7070/api/sprints';

  constructor(private http: HttpClient) {}

  public getSprints(): Observable<SprintItem[]> {
    return this.http.get<SprintItem[]>(`${this.baseUrl}`);
  }

  public getSprintDetails(sprintId: number): Observable<SprintItem> {
    return this.http.get<SprintItem>(`${this.baseUrl}/${sprintId}`);
  }

  public getSprintTickets(sprintId: number): Observable<TicketItem[]> {
    return this.http.get<TicketItem[]>(`${this.baseUrl}/${sprintId}/tickets`);
  }
}
