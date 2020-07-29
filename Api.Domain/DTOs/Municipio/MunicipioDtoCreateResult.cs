using System;
using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Uf;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}