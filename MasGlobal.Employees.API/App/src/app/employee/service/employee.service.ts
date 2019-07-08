import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employees, Employee } from '../employee.model';
import { HttpClient } from '@angular/common/http';
import { employeeUrl } from '../employee.urls';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${employeeUrl.get}${id}`);
  }

  getEmployees(): Observable<Employees> {
    return this.http.get<Employees>(employeeUrl.get);
  }
}
