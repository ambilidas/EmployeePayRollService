using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeePayRollService
{
    public class Salary
    {
        private static SqlConnection ConnectionSetUp()
        {
            return new SqlConnection("data source=LIANO; database=Payroll_Service; integrated security=true");
        }
        public static long UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetUp();
            long salary = 0;

            try
            {
                using (SalaryConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    //SalaryUpdateModel salaryUpdateModelobj= new SalaryUpdateModel();
                    SalaryUpdateModel UpdateModel = new SalaryUpdateModel();
                    UpdateModel.EmployeeId = 6;
                    UpdateModel.Salary = 60000;
                    UpdateModel.EmployeeName = "Terissa";
                  
                    //Define sql command object
                    SqlCommand cmd = new SqlCommand("spUpdateEmployeeSalary",SalaryConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", UpdateModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeName", UpdateModel.Salary);

                    SalaryConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    //check if there are recors
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            displayModel.EmployeeName = reader["empName"].ToString();
                            displayModel.Salary = Convert.ToInt64(reader["salary"]);

                            //display retrieved records
                            Console.WriteLine("{0},{1}",displayModel.EmployeeName,displayModel.Salary);
                            Console.WriteLine("\n");
                            salary = displayModel.Salary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return salary;
        }
    }
}
