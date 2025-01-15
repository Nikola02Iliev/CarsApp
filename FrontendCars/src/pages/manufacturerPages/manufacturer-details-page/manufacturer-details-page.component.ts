import { Component } from '@angular/core';
import { ManufacturerDetailsComponent } from "../../../components/manufacturerComponents/manufacturer-details/manufacturer-details.component";

@Component({
  selector: 'app-manufacturer-details-page',
  standalone: true,
  imports: [ManufacturerDetailsComponent],
  templateUrl: './manufacturer-details-page.component.html',
  styleUrl: './manufacturer-details-page.component.css'
})
export class ManufacturerDetailsPageComponent {

}
