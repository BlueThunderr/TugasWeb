import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LaporanHeader } from '../../../models/LaporanHeaderModel';
import { Observable } from 'rxjs';

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
export class LaporanService {
  baseUrl: string = 'https://localhost:5001/api/laporan';

  constructor(private http: HttpClient) { }

  getLaporans(){
    return this.http.get<any[]>(this.baseUrl);
  }

  postLaporan(laporanHeader: LaporanHeader):Observable<any>{
    return this.http.post(this.baseUrl, laporanHeader);
  }

  changeStatusLaporan(laporanHeaderId, statusLaporan):Observable<any>{
    return this.http.get(this.baseUrl+ '/changeStatus?laporanHeaderId=' + laporanHeaderId + '&statusLaporan=' + statusLaporan);
  }
}
