import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { TaxBandsConsistencyResult } from "./models/tax-band-consistency-result.model";
import { TaxBandModel } from "./models/tax-band.model";

@Injectable({
    providedIn: 'root'
})
export class TaxBandListService {
    constructor(private http: HttpClient) { }

    public get(): Observable<TaxBandModel[]> {
        return this.http.get<TaxBandModel[]>(environment.api.url + `/api/tax-bands`);
    }

    public getCheckConsistencyResult(): Observable<TaxBandsConsistencyResult> {
        return this.http.get<TaxBandsConsistencyResult>(environment.api.url + `/api/tax-bands/check`);
    }
}