﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public  class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreateOn { get; set; } = DateTime.UtcNow;




    }
}
