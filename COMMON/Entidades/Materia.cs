using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Entidades
{
    public class Materia : BaseDTO
    {
        public string Profesor { get; set; }
        public string Horario { get; set; }
        public string Nombre { get; set; }
        public ObjectId IdUsuario { get; set; }

        public override string ToString()
        {
            return Nombre + ": " + Profesor;
        }
    }
}
