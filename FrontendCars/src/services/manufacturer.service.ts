import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {

  constructor(private http: HttpClient) { }

  baseUrl:string = 'http://localhost:5261/api/Manufacturers';

  getManufacturers(): Observable<any> 
  {
    return this.http.get<any>(this.baseUrl);
  }
  
}
