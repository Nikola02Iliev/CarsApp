import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ManufacturerInListDTO } from '../dtos/manufacturerDtos/manufacturerInListDTO.interface';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = 'http://localhost:5261/api/Manufacturers';

  getManufacturers(): Observable<ManufacturerInListDTO[]> 
  {
    return this.http.get<ManufacturerInListDTO[]>(this.baseUrl);
  }
  
}
