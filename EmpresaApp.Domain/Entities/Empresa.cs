using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Entities
{
    public class Empresa
    {
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set;}

        #region Relacionamentos

        public List<Funcionario>? Funcionarios { get; set; }

        #endregion
    }
}
