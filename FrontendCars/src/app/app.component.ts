import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[ManufacturerService]
})
export class AppComponent {
  title = 'FrontendCars';
}
