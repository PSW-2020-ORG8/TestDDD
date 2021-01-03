import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable, throwError } from 'rxjs';
import { Report } from './models/Report';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class DirectorServiceService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) { this.getReportList() }

  getReportList():Observable<Report[]>{
    return this.http.get<Report[]>(this.APIUrl+'/report');
  }

  addReports(val:Report):Observable<Report>{
    return this.http.post<Report>(this.APIUrl+'/report', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Something went wrong!' );
      })
    )
  }
  
  updateReport(val:any){
    return this.http.put(this.APIUrl+'/report', val);
  }

  generate(val:any){
    return this.http.post<any[]>(this.APIUrl+'/report', val);
  }

  publishTender(){
    return this.http.get<any[]>(this.APIUrl+'/tender');
  }
}
