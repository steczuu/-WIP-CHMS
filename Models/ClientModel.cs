using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHMS.Models
{
    [PrimaryKey(nameof(Name))]
    public class ClientModel
    {
        public string Name { get; set; }    
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int LoanPeriod { get; set; }
    }
}
