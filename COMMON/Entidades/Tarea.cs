using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Entidades
{
    public class Tarea : BaseDTO
    {
        //TODO: Cadena de conexión: mongodb://<dbuser>:<dbpassword>@ds261678.mlab.com:61678/profecarlosmiescuela
        public string Titulo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Entregada { get; set; }
        public string Descripcion { get; set; }
        public ObjectId IdMateria { get; set; }
    }
}
