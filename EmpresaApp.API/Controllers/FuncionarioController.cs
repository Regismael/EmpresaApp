using EmpresaApp.API.Models.Funcionario;
using EmpresaApp.Domain.Entities;
using EmpresaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioDomainService _funcionarioDomainService;

        public FuncionarioController(IFuncionarioDomainService funcionarioDomainService, IEmpresaDomainService empresaDomainService)
        {
            _funcionarioDomainService = funcionarioDomainService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioPostModel model)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    IdFuncionario = Guid.NewGuid(),
                    DataHoraCadastro = DateTime.Now,
                    Nome = model.Nome,
                    Matricula = model.Matricula,
                    Cpf = model.Cpf,
                    DataAdmissao = model.DataAdmissao,
                    IdEmpresa = model.IdEmpresa,

                };

                _funcionarioDomainService.CadastrarFuncionario(funcionario);

                return StatusCode(201, new
                {
                    Message = "Funcionário cadastrado com sucesso", funcionario
                });
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

        [HttpPut]
        public IActionResult Put(FuncionarioPutModel model)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    IdFuncionario = model.IdFuncionario,
                    DataHoraCadastro= DateTime.Now,
                    Nome = model.Nome,
                    Matricula = model.Matricula,
                    Cpf = model.Cpf,
                    DataAdmissao= model.DataAdmissao,
                    IdEmpresa = model.IdEmpresa
                    
                };

                _funcionarioDomainService.AtualizarFuncionario(funcionario);

                return StatusCode(200, new
                {
                    Message = "Funcionário atualizado com sucesso!", funcionario
                });
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var funcionario = _funcionarioDomainService.ObterPorId(id);

                _funcionarioDomainService.RemoverFuncionario(id);

                return StatusCode(200, new
                {
                    Message = "Funcionário excluído com sucesso!", funcionario
                });
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var funcionarios = _funcionarioDomainService.ConsultarFuncionarios();

                return StatusCode(200, funcionarios);
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
        public IActionResult GetById(Guid id)
        {
            try
            {
                var funcionario = _funcionarioDomainService.ObterPorId(id);

                return StatusCode(200, funcionario);
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
