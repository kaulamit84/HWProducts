﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model
{
    public class ProductCategory : BaseEntity
    {        
        [Required]
        public string Category { get; set; }        
    }
}
