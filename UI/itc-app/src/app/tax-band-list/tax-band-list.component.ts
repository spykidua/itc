import { Component, OnInit } from '@angular/core';
import { TaxBandModel } from './models/tax-band.model';
import { TaxBandsConsistencyResult } from './models/tax-band-consistency-result.model';
import { TaxBandListService } from './tax-band-list.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-tax-band-list',
  templateUrl: './tax-band-list.component.html',
  styleUrls: ['./tax-band-list.component.scss']
})
export class TaxBandListComponent implements OnInit {
  public taxBands: TaxBandModel[] | undefined;
  public consistencyCheck: TaxBandsConsistencyResult | undefined;
  public checkSpinnerName = "check-spinner";
  public bandsSpinnerName = "bands-spinner"

  constructor(private taxBandService: TaxBandListService, private spinner: NgxSpinnerService) { }

  public ngOnInit(): void {
    this.spinner.show(this.checkSpinnerName);
    this.spinner.show(this.bandsSpinnerName);
    this.taxBandService.getCheckConsistencyResult().subscribe(x => {
      this.consistencyCheck = x;
      setTimeout(() => this.spinner.hide(this.checkSpinnerName), 4000);
    });
    this.taxBandService.get().subscribe(x => {
      this.taxBands = x;
      setTimeout(() => this.spinner.hide(this.bandsSpinnerName), 2000);
    })
  }
}
