import { Conditions } from "./conditions.model";
import { Forecast } from "./forecast.model";

export interface Report
{
    conditions: Conditions;
    forecast: Forecast;
}