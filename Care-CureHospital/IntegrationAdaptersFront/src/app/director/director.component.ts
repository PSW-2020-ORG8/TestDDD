import { Component, OnInit } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';
import { Report } from '../models/Report';

@Component({
  selector: 'app-director',
  templateUrl: './director.component.html',
  styleUrls: ['./director.component.css']
})
export class DirectorComponent implements OnInit {

  constructor(private service:DirectorServiceService) { }

  medicamentName:string;
  quantity:number;
  fromDate:Date;
  toDate:Date;

  ReportList: Report[];

  ModalTitle:string;
  ActivateAddEditRepComp:boolean=false;
  rep:Report;

  ngOnInit(): void {
    this.refreshReportList();
  }

  addclick(){
    this.rep={
      medicamentName:"",
      quantity: 0,
      fromDate: null,
      toDate: null
    }
    this.ModalTitle="Add Report";
    this.ActivateAddEditRepComp=true;
  }

  closeClick(){
    this.ActivateAddEditRepComp=false;
    this.refreshReportList();
  }

  refreshReportList(){
    this.service.getReportList().subscribe((data: Report[]) => {
      console.log(data);
      this.ReportList = data;
    })
  }

  generate(){
    alert("Report saved!");
    console.log(this.ReportList);
  }

  publishT(){
    this.service.publishTender().subscribe(data=>{
      console.log("Successfully sent!");
      alert("Successfully sent!");
    },
    Error => {
      console.log("Error");
    });
  }
}
