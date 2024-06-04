using DesafioAeCAutomacaoApp.Domain.Entities;
using DesafioAeCAutomacaoApp.Selenium.BotCursoAlura;
using DesafioAeCAutomacaoApp.Selenium.Settings;
using InfraDadosLocal.Data.Repositories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.AppService.Servicos
{
    public class CursoAluraServicos
    {
        private readonly CursoResultadoJsonRepository _cursoServico;

        public CursoAluraServicos()
        {
            _cursoServico = new CursoResultadoJsonRepository(); 
        }

        /// <summary>
        /// Salva o curso no banco de dados.
        /// </summary>
        /// <param name="curso"></param>
        public void SalvarCurso(CursoResultado curso)
        {
            _cursoServico.Add(curso);
        }

        /// <summary>
        /// Delete todos os cursos do banco.
        /// </summary>
        public void DeletarDados()
        {
            _cursoServico.DeleteAll();
        }

        /// <summary>
        /// Retorna todos os cursos cadastrados no banco de dados.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CursoResultado> ObterTodosCursos()
        {
            return _cursoServico.GetAll();
        }

        /// <summary>
        /// Consultar um curso pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CursoResultado ObterCursoPorId(Guid id)
        {
            return _cursoServico.Get(id);
        }

 
    }
}
