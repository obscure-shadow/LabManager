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
        // Please see the Chemical.cs model for an explanation of the constructor below and updates to the DateTime properties in this model.

        //public LabThing()
        //{
        //    AcquisitionDate = DateTime.Now;
        //    CalibratedOn = DateTime.Now;
        //    CalibrationDue = DateTime.Now;
        //    MaintenanceOn = DateTime.Now;
        //    MaintenanceDue = DateTime.Now;
        //}


        //----------------------------------------------------------------------------------------------------------
        // Properties:

        public int ID { get; set; }

        [Display(Name = "Lab Item:")]
        public string Name { get; set; }

        [Display(Name = "Serial Number:")]
        public string SerialNo { get; set; }

        [Display(Name = "Model Number:")]
        public string ModelNo { get; set; }

        // Acquisition
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Acquisition Date:")]
        public DateTime AcquisitionDate { get; set; }

        // Calibration
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Calibrated On:")]
        public DateTime CalibratedOn { get; set; }

        // CalibrationDue
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Calibration Due:")]
        public DateTime CalibrationDue { get; set; }

        // Maintenance
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Maintenance On:")]
        public DateTime MaintenanceOn { get; set; }

        // MaintenanceDue
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