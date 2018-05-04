﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtlantTest.Database;
using AtlantTest.Entities;

namespace AtlantTest.Repositories.Implementations
{
    public class DetailRepository : IDetailRepository
    {
        private EFDbContext context = new EFDbContext();

        public void Add(Detail detail)
        {
            context.Details.Add(detail);
        }

        public IQueryable<Detail> GetAll()
        {
            return context.Details.AsQueryable();
        }
    }
}