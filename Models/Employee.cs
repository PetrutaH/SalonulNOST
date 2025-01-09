using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonulNOST.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeID { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
    }
}
