import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortURLInfoComponent } from './short-urlinfo.component';

describe('ShortURLInfoComponent', () => {
  let component: ShortURLInfoComponent;
  let fixture: ComponentFixture<ShortURLInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShortURLInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortURLInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
