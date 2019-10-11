using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model
{
    public class Product : BaseEntity
    {      

        [StringLength(20)]
        [DisplayName("Product Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0,1000)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
        public string Image { get; set; }       

    }
}
