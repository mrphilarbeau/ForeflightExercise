import { Component, OnInit } from '@angular/core';
import { FFExerciseService } from '../services/ff-exercise-service';
import { CurrentAirportInfo } from '../models/current-airport-info.model';

@Component({
  selector: 'app-airport-data',
  providers: [FFExerciseService],
  templateUrl: './airport-data.component.html',
  styleUrls: ['./airport-data.component.css']
})
export class AirportDataComponent implements OnInit {
  public currentAirportInfo: CurrentAirportInfo[] = [];
  searchAirportCodes: string = '';

  constructor(private ffExerciseService: FFExerciseService) { }

  ngOnInit(): void {
    
  }

  getWeatherTimeOffset(periodStartDate: string, forecastDate: string): string {
    let startDate = new Date(periodStartDate);
    let endDate = new Date(forecastDate);
    let timeDifference = endDate.getTime() - startDate.getTime();
    let minutes = Math.floor((timeDifference / (1000 * 60)) % 60);
    let hours = Math.floor((timeDifference / (1000 * 60 * 60)) % 24);

    return hours.toString() + ':' + (minutes < 10 ? '0' + minutes.toString() : minutes.toString());
  }

  searchAirports(airportCodes: string) {
    this.ffExerciseService.GetCurrentAirportInfo(airportCodes).subscribe(result => {
      this.currentAirportInfo = result; console.log(result); console.log(this.currentAirportInfo);
    }, error => console.error(error));
  }
   
}
