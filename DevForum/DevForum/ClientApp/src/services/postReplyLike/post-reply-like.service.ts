import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostReplyLikeService {
  constructor(private _http: HttpClient) { }
  InsertPostReplyLike(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/PostReplyLike`, model);
  }

  GetPostReplyLike(): Observable<any> {
    return this._http.get(`${environment.apiUrl}/PostReplyLike`);
  }
}
