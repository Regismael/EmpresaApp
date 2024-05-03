using EmpresaApp.Domain.Entities;
using EmpresaApp.Domain.Interfaces.Repositories;
using EmpresaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Domain.Services
{
    public class EmpresaDomainService : IEmpresaDomainService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaDomainService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public void AtualizarEmpresa(Empresa empresa)
        {
            if (_empresaRepository.GetById(empresa.IdEmpresa.Value) == null)
                throw new ApplicationException("ID inexistente. Por favor, digite novamente.");

            _empresaRepository.Update(empresa);

        }

        public void CadastrarEmpresa(Empresa empresa)
        {
            if (_empresaRepository.GetRazaoSocial(empresa.RazaoSocial) != null)
                throw new ApplicationException("Razão social ja existente. Por favor, informe outra.");

            if (_empresaRepository.GetCnpj(empresa.Cnpj) != null)
                throw new ApplicationException("CNPJ ja existente. Por favor, informe outro.");

            _empresaRepository.Add(empresa);
        }

        public List<Empresa> ConsultarEmpresas()
        {
            return _empresaRepository.GetAll();
        }

        public Empresa ObterPorId(Guid id)
        {

            var empresa = _empresaRepository.GetById(id);

            if (empresa == null)
                throw new ApplicationException("ID inexistente. Por favor, digite novamente");

            return _empresaRepository.GetById(id);
        }

        public void RemoverEmpresa(Guid id)
        {
            var empresa = _empresaRepository.GetById(id);

            if(empresa == null)
                throw new ApplicationException("ID inexistente. Por favor, digite novamente");

            _empresaRepository.Delete(empresa);

        }
    }
}
