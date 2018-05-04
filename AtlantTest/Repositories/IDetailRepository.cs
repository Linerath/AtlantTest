﻿using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlantTest.Repositories
{
    public interface IDetailRepository
    {
        IQueryable<Detail> GetAll();
        void Add(Detail detail);
    }
}