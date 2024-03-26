import { Runway } from "./runway.model";
import { WeatherReport } from "./weather-report.model";

export interface CurrentAirportInfo
{
    identifier: string;
    name: string;
    runways: Runway[];
    bestRunway: string;
    latitude: string;
    longitude: string;
    weatherReport: WeatherReport;
}