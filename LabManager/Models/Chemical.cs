using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabManager.Models
{
    public class Chemical
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string COA { get; set; }
        public string OpenedBy { get; set; }
        public string Note { get; set; }

        public int EmployeeID { get; set; }
        public int ManufacturerID {get; set;}
        public int ChemicalTypeID { get; set; }
        
        //public Employee Employee { get; set; }
        //public List<Employee> Employee { get; set; }
        //public List<Manufacturer> Manufacturer { get; set; }
        //public List<ChemicalType> ChemicalType { get; set; }




    }
}