﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Youtube2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Youtube2.Data;

namespace Youtube2.Services.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProfileDBContext RepositoryContext { get; set; }

        public RepositoryBase(ProfileDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public List<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().ToList();
        }

        public T FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).SingleOrDefault();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
