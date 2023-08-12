import { NgModule } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { PoundMoneyPipe } from './pipes/pound-money.pipe';

@NgModule({
  declarations: [
    PoundMoneyPipe
  ],
  imports: [
    DecimalPipe,
    CommonModule
  ],
  exports: [
    PoundMoneyPipe
  ],
  providers:[
    DecimalPipe,
    PoundMoneyPipe
  ]
})
export class SharedModule { }
