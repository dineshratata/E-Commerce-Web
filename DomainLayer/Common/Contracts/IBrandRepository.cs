﻿using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Common.Contracts
{
    public interface IBrandRepository : IGenericRepository<Brand> 
    {
        Task UpdateAsync(Brand brand);

    }
}
