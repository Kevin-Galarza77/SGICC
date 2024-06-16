using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Dominio.Modelo.Abstracciones
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(int id);
        void Modify(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Dispose();
    }
}
