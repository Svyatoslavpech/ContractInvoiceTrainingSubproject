using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractInvoice.Model.Entities;
using ContractInvoice.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using ContractInvoice.Model.Contracts;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContractInvoiceDbContext context;

        public GenericRepository(ContractInvoiceDbContext context)
        {
            this.context = context;
        }

        // Добавляет новую запись в контекст

        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        // Добавить список записей

        public void AddRange(IEnumerable<T> entities)
        {
            this.context.Set<T>().AddRange(entities);
        }

        // Находит набор записей, соответствующий переданному выражению.

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression);
        }

        // Получите все записи.

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().ToList();
        }

        // Получить объект по идентификатору.

        public T GetById(long id)
        {
            return this.context.Set<T>().Find(id);
        }

        // Удаляет запись из контекста

        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        // Удаляет список записей.

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.context.Set<T>().RemoveRange(entities);
        }
    }
}