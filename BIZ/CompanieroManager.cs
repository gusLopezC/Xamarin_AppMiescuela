using COMMON.Entidades;
using COMMON.Interfaces;
using DAL;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class CompanieroManager : ICompanieroManager
    {
        private GenericRepository<Companiero> genericRepository;

        public CompanieroManager(GenericRepository<Companiero> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        //--------------------------------------------------------------------------------------------------------


        public List<Companiero> ListarElementos { get => genericRepository.Read; set { } }

        public Companiero Agregar(Companiero entidad)
        {
            return genericRepository.Create(entidad);
        }

        public List<Companiero> CompanierosDeUsuario(ObjectId idUsuario)
        {
            return genericRepository.Read.Where(p => p.IdUsuario == idUsuario).ToList();
        }

        public bool Eliminar(ObjectId id)
        {
            return genericRepository.Delete(id);
        }

        public Companiero Modificar(Companiero entidad)
        {
            return genericRepository.Update(entidad);
        }

        public Companiero ObtenerElementoPorId(ObjectId id)
        {
            return genericRepository.SearchById(id);
        }
    }
}
