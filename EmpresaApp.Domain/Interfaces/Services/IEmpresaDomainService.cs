using EmpresaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Interfaces.Services
{
    public interface IEmpresaDomainService
    {
        void CadastrarEmpresa(Empresa empresa);
        void AtualizarEmpresa(Empresa empresa);
        void RemoverEmpresa(Guid id);
        List<Empresa> ConsultarEmpresas();
        Empresa ObterPorId(Guid id);
    }
}
