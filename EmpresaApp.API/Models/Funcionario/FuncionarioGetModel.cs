namespace EmpresaApp.API.Models.Funcionario
{
    public class FuncionarioGetModel
    {
        public Guid? IdFuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? IdEmpresa { get; set; }
    }
}
