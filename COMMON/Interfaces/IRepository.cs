using COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IRepository<T> where T : BaseDTO
    {
        T Create(T entidad);
        List<T> Read { get; }
        T Update(T entidad);
        bool Delete(ObjectId id);
        T SearchById(ObjectId id);
    }
}
