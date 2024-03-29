﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMotorsProject.Repository.Context;
using WebMotorsProject.Repository.Entity;
using WebMotorsProject.Repository.Generic.Interface;

namespace WebMotorsProject.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly ContextDB Context;
        private DbSet<T> dataset;

        public GenericRepository(ContextDB context)
        {
            Context = context;
            dataset = Context.Set<T>();
        }

        public T Create(T entity)
        {
            dataset.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = dataset.SingleOrDefault(d => d.Id.Equals(id));
            if (entity != null)
            {
                dataset.Remove(entity);
                Context.SaveChanges();
            }

        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T entity)
        {
            if (!dataset.Any(b => b.Id.Equals(entity.Id))) return null;

            var result = dataset.SingleOrDefault(b => b.Id == entity.Id);
            if (result != null)
            {
                Context.Entry(result).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
            return result;
        }
    }
}
