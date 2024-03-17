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
    [PrimaryKey(nameof(RentedCarId))]
    public class RentedCarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentedCarId { get; set; }

        public string RentedCarMake { get; set; }
        public string RentedCar_Model { get; set; }
        public string RentedCarType { get; set; }
        public string RentedCarColor { get; set; }
        public string RentedCarGearboxType { get; set; }
        public float RentedCost { get; set; }
        public DateTime RentedDate { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }
        public int LoanPeriod { get; set; }

    }
}
