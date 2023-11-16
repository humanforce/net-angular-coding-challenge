import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class BacklogService {
    private dataUrl = environment.backlogDataUrl;
    constructor(private http: HttpClient) { }

    getBySprintId(sprintId: number): Observable<any[]> {
        let dataUrl = environment.environmentName === 'mock' ? environment.backlogDataUrl : `${environment.backlogDataUrl}/GetBySprintId/${sprintId}`;

        return this.http.get<any[]>(`${dataUrl}`).pipe(
            map((backlogs: any[]) => {
                if (environment.environmentName === 'mock') {
                    return backlogs.filter(backlog => backlog.fields.customfield_10020[0].id === sprintId);
                } else {
                    return backlogs;
                }
            })
        );
    }
}
