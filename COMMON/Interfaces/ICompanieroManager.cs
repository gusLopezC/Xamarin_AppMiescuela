using COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface ICompanieroManager : IGenericManager<Companiero>
    {
        List<Companiero> CompanierosDeUsuario(ObjectId idUsuario);
    }
}
