import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RightcComponent } from './rightc.component';

describe('RightcComponent', () => {
  let component: RightcComponent;
  let fixture: ComponentFixture<RightcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RightcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RightcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
