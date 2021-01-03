import { Component, OnInit, Input } from '@angular/core';
import { DoctorService } from 'src/app/doctor.service';
import { EPrescription } from '../../models/EPrescription';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-eprescription',
  templateUrl: './eprescription.component.html',
  styleUrls: ['./eprescription.component.css']
})
export class EprescriptionComponent implements OnInit {

  constructor(private service:DoctorService, public http: HttpClient) { }

  @Input() ep:EPrescription;
   patientName:string;
   comment:string;
   medicamentName:string;
   publishingDate:Date;

  EPrescriptionList:any=[];
  
  ngOnInit(): void {
    this.patientName = this.ep.patientName;
    this.comment = this.ep.comment;
    this.medicamentName = this.ep.medicamentName;
    this.publishingDate = this.ep.publishingDate;
  }

  addEPrescription(){
  var val = {patientName:this.EPrescriptionList.patientName,
            comment:this.EPrescriptionList.comment,
            medicamentName:this.EPrescriptionList.medicamentName,
            publishingDate:this.EPrescriptionList.publishingDate
            };
    this.service.addEPrescription(val).subscribe(
      epr => {alert(epr.toString())});
  alert("Successfully added medication!");
  }

  generateEP(){
    alert("EPrescription saved!");
  }
}
