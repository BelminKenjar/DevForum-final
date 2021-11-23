import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubtopicService {

  constructor(private _http: HttpClient) { }

  GetSubtopics(id: any, pageNum: any, pageSize: any, searchObject: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Subtopic/${id}/${pageNum}/${pageSize}?Title=${searchObject.Name}`);
  }
  PostSubtopic(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Subtopic`, model);
  }
  UpdateSubtopic(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Subtopic/${id}`, model);
  }
  DeleteSubtopic(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/Subtopic/${id}`);
  }
}
