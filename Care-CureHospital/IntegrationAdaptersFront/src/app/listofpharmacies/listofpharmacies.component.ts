import { Component, OnInit } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';
import { Medicament } from '../models/Medicament';

@Component({
    selector: 'app-listofpharmacies',
    templateUrl: './listofpharmacies.component.html',
    styleUrls: ['./listofpharmacies.component.css']
  })

  export class ListofPharmaciesComponent implements OnInit {

    categories = [];
    medicamentName;
  
    constructor(private pharmacyService: PharmacyService) { }
  
    ModalTitle:string;
    ActivateAddEditRepComp:boolean=false;
    med:Medicament;

    ngOnInit() {
        this.getAll();
    }
  
    private getAll(): void {
        this.pharmacyService.getAllPharmacies().subscribe(data => {
          this.categories = data;
          console.log("Pharmacies: ",this.categories)
        }, error => {
          console.log('Error');
        });
      }

    addStock(){
      this.ModalTitle="Medicament stock";
      this.ActivateAddEditRepComp=true;
    }
  }