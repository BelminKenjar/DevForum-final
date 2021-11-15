import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private _http: HttpClient) { }

  GetUserProfile(): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Profile/current`);
  }
}
