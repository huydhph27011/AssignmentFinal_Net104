using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.Models
{
    public class BillDetail
    {
        public Guid IdMDetail { get; set; }
        public Guid IdBill { get; set; }

        public Guid IdMaterial { get; set; }

        public string MaterialName { get; set; }

        public int Amount { get; set; }
        public Decimal Price { get; set; }
        public virtual Material Material { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
