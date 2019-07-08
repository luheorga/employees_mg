export type Employees = Employee[];

export class Employee {
    id: number;
    name: string;
    roleId: number;
    roleName: string;
    roleDescription: string;
    contractName: string;
    salary: number;
    annualSalary: number;
}
