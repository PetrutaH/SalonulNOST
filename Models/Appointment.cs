using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonulNOST.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime AppointmentDate { get; set; }

        [Ignore]
        public string ServiceName { get; set; }
    }
}
