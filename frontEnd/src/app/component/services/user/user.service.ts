import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../../../models/UserModel';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'text/plain',
    'Access-Control-Allow-Origin' : 'http://localhost:5100',
    'Access-Control-Allow-Credentials' : 'true',
    'Access-Control-Allow-Methods' : 'GET, POST, OPTIONS',
    'Access-Control-Allow-Headers' : 'Origin, Content-Type, Accept'
  })
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: string = 'https://localhost:5001/api/user';

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<any[]>(this.baseUrl, httpOptions);
  }

  //NOTE JANGAN PAKE INI LAGI KARENA UDAH ADA AUTHENTICATION SERVICE
  login(userName:string, password: string):Observable<any>{
    return this.http.get(this.baseUrl + '/login?userName=' + userName + '&password=' + password, httpOptions);
  };

  postUser(user: User):Observable<any>{
    return this.http.post(this.baseUrl, user);
  }
}
