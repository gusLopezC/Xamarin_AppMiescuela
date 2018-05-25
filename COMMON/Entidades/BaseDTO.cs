using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Entidades
{
    public abstract class BaseDTO
    {
        public ObjectId Id { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
