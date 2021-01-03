import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectorComponent } from './director/director.component';
import { DoctorComponent } from './doctor/doctor.component';
import { ReportComponent } from './director/report/report.component';
import { DirectorServiceService } from './director-service.service';
import { ListofPharmaciesComponent } from './listofpharmacies/listofpharmacies.component';
import { PharmacyComponent } from './pharmacies/pharmacies.component';
import{ HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableExporterModule } from 'mat-table-exporter';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { EprescriptionComponent } from './doctor/eprescription/eprescription.component';
import { MedicamentComponent } from './medicament/medicament.component';
import { UrgentProcurementComponent } from './urgent-procurement/urgent-procurement.component';
import { TenderComponent } from './doctor/tender/tender.component';

@NgModule({
  declarations: [
    AppComponent,
    DirectorComponent,
    DoctorComponent,
    ReportComponent,
    EprescriptionComponent,
    ListofPharmaciesComponent,
    PharmacyComponent,
    MedicamentComponent,
    UrgentProcurementComponent,
    TenderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    MatTableExporterModule,
    MatButtonModule
  ],
  providers: [ DirectorServiceService],
  bootstrap: [AppComponent]
})

export class AppModule { }
