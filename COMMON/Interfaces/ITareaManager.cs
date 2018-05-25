using COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface ITareaManager : IGenericManager<Tarea>
    {
        List<Tarea> BuscarTareasDeMateria(ObjectId idMateria);

    }
}
