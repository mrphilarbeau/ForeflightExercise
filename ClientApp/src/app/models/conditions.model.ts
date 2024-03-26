import { CloudLayer } from "./cloud-layer.model";
import { Visibility } from "./visibility.model";
import { Wind } from "./wind.model";

export interface Conditions
{
    tempC: number;
    tempF: number;
    relativeHumidity: number;
    cloudLayers: CloudLayer[];
    visibility: Visibility;
    wind: Wind;
    dateIssued: string;
}