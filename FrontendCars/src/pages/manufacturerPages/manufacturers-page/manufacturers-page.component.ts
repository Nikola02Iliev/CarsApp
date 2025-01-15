import { Component } from '@angular/core';
import { ManufacturersListComponent } from "../../../components/manufacturerComponents/manufacturers-list/manufacturers-list.component";
import { ManufacturerService } from '../../../services/manufacturer.service';

@Component({
  selector: 'app-manufacturers-page',
  standalone: true,
  imports: [ManufacturersListComponent],
  templateUrl: './manufacturers-page.component.html',
  styleUrl: './manufacturers-page.component.css'
})
export class ManufacturersPageComponent {

  constructor(){}  


}
