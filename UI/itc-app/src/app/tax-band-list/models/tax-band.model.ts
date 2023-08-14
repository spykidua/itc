export class TaxBandModel
{
    name: string;
    upperLimit?: number = undefined;
    lowerLimit: number;
    rate: number;
}