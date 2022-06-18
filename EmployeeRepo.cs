using System;
using System.Collections.Generic;
using System.Data;
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
                    string query = @"select * FROM employee_payroll";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    //check if there are records
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Employee Records");
                        Console.WriteLine("--------------------------------");
                        while (reader.Read())
                        {
                            model.EmployeeId = reader.GetInt32(0);
                            model.EmployeeName = reader.GetString(1);
                            model.Salary = reader.GetInt64(2);
                            model.StartDate = reader.GetDateTime(3);
                            model.Gender = reader.GetString(4);
                            model.EmpPhone = reader.GetInt64(5);
                            model.EmpAddress = reader.GetString(6);
                            model.Department = reader.GetString(7);
                            model.BasicPay = reader.GetInt64(8);
                            model.Deductions = reader.GetDouble(9);
                            model.TaxablePay= reader.GetDouble(10);
                            model.IncomeTax= reader.GetDouble(11);
                            model.NetPay = reader.GetInt64(12);

                            //display retrived records
                            
                            Console.WriteLine("{0},{1},{2}",model.EmployeeName,model.Salary,model.Department);
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
        //Adding data to the database
        public bool AddEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Raju";
            model.Salary = 30000;
            model.Department = "Marketing";
            model.Gender = "M";
            model.EmpPhone = 94455623;
            model.StartDate = Convert.ToDateTime("2022-12-26");
            model.BasicPay = 40000;
            model.Deductions = 500;
            model.TaxablePay = 1000;
            model.IncomeTax = 1000;
            model.NetPay = 45000;
            model.EmpAddress = "Chennai";

            try
            {
                using (connection)
                {
                    SqlCommand sqlcmd = new SqlCommand("SPAddEmployeeDetails", connection);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    sqlcmd.Parameters.AddWithValue("@Salary", model.Salary);
                    sqlcmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                    sqlcmd.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlcmd.Parameters.AddWithValue("@EmpPhone", model.EmpPhone);
                    sqlcmd.Parameters.AddWithValue("@EmpAddress", model.EmpAddress);
                    sqlcmd.Parameters.AddWithValue("@Department", model.Department);
                    sqlcmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    sqlcmd.Parameters.AddWithValue("@Deductions", model.Deductions);
                    sqlcmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    sqlcmd.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    sqlcmd.Parameters.AddWithValue("@NetPay", model.NetPay);

                    connection.Open();
                    var result=sqlcmd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        Console.WriteLine("Data has been added");
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
