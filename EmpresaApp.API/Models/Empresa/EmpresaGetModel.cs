using EmpresaApp.Domain.Entities;

namespace EmpresaApp.API.Models.Empresa
{
    public class EmpresaGetModel
    {
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }


    }
}
