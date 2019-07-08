import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './service/employee.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Employees } from './employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  employees$: Observable<Employees>;
  employeeId: number = null;

  constructor(private service: EmployeeService) { }

  ngOnInit() {
  }

  getEmployees(employeeId: number) {
    if (!employeeId) {
      this.employees$ = this.service.getEmployees();
    } else {
      this.employees$ = this.service.getEmployee(employeeId)
        .pipe(
          map(employee => [employee])
        );
    }
  }

}
