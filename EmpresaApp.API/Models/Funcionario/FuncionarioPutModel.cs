using System.ComponentModel.DataAnnotations;

namespace EmpresaApp.API.Models.Funcionario
{
    public class FuncionarioPutModel
    {
        [Required(ErrorMessage = "O ID é obirgatório.")]
        public Guid? IdFuncionario { get; set; }

        [MinLength(8, ErrorMessage = "O nome deve ter, no mínimo, {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo do nome é obrigatório")]
        public string? Nome { get; set; }

        [MaxLength(6, ErrorMessage = "A matrícula deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo da matrícula é obrigatório")]
        public string? Matricula { get; set; }

        [MaxLength(11, ErrorMessage = "O CPF deve ter, no máximo, {1} caracteres.")]
        [Required(ErrorMessage = "O campo do CPF é obrigatório")]
        public string? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? IdEmpresa { get; set; }

    }
}
