import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-urgent-procurement',
  templateUrl: './urgent-procurement.component.html',
  styleUrls: ['./urgent-procurement.component.css']
})
export class UrgentProcurementComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  sendHttpRequest(){
    console.log("tu sm");
  }
}
