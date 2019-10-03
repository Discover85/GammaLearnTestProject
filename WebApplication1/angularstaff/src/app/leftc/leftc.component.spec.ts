import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeftcComponent } from './leftc.component';

describe('LeftcComponent', () => {
  let component: LeftcComponent;
  let fixture: ComponentFixture<LeftcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeftcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeftcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
