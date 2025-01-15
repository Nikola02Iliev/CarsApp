import { Component, OnInit } from '@angular/core';
import { ManufacturerService } from '../../../services/manufacturer.service';

@Component({
  selector: 'app-manufacturers-list',
  standalone: true,
  imports: [],
  templateUrl: './manufacturers-list.component.html',
  styleUrl: './manufacturers-list.component.css'
})
export class ManufacturersListComponent implements OnInit {
  
  constructor(private manufacturerService: ManufacturerService) { }

  ngOnInit(): void {
    this.manufacturerService.getManufacturers().subscribe(
      (manufacturers)=>{
        console.log(manufacturers);
      }
    )
  }


}
