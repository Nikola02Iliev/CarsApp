import { Component, HostListener, OnInit } from '@angular/core';
import { ManufacturerService } from '../../../services/manufacturer.service';
import { ManufacturerInListDTO } from '../../../dtos/manufacturerDtos/manufacturerInListDTO.interface';
import { NgClass, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-manufacturers-list',
  standalone: true,
  imports: [NgFor, NgClass, NgIf],
  templateUrl: './manufacturers-list.component.html',
  styleUrl: './manufacturers-list.component.css',
})
export class ManufacturersListComponent implements OnInit{

  constructor(private manufacturerService: ManufacturerService) {}

  manufacturers: ManufacturerInListDTO[] = [];
  screenWidth!: number;
  screenHeight!: number;
  isLoading: boolean = true;

  @HostListener('window:resize',['$event'])
  onresize(event:Event)
  {
    if(typeof window !== "undefined"){
      this.screenWidth = window.innerWidth;
      this.screenHeight = window.innerHeight;
      console.log(this.screenWidth);
      console.log(this.screenHeight);
    }
  }

  ngOnInit(): void {
    
    this.manufacturerService.getManufacturers().subscribe(
      (manufacturers)=>{
        this.manufacturers = manufacturers;
        this.isLoading = false;
      }
    )

    if(typeof window !== "undefined"){
      this.screenWidth = window.innerWidth;
      this.screenHeight = window.innerHeight;
    }
    
  }
}
