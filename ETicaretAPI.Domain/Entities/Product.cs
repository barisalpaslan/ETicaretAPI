﻿using ETicaretAPI.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public int? Stock { get; set; }
        public long? Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
