﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T GetById(string id);

        string Update(T updatedEntity);        
    }
}
