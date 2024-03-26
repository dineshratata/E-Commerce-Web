﻿using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dto.Category
{
    public class BrandDto
    {
       public int Id { get; set; }  

        public string Name { get; set; }

        public string EstabliseYear { get; set; }   


    }
}