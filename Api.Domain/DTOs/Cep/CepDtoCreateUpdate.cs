using System;
using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Municipio;
using Domain.Entities;

namespace Domain.DTOs.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Id do registro é obrigatório")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Codigo do Cep é obrigatório")]
        [StringLength(10, ErrorMessage = "Codigo do Cep deve ter no máximo {1} caracteres")]
        public string Cep { get; set; }
        
        [Required(ErrorMessage = "Logradouro do Cep é obrigatório")]
        [StringLength(60, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "Número do Cep é obrigatório")]
        [StringLength(10, ErrorMessage = "Número do Cep deve ter no máximo {1} caracteres")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Municipio do Cep é obrigatório")]
        public Guid MunicipioId { get; set; }

        public MunicipioDtoCompleto MunicipioDto { get; set; }
    }
}