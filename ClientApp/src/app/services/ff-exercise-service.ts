import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { CurrentAirportInfo } from "../models/current-airport-info.model";

@Injectable()
export class FFExerciseService
{
    private baseUrl: string;
    private headers: HttpHeaders;

    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        //this.baseUrl = baseUrl;// + 'api/';
        this.baseUrl = 'https://localhost:7251/api/';

        this.headers = new HttpHeaders();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.headers.append('Access-Control-Allow-Origin', '*');
    }

    public GetCurrentAirportInfo = (airportCodes: string): Observable<CurrentAirportInfo[]> => {
        const fullActionUrl = this.baseUrl + 'airportinfo?airportList=' + airportCodes;
        return this._http.get(fullActionUrl, 
        { headers: this.headers })
            .pipe(map((response) => <CurrentAirportInfo[]>response));
    }
}