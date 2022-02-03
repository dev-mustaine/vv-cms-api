using System;

namespace Via.CMS.DTO
{
    public class ComponentBaseDTO
    {
        public string Id { get; set; }
        /// <summary>
        /// Example c38_c326_c3266_m459
        /// </summary>
        public string Filtro { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public string Bandeira { get; set; }
    }
}
