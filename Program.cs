using System;

namespace EmployeePayRollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Services");
            Console.WriteLine("*****************************************");
           
            EmployeeRepo repo = new EmployeeRepo();
            Console.WriteLine("1.Get data from database employee payroll");
            Console.WriteLine("2.Add data to database employee payroll");
            Console.WriteLine("3.Update the salary for employee and update with database");
            Console.WriteLine("4.Get Employee details who joined in a particular date range");
            Console.Write("Enter your choice : ");
            int choice =Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    repo.GetAllEmployee();
                    break;
                case 2:
                    repo.AddEmployee();
                    break ;
                case 3:
                    SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel();
                    Salary.UpdateEmployeeSalary(salaryUpdateModel);
                    break;
                case 4:
                    repo.GetEmpJoinedInParticularDateRange();
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break ;
            }
           
        }
    }
}
