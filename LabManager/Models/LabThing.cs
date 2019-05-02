using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabManager.Models
{
    public class LabThing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime CalibratedOn { get; set; }
        public DateTime CalibrationDue { get; set; }
        public DateTime MaintenanceOn { get; set; }
        public DateTime MaintenanceDue { get; set; }
        public string Note { get; set; }

        [NotMapped]
        public Employee Employee { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        [NotMapped]
        public Manufacturer Manufacturer { get; set; }

        public int EmployeeID { get; set; }
        public int CategoryID { get; set; }
        public int ManufacturerID { get; set; }

        //public List<Employee> Employee { get; set; }
        //public List<Category> Category { get; set; }
        //public List<Manufacturer> Manufacturer { get; set; }
    }
}