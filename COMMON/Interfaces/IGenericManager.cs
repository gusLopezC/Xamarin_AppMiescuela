using COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IGenericManager<T> where T : BaseDTO
    {
        T Agregar(T entidad);
        T Modificar(T entidad);
        bool Eliminar(ObjectId id);
        List<T> ListarElementos { get; set; }
        T ObtenerElementoPorId(ObjectId id);
    }
}
