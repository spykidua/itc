import {
    Pipe,
    PipeTransform
  } from '@angular/core';
  import { DecimalPipe } from '@angular/common';
  
  @Pipe({ name: 'poundMoney' })
  export class PoundMoneyPipe implements PipeTransform {
    constructor(private decimalPipe: DecimalPipe) {}
  
    transform(value: number | undefined, decimals: number) {
        if (!value && value !== 0) {
            return '-';
          }
      
          const pipeResult = this.decimalPipe.transform(value, `1.${decimals}-${decimals}`);
      
          return !pipeResult ? '-' : '£' + pipeResult;
    }
}