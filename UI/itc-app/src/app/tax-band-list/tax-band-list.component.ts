import { Component, OnInit } from '@angular/core';
import { TaxBandModel } from './models/tax-band.model';
import { TaxBandsConsistencyResult } from './models/tax-band-consistency-result.model';
import { TaxBandListService } from './tax-band-list.service';

@Component({
  selector: 'app-tax-band-list',
  templateUrl: './tax-band-list.component.html',
  styleUrls: ['./tax-band-list.component.scss']
})
export class TaxBandListComponent implements OnInit {
  public taxBands: TaxBandModel[] | undefined;
  public consistencyCheck: TaxBandsConsistencyResult | undefined;

  constructor(private taxBandService: TaxBandListService) { }

  public ngOnInit(): void {
    this.taxBandService.getCheckConsistencyResult().subscribe(x => this.consistencyCheck = x);
    this.taxBandService.get().subscribe(x => this.taxBands = x)
  }
}
