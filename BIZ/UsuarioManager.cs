using COMMON.Entidades;
using COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class UsuarioManager : IUsuariosManager
    {
        IRepository<Usuario> repository;

        public UsuarioManager(IRepository<Usuario> repo)
        {
            repository = repo;
        }
        public List<Usuario> ListarElementos { get => repository.Read; set { } }

        public Usuario Agregar(Usuario entidad)
        {
            return repository.Create(entidad);
        }

        public Usuario CrearCuenta(string usuario, string pass)
        {
            //lambda
            if (repository.Read.Count(e => e.Nombre == usuario) == 0)
            {
                return repository.Create(new Usuario()
                {
                    Nombre = usuario,
                    Password = pass
                });
            }
            else
            {
                return null;
            }
        }

        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public Usuario Login(string usuario, string pass)
        {
            return repository.Read.Where(e => e.Nombre == usuario && e.Password == pass).SingleOrDefault();
        }

        public Usuario Modificar(Usuario entidad)
        {
            return repository.Update(entidad);
        }

        public Usuario ObtenerElementoPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }
    }
}
