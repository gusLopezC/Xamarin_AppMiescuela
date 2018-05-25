
using COMMON.Entidades;
using COMMON.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenericRepository<T> : IRepository<T> where T : BaseDTO
    {
        private MongoClient client;
        private IMongoDatabase db;
        public GenericRepository()
        {
            client = new MongoClient(new MongoUrl(@"mongodb://gustavo:kirito12@ds012578.mlab.com:12578/gustavomiescuela"));
            db = client.GetDatabase("gustavomiescuela");
        }


        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Read => Collection().AsQueryable<T>().ToList();

        public T Create(T entidad)
        {
            entidad.Id = ObjectId.GenerateNewId();
            entidad.FechaHora = DateTime.Now;
            try
            {
                Collection().InsertOne(entidad);
                return entidad;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(global::MongoDB.Bson.ObjectId id)
        {
            try
            {
                return Collection().DeleteOne(m => m.Id == id).DeletedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T SearchById(global::MongoDB.Bson.ObjectId id)
        {
            try
            {
                return Collection().Find(e => e.Id == id).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T Update(T entidad)
        {
            try
            {
                entidad.FechaHora = DateTime.Now;
                return Collection().ReplaceOne(e => e.Id == entidad.Id, entidad).ModifiedCount == 1 ? entidad : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
