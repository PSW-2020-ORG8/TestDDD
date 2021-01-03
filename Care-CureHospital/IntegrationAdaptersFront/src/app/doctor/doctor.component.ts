import { Component, OnInit } from '@angular/core';
import { DoctorService } from 'src/app/doctor.service';
import { EPrescription } from '../models/EPrescription';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  constructor(private service:DoctorService) { }

  EPrescriptionList: EPrescription[];

  ModalTitle:string;
  ActivateAddEditEPComp:boolean=false;
  ep:EPrescription;

  ngOnInit(): void {
    this.refreshEPrescList();
  }

  addEP(){
    this.ModalTitle="Add EPrescription";
    this.ActivateAddEditEPComp=true;
  }

  refreshEPrescList(){
    this.service.getEPrescriptionList().subscribe((data:EPrescription[])  => {
      console.log(data);
      this.EPrescriptionList = data;
    });
  }

  closeClick(){
    this.ActivateAddEditEPComp=false;
    this.refreshEPrescList();
  }
}
