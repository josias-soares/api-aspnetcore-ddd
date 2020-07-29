using System;
using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Uf;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDtoUpdate
    { 
        [Required(ErrorMessage = "Id do registro é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Nome de município é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Codigo de IBGE inválido")]
        public int CodIBGE { get; set; }
        
        [Required(ErrorMessage = "A UF é obrigatória na alteração")]
        public Guid UfId { get; set; }
    }
}