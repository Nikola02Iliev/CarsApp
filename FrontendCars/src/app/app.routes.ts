import { Routes } from '@angular/router';
import { ManufacturersPageComponent } from '../pages/manufacturerPages/manufacturers-page/manufacturers-page.component';
import { ManufacturerDetailsPageComponent } from '../pages/manufacturerPages/manufacturer-details-page/manufacturer-details-page.component';
import { ManufacturerCreatePageComponent } from '../pages/manufacturerPages/manufacturer-create-page/manufacturer-create-page.component';
import path from 'path';
import { ManufacturerUpdatePageComponent } from '../pages/manufacturerPages/manufacturer-update-page/manufacturer-update-page.component';

export const routes: Routes = [
  { path: 'manufacturers', component: ManufacturersPageComponent },
  {
    path: 'manufacturers/manufacturer-details',
    component: ManufacturerDetailsPageComponent,
  },
  {
    path: 'manufacturers/create-manufacturer',
    component: ManufacturerCreatePageComponent,
  },
  {
    path: 'manufacturers/update-manufacturer',
    component: ManufacturerUpdatePageComponent,
  },
];
