﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Model
{
    public class Product
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string ProductType { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
