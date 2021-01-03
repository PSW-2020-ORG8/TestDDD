import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pharmacy } from './pharmacies/pharmacy';
import { Medicament } from './models/Medicament';

@Injectable({
    providedIn: 'root'
  })

  export class PharmacyService {
    readonly APIUrl = "http://localhost:51492/api";

    constructor(private http: HttpClient) { 
      this.generateMedicamentStock();
    }

    addPh(pharmacy: Pharmacy): Observable<any> {
        return this.http.post(`http://localhost:51492/api/pharmacy/addPharmacy`, pharmacy);
      }

    getAllPharmacies(): Observable<any> {
        return this.http.get(`http://localhost:51492/api/pharmacy/getPharmacies`);
      }

    generateMedicamentStock():Observable<any>{
      return this.http.get<any>(this.APIUrl+'/stock');
    }
  }