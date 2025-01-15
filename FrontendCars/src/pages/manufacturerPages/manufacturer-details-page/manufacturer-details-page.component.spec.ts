import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufacturerDetailsPageComponent } from './manufacturer-details-page.component';

describe('ManufacturerDetailsPageComponent', () => {
  let component: ManufacturerDetailsPageComponent;
  let fixture: ComponentFixture<ManufacturerDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufacturerDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManufacturerDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
