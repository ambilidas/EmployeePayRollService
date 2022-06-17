using System;

namespace EmployeePayRollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Services");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployee();
        }
    }
}
