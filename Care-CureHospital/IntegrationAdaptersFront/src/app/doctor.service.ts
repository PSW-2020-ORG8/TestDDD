import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { EPrescription } from './models/EPrescription';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  readonly APIUrl = "http://localhost:51492/api";

  constructor(private http:HttpClient) {
    this.getEPrescriptionList();
   }

  getEPrescriptionList():Observable<any>{
    return this.http.get(this.APIUrl+'/eprescription');
  }

  addEPrescription(val:EPrescription):Observable<any>{
    return this.http.post(this.APIUrl+'/eprescription', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Something went wrong!' );
      })
    )
  }

  updateEPrescription(val:any){
    return this.http.put(this.APIUrl+'/eprescription', val);
  }

  generateEP(val:any){
    return this.http.get<any[]>(this.APIUrl+'/sftpep');
  }
}
