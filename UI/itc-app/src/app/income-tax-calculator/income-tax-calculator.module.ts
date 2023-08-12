import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { IncomeTaxcalculatorComponent } from './income-tax-calculator.component';

@NgModule({
  declarations: [
    IncomeTaxcalculatorComponent
  ],
  imports: [
    ReactiveFormsModule,
  ],
  exports: [IncomeTaxcalculatorComponent]
})
export class AppModule { }
