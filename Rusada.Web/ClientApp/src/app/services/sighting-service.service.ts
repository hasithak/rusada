import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { AirplaneSighting } from '../models/airplane-sighting';

@Injectable({
  providedIn: 'root'
})
export class SightingServiceService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    //this.baseUrl = baseUrl;
    //this.http = http;
  }

  add(airplaneSighting: AirplaneSighting): Observable<any> {
    return this.http.post(this.baseUrl + 'aircraftsightings', airplaneSighting);
  }

  getList(): Observable<AirplaneSighting[]> {
    return this.http.get<AirplaneSighting[]>(this.baseUrl + 'aircraftsightings');
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + `aircraftsightings/${id}`);
  }
}
