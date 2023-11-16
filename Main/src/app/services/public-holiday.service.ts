import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PublicHolidayService {
    private dataUrl = environment.publicHolidayDataUrl; 
    constructor(private http: HttpClient) { }

    getByCountryName(countryName: string): Observable<any[]> {
        let dataUrl = environment.environmentName === 'mock' ? `${environment.publicHolidayDataUrl}/${countryName.toLowerCase()}.json` : `${environment.publicHolidayDataUrl}/GetByCountryName/${countryName}`;
        return this.http.get<any[]>(dataUrl);
    }
}
