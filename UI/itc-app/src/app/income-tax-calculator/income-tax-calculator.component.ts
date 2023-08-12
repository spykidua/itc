import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CalculationResult } from './calculation-result.model';
import { IncomeTaxCalculatorService } from './income-tax-calculator.service';

@Component({
  selector: 'app-income-tax-calculator',
  templateUrl: './income-tax-calculator.component.html',
  styleUrls: ['./income-tax-calculator.component.scss']
})
export class IncomeTaxcalculatorComponent implements OnInit {
  public formGroup!: FormGroup;
  public calculationResult!: CalculationResult;

  constructor(
    private taxCalculatorService: IncomeTaxCalculatorService,
    private fb: FormBuilder
  ) { }

  public ngOnInit(): void {
    this.formGroup = this.fb.group({
      salary: [0, [
        Validators.required,
        Validators.min(100)
      ]]
    });
  }

  public submit() {
    this.taxCalculatorService.getTaxCalculations(this.formGroup.value.salary).subscribe(x => {
      this.calculationResult = x;
      this.formGroup.reset(this.formGroup.value);
    });
  }

  public getSubmitBlockReasone(): string {
    if (this.formGroup.valid) {
      return '';
    }

    const errors: Array<string> = [];
    const salaryControl = this.formGroup.controls['salary'];

    if (salaryControl.errors?.['required']) {
      errors.push('Gross Annual Salary is required');
    }

    if (salaryControl.errors?.['min']) {
      errors.push('Gross Annual Salary should be more then 100');
    }

    if(!this.formGroup.dirty){
      errors.push('Salary wasn\'t input or value haven\'t changed since previouse request');
    }

    return errors.join('\r\n');;
  }
}
