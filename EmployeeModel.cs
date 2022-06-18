using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollService
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long Salary { get; set; } 
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public long EmpPhone { get; set; }
        public string EmpAddress { get; set; }
        public string Department { get; set; }
        public long BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public long NetPay { get; set; }

    }
}
