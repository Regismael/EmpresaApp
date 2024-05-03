using System.ComponentModel.DataAnnotations;

namespace EmpresaApp.API.Models.Empresa
{
    public class EmpresaPostModel
    {
        [MinLength(8, ErrorMessage = "O nome deve ter, no mínimo, {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo do nome é obrigatório")]
        public string? NomeFantasia { get; set; }

        [MinLength(8, ErrorMessage = "A razão social deve ter, no mínimo, {1} caracteres")]
        [MaxLength(100, ErrorMessage = "A razãao social deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo da razão social é obrigatório")]
        public string? RazaoSocial { get; set; }

        [MaxLength(14, ErrorMessage = "O CNPJ deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo do CNPJ é obrigatório")]
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
