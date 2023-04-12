using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.Models
{
    public class Store
    {
        public Guid IdStore { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Nation { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
