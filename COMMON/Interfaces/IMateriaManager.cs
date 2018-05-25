using COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IMateriaManager : IGenericManager<Materia>
    {
        List<Materia> BuscarMateriasDeUsuario(ObjectId idUsuario);
    }
}
