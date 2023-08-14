import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IncomeTaxcalculatorComponent } from './income-tax-calculator/income-tax-calculator.component';
import { TaxBandListComponent } from './tax-band-list/tax-band-list.component';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: '',
      pathMatch: 'full',
      redirectTo: 'income-tax-calculator'
    },
    {
      path: 'income-tax-calculator',
      component: IncomeTaxcalculatorComponent
    },
    {
      path: 'tax-band-list',
      component: TaxBandListComponent
    }
  ]
},
{
  path: '**',
  redirectTo: ''
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
