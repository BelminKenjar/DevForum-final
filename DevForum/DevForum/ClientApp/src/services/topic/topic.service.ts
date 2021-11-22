import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private _http: HttpClient) { }

  GetTopics(pageNum: number, pageSize: number, searchObject: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Topic/${pageNum}/${pageSize}?Title=${searchObject.Title}`);
  }
  GetTopicById(id: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Topic/${id}`);
  }
  PostTopic(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Topic`, model);
  }
  UpdateTopic(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Topic/${id}`, model);
  }
  DeleteTopic(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/Topic/${id}`);
  }
}
