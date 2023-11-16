import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeamMembersService {

  constructor(private http: HttpClient) { }
  private dataUrl = environment.teamMemberDataUrl

  getAll(): Observable<any[]> {
    let dataUrl = environment.environmentName === 'mock' ? environment.teamMemberDataUrl : `${environment.teamMemberDataUrl}/GetAll`; 
    return this.http.get<any[]>(dataUrl);
  }
}
