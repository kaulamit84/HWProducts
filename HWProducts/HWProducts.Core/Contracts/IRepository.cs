﻿using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();

        void Commit();

        void Delete(string Id);

        T Find(string Id);

        void Insert(T t);

        void Update(T t);
    }
}
