using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabManager.Models
{
    public class Chemical
    {

        //----------------------------------------------------------------------------------------------------------
        // Properties:

        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Received Date:")]
        public DateTime ReceivedDate { get; set; }
        //public DateTime ReceivedDate { get; set; } = DateTime.Now;

        // Not required
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Opened Date (If unopened, leave blank):")]
        public DateTime? OpenDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date:")]
        public DateTime ExpirationDate { get; set; }

        // This should be a required field 
        [Display(Name="Certificate of Analysis (COA):")]
        public string COA { get; set; }

        // Not required until something exists in the Opened Date field but currently there is no system in place to check one agaist the other. 
        [Display(Name = "Opened By (If unopened, leave blank):")]
        public string OpenedBy { get; set; }

        public string Note { get; set; }

        //NOTE: Feature: Add LOT NUMBER

        //[NotMapped]
        public Employee Employee { get; set; }
        //[NotMapped]
        public Manufacturer Manufacturer { get; set; }
        //[NotMapped]
        public ChemicalType ChemicalType { get; set; }

        public string EmployeeId { get; set; }
        public int ManufacturerID {get; set;}
        public int ChemicalTypeID { get; set; }
        




    }
}