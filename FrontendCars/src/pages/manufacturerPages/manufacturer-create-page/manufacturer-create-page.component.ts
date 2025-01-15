import { Component } from '@angular/core';
import { ManufacturerCreateComponent } from "../../../components/manufacturerComponents/manufacturer-create/manufacturer-create.component";

@Component({
  selector: 'app-manufacturer-create-page',
  standalone: true,
  imports: [ManufacturerCreateComponent],
  templateUrl: './manufacturer-create-page.component.html',
  styleUrl: './manufacturer-create-page.component.css'
})
export class ManufacturerCreatePageComponent {

}
