import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IncomeTaxcalculatorComponent } from './income-tax-calculator/income-tax-calculator.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { DecimalPipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    IncomeTaxcalculatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    SharedModule,
    HttpClientModule,
    DecimalPipe
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
