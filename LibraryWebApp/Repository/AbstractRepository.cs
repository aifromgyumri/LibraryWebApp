﻿using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Repository
{
    public abstract class AbstractRepository<T> where T : class
    {
        protected readonly LibraryDbContext _dbContext;

        public AbstractRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Add(T model)
        {
            var entity = _dbContext.Add(model).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Edit(T model)
        {
            var entity = _dbContext.Update(model).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Delete(T model)
        {
            var entity = _dbContext.Remove(model).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(long id);
    }
}