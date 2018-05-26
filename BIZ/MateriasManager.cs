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
    public class MateriasManager : IMateriaManager
    {
        IRepository<Materia> repository;
        public MateriasManager(IRepository<Materia> repo)
        {
            repository = repo;
        }
        public List<Materia> ListarElementos { get => repository.Read; set { } }


        public Materia Agregar(Materia entidad)
        {
            return repository.Create(entidad);
        }

        public List<Materia> BuscarMateriasDeUsuario(ObjectId idUsuario)
        {
            return repository.Read.Where(e => e.IdUsuario == idUsuario).ToList();
        }

        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public Materia Modificar(Materia entidad)
        {
            return repository.Update(entidad);
        }

        public Materia ObtenerElementoPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }
    }
}
