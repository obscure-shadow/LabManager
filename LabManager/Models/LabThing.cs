using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabManager.Models
{
    public class LabThing
    {
        public int ID { get; set; }

        [Display(Name = "Lab Item:")]
        public string Name { get; set; }

        [Display(Name = "Serial Number:")]
        public string SerialNo { get; set; }

        [Display(Name = "Model Number:")]
        public string ModelNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Acquisition Date:")]
        public DateTime AcquisitionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Calibrated On:")]
        public DateTime CalibratedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Calibration Due:")]
        public DateTime CalibrationDue { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Maintenance On:")]
        public DateTime MaintenanceOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Maintenance Due:")]
        public DateTime MaintenanceDue { get; set; }
        
        public string Note { get; set; }

        //[NotMapped]
        public Employee Employee { get; set; }
        //[NotMapped]
        public Category Category { get; set; }
        //[NotMapped]
        public Manufacturer Manufacturer { get; set; }

        public string EmployeeId { get; set; }
        public int CategoryID { get; set; }
        public int ManufacturerID { get; set; }
    }
}