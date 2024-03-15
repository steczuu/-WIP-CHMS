using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CHMS.Models
{
    [PrimaryKey(nameof(CarId))]
    public class RentedCarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        public string CarMake { get; set; }
        public string Car_Model { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public string CarGearboxType { get; set; }
        public float Cost { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int LoanPeriod { get; set; }

    }
}
