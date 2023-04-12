using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.Models
{
    public class Material
    {
        public Guid IdMaterial { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }
        public int SoLuongTon { get; set; }
        public int SoLuong { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<MaterialDetail> MaterialDetails { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
