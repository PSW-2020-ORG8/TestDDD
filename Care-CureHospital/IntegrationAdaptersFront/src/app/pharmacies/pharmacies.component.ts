import { Component, OnInit } from '@angular/core';
import { PharmacyService } from 'src/app/pharmacy.service';
import { Pharmacy } from './pharmacy';

@Component({
  selector: 'app-pharmacies',
  templateUrl: './pharmacies.component.html',
  styleUrls: ['./pharmacies.component.css']
})
export class PharmacyComponent implements OnInit {

  pharmacy = new Pharmacy(null,null,null);

  constructor(private pharmacyService : PharmacyService) { }

  ngOnInit(): void {
  }

  onSubmitPharmacy(){ 
    console.log(this.pharmacy)
    this.pharmacyService.addPh(this.pharmacy).subscribe(data => {
      console.log('Success!', JSON.stringify(data))
      alert('Uspesna registracija apoteke!')
    }, error => {
      console.log('Error');
      alert('Niste uspesno registrovali apoteku')
    });
  }
}