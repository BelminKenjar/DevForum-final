import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubtopicService {

  constructor(private _http: HttpClient) { }

  GetSubtopics(id: any, pageNum: any, pageSize: any): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Subtopic/${id}/1/10`);
  }
}
