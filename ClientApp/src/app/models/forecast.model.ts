import { Conditions } from "./conditions.model";
import { Period } from "./period.model";

export interface Forecast
{
    period: Period;
    conditions: Conditions[];
}