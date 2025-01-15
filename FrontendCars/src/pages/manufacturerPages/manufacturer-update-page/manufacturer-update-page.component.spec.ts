import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufacturerUpdatePageComponent } from './manufacturer-update-page.component';

describe('ManufacturerUpdatePageComponent', () => {
  let component: ManufacturerUpdatePageComponent;
  let fixture: ComponentFixture<ManufacturerUpdatePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufacturerUpdatePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManufacturerUpdatePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
