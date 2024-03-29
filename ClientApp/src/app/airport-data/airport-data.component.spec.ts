import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';

import { AirportDataComponent } from './airport-data.component';
import { HttpClientModule } from '@angular/common/http';
import { FFExerciseService } from '../services/ff-exercise-service';
import { of } from 'rxjs';
import { MatAccordion } from '@angular/material/expansion';
import { CurrentAirportInfo } from '../models/current-airport-info.model';

let currentAirportInfo: CurrentAirportInfo = 
{
  identifier: 'KCAR',
  name: 'Caribou Municipal Airport',
  runways: [{
    ident: '01',
    name: '01',
    recipName: '19'
  }],
  bestRunway: '01',
  latitude: '',
  longitude: '',
  weatherReport: { 
    report: {
      conditions: {
        tempC: 1,
        tempF: 33,
        relativeHumidity: 80,
        cloudLayers: [{
          coverage: 'ovc',
          altitudeFt: 2000,
          ceiling: true
        }],
        visibility: {
          distanceSm: 5
        },
        wind: {
          speedKts: 7,
          direction: 10,
          from: 190,
          variable: false
        },
        dateIssued: ''
      },
      forecast: {
        period: {
          dateStart: '3-23-24'
        },
        conditions: [{
          tempC: 1,
          tempF: 33,
          relativeHumidity: 80,
          cloudLayers: [{
            coverage: 'ovc',
            altitudeFt: 2000,
            ceiling: true
          }],
          visibility: {
            distanceSm: 5
          },
          wind: {
            speedKts: 7,
            direction: 10,
            from: 190,
            variable: false
          },
          dateIssued: ''
        }]
      }
    }
  }
};

export class MockFFService {  
  getCurrentAirportInfo() {
    return of([currentAirportInfo]);
  }
}

describe('AirportDataComponent', () => {
  let component: AirportDataComponent;
  let fixture: ComponentFixture<AirportDataComponent>;
  
  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ AirportDataComponent, MatAccordion ],
      imports: [ HttpClientModule ],
      providers: [{ provide: FFExerciseService, useClass: MockFFService }]
    }).compileComponents();

    fixture = TestBed.createComponent(AirportDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getCurrentAirportInfo() of ffExerciseService', () => {
    spyOn(component.ffExerciseService, 'getCurrentAirportInfo').and.returnValue(of([currentAirportInfo]));
    component.searchAirports('pqi,car');
    expect(component.ffExerciseService.getCurrentAirportInfo).toHaveBeenCalled();
    expect(component.currentAirportInfo.length).toBe(1);
    expect(component.currentAirportInfo[0].bestRunway).toBe('01');
  });
});

