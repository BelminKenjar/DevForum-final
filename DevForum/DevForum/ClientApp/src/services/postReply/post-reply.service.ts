import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostReplyService {

  constructor(private _http: HttpClient) { }

  GetPostReply(id: any, pageNum: any, pageSize: any, searchObject: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/PostReply/${id}/${pageNum}/${pageSize}?Title=${searchObject.Name}`);
  }
  PostPostReply(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/PostReply`, model);
  }
  UpdatePostReply(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/PostReply/${id}`, model);
  }
  DeletePostReply(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/PostReply/${id}`);
  }
  GetPostReplyById(id: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/PostReply/${id}`);
  }
}
