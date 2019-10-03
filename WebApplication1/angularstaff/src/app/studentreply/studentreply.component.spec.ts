import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentreplyComponent } from './studentreply.component';

describe('StudentreplyComponent', () => {
  let component: StudentreplyComponent;
  let fixture: ComponentFixture<StudentreplyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentreplyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentreplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
