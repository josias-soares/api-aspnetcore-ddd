using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}