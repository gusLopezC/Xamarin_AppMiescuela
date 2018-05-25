using COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Interfaces
{
    public interface IUsuariosManager : IGenericManager<Usuario>
    {
        Usuario Login(string usuario, string pass);
        Usuario CrearCuenta(string usuario, string pass);
    }
}
