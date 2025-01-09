using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SalonulNOST.Models
{
    public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
