﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IRepository<T> where T:class
    {
        IEnumerable<T> GetALL();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}