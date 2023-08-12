import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
      loadChildren: () => import('./income-tax-calculator/income-tax-calculator-routing.module').then(m => m.IncomeTaxCalculatorRoutingModule)
    }
  ]
},
// {
//   path: 'forbidden',
//   loadChildren: () => import('./forbidden-page/forbidden-page.module').then(m => m.ForbiddenPageModule)
// },
{
  path: '**',
  redirectTo: ''
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
