import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostLikeService {

  constructor(private _http: HttpClient) { }

  // GetPostLike(id: any, pageNum: any, pageSize: any, searchObject: any): Observable<any> {
  //   return this._http.get(`${environment.apiUrl}/PostLike/${id}/${pageNum}/${pageSize}?Title=${searchObject.Name}`);
  // }
  PostPostLike(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/PostLike`, model);
  }
  DeletePostLike(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/PostLike/${id}`);
  }
  GetPostLikeById(id: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/PostLike/${id}`);
  }
}
