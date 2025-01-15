import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufacturerCreatePageComponent } from './manufacturer-create-page.component';

describe('ManufacturerCreatePageComponent', () => {
  let component: ManufacturerCreatePageComponent;
  let fixture: ComponentFixture<ManufacturerCreatePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufacturerCreatePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManufacturerCreatePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
