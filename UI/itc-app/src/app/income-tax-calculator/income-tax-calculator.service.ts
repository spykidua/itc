import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { CalculationResult } from './calculation-result.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class IncomeTaxCalculatorService {
    constructor(private http: HttpClient) { }

    public getTaxCalculations(salary: number): Observable<CalculationResult> {
        return this.http.get<CalculationResult>(environment.api.url + `/api/salary/${salary}/calculate-report`);
    }
}
