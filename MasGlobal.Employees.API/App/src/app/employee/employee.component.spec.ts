import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './service/employee.service';
import { of } from 'rxjs';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;
  let service: jasmine.SpyObj<EmployeeService>;

  beforeEach(async(() => {
    service = jasmine.createSpyObj<EmployeeService>('EmployeeService', {
      getEmployees: of([]),
      getEmployee: of(null)
    });

    TestBed.configureTestingModule({
      declarations: [EmployeeComponent],
      providers: [{ provide: EmployeeService, useValue: service }]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
