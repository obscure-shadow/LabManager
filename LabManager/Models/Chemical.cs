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
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Received Date:")]
        public DateTime ReceivedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Opened Date:")]
        public DateTime OpenDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date:")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name="Certificate of Analysis (COA):")]
        public string COA { get; set; }

        [Display(Name = "Opened By:")]
        public string OpenedBy { get; set; }

        public string Note { get; set; }

        //NOTE: Add LOT NUMBER

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