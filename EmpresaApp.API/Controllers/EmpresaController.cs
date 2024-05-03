using EmpresaApp.API.Models.Empresa;
using EmpresaApp.Domain.Entities;
using EmpresaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaDomainService _empresaDomainService;

        public EmpresaController(IEmpresaDomainService empresaDomainService)
        {
            _empresaDomainService = empresaDomainService;
        }

        [HttpPost]
        public IActionResult Post(EmpresaPostModel model)
        {
            try
            {
                var empresa = new Empresa
                {
                    IdEmpresa = Guid.NewGuid(),
                    NomeFantasia = model.NomeFantasia,
                    RazaoSocial = model.RazaoSocial,
                    Cnpj = model.Cnpj,
                    DataHoraCadastro = DateTime.Now
                };

                _empresaDomainService.CadastrarEmpresa(empresa);

                return StatusCode(201, new
                {
                    Message = "Empresa cadastrada com sucesso!", empresa
                });
            }
            catch(ApplicationException e)
            {
                return StatusCode(400, new
                {
                    e.Message
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutModel model)
        {
            try
            {
                var verificacaoId = _empresaDomainService.ObterPorId(model.IdEmpresa.Value);

                if (verificacaoId != null)
                {


                    var empresa = new Empresa
                    {
                        IdEmpresa = model.IdEmpresa,
                        NomeFantasia = model.NomeFantasia,
                        RazaoSocial = model.RazaoSocial,
                        Cnpj = model.Cnpj,
                        DataHoraCadastro = verificacaoId.DataHoraCadastro
                    };

                    _empresaDomainService.AtualizarEmpresa(empresa);


                    return StatusCode(201, new
                    {
                        Message = "Empresa atualizada com sucesso!",
                        empresa.DataHoraCadastro,
                        empresa
                    });
                }
                else
                {
                    return StatusCode (401, new
                    {
                        Message = "ID não encontrado, verifique-o"
                    });
                }

            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    e.Message
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var empresa = _empresaDomainService.ObterPorId(id);

                _empresaDomainService.RemoverEmpresa(id);

                return StatusCode(200, new
                {
                    Message = "Empresa excluída com sucesso!",
                    empresa

                });
            }
            catch(ApplicationException e)
            {
                return StatusCode(400, new
                {
                    e.Message
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var empresas = _empresaDomainService.ConsultarEmpresas();

                return StatusCode(200, empresas);
            }

            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var empresa = _empresaDomainService.ObterPorId(id);

                return StatusCode(200, empresa);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
