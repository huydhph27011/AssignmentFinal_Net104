using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.Models
{
    public class Position
    {

        public Guid IdPosition { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
