import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IncomeTaxcalculatorComponent as IncomeTaxCalculatorComponent } from './income-tax-calculator.component';

const routes: Routes = [
  {
    path: '',
    component: IncomeTaxCalculatorComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IncomeTaxCalculatorRoutingModule {
}
