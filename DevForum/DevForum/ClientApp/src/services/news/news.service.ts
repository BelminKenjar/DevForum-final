import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private _http: HttpClient) { }

  GetNews(): Observable<any> {
    return this._http.get(`${environment.apiUrl}/News`);
  }
  PostNews(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/News`, model);
  }
  UpdateNews(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/News/${id}`, model);
  }
  DeleteNews(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/News/${id}`);
  }
}
