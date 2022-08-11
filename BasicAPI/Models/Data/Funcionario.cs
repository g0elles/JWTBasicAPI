using System;
using System.Collections.Generic;

namespace BasicAPI.Models.Data
{
    public partial class Funcionario
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string Pais { get; set; } = null!;
        public string TipoIdentificacion { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public string Area { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
