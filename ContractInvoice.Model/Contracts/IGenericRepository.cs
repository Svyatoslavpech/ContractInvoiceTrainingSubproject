using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContractInvoice.Model.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        // Получить объект по идентификатору.
        T GetById(long id);

        // Получите все записи.
        IEnumerable<T> GetAll();

        // Находит набор записей, соответствующий переданному выражению.
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        // Добавляет новую запись в контекст
        void Add(T entity);

        // Добавить список записей
        void AddRange(IEnumerable<T> entities);

        // Удаляет запись из контекста
        void Remove(T entity);

        // Удаляет список записей.
        void RemoveRange(IEnumerable<T> entities);

    }
}