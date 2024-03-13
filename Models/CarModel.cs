using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CHMS.Models
{
    [PrimaryKey(nameof(CarMake))]   
    public class CarModel
    {
        public string CarMake { get; set; } 
        public string Car_Model {  get; set; }   
        public string CarType {  get; set; }    
        public string CarColor { get; set; }
        public string CarGearboxType { get; set; }  
        public float Cost {  get; set; }    
    }
}
