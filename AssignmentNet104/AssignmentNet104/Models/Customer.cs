using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.Models
{
    public class Customer
    {

        public Guid IdCustomer { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }

        public DateTime BirthOfDate { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
