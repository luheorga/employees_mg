import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { EmployeeService } from './employee.service';
import { Employees, Employee } from '../employee.model';
import { employeeUrl } from '../employee.urls';

describe('EmployeeService', () => {

  let httpMock: HttpTestingController;
  let service: EmployeeService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmployeeService]
    });
    service = TestBed.get(EmployeeService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should "getEmployees" get the list of employees info', () => {
    const expected = [{ id: 1, name: 'Luis' }, { id: 1, name: 'Hernando' }] as Employees;
    let actual: Employees;
    service.getEmployees().subscribe(result => actual = result);
    const request = httpMock.expectOne(employeeUrl.get);
    request.flush(expected);
    expect(request.request.method).toBe('GET');
    expect(actual).toEqual(expected);
  });

  it('should "getEmployee" get the employee with the given id', () => {
    const expected = { id: 1, name: 'Luis' } as Employee;
    let actual: Employee;
    service.getEmployee(1).subscribe(result => actual = result);
    const request = httpMock.expectOne(employeeUrl.get + '1');
    request.flush(expected);
    expect(request.request.method).toBe('GET');
    expect(actual).toEqual(expected);
  });

});
