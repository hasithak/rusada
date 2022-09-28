import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SightingAddComponent } from './sighting-add.component';

describe('SightingAddComponent', () => {
  let component: SightingAddComponent;
  let fixture: ComponentFixture<SightingAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SightingAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SightingAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
