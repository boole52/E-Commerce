﻿using Etities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product{get; set;}
        public List<Category> Categories { get; set; }
    }
}
