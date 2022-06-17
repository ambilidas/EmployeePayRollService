using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeePayRollService
{
    public class EmployeeRepo
    {
        public static string connectionString = "data source=LIANO; database=Payroll_Service; integrated security=true";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select empId,empName,salary,startDate,gender,empPhone,empAddress,department,basicPay,deductions,taxablePay,incomeTax,netPay FROM employee_payroll";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    //check if there are records
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeId = reader.GetInt32(0);
                            model.EmployeeName = reader.GetString(1);
                            model.Salary = reader.GetInt64(2);
                            model.StartDate = reader.GetDateTime(3);
                            model.Gender = reader.GetString(4);
                            model.EmpPhone = reader.GetString(5);
                            model.EmpAddress = reader.GetString(6);
                            model.Department = reader.GetString(7);
                            model.BasicPay = reader.GetInt64(8);
                            model.Deductions = reader.GetInt64(9);
                            model.TaxablePay= reader.GetInt64(10);
                            model.IncomeTax= reader.GetInt64(11);
                            model.NetPay = reader.GetInt64(12);

                            //display retrived records
                            Console.WriteLine("{0},{1},{2},{3},{4}",model.EmployeeId,model.EmployeeName,model.Salary,model.Department);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
