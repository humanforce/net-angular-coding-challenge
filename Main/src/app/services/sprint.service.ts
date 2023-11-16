import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SprintService {
  constructor(private http: HttpClient) { }
  private dataUrl = environment.sprintDataUrl; 

  getAll(): Observable<any[]> {
    let dataUrl = environment.environmentName === 'mock' ? environment.sprintDataUrl : `${environment.sprintDataUrl}/GetAll`; 
    return this.http.get<any[]>(dataUrl);
  }
}
