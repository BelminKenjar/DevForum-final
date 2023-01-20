import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private _http: HttpClient) { }

  GetPosts(id: any, pageNum: any, pageSize: any, searchObject: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Post/${id}/${pageNum}/${pageSize}?Title=${searchObject.Name}`);
  }
  PostPosts(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Post`, model);
  }
  UpdatePost(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Post/${id}`, model);
  }
  DeletePost(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/Post/${id}`);
  }
  GetPostById(id: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Post/${id}`);
  }
}
