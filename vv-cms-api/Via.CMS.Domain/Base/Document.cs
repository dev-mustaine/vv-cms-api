
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Via.CMS.Domain.Base
{
    [BsonNoId]
    public abstract class Document 
    {
        [BsonElement("_id")]
        public ObjectId _Id { get; set; }
        public string Filtro { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public string Bandeira { get; set; }
    }
}
