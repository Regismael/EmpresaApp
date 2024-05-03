using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Entities
{
    public class Funcionario
    {
        public Guid? IdFuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set;}
        public string? Cpf { get; set;}
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set;}
        public Guid? IdEmpresa { get; set; }


        #region Relacionamentos

        public Empresa? Empresa { get; set; }

        #endregion
    }
}
