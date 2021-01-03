import { Component, OnInit, Input } from '@angular/core';
import { DirectorServiceService } from 'src/app/director-service.service';
import { HttpClient } from '@angular/common/http'; 
import { Report } from 'src/app/models/Report';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  constructor(private service:DirectorServiceService, public http: HttpClient) { }

  @Input() rep:Report;
  medicamentName:string;
  quantity:number;
  fromDate:Date;
  toDate:Date;

  ReportList:any=[];

  ngOnInit(): void {
    this.medicamentName = this.rep.medicamentName;
    this.quantity = this.rep.quantity;
    this.fromDate = this.rep.fromDate;
    this.toDate = this.rep.toDate;
  }

  addReport(){
    var val = {medicamentName:this.ReportList.medicamentName,
              quantity:this.ReportList.quantity,
              fromDate:this.ReportList.fromDate,
              toDate:this.ReportList.toDate};

    this.service.addReports(val).subscribe(res=>{
      alert(res.toString())});
    alert("Successfully added report");
  }
}
