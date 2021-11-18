import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: "root",
})
export class ProfileService {
  constructor(private _http: HttpClient) { }

  GetUserProfile(): Observable<any> {
    return this._http.get(`${environment.apiUrl}/Profile/current`);
  }
  UpdateProfile(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/Profile/${id}`, model);
  }
  UpdateProfileDetails(id: any, model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/ProfileDetails/${id}`, model);
  }
  InsertProfileDetails(model: any): Observable<any> {
    return this._http.post(`${environment.apiUrl}/ProfileDetails`, model);
  }
  DeleteAccount(id: any): Observable<any> {
    return this._http.delete(`${environment.apiUrl}/Profile/${id}`);
  }
}
