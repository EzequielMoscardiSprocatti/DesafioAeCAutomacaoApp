using DesafioAeCAutomacaoApp.Domain.Entities;
using DesafioAeCAutomacaoApp.Selenium.BotCursoAlura;
using DesafioAeCAutomacaoApp.Selenium.Settings;
using InfraDadosLocal.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.AppService.BotAlura
{
    public class BotAluraCursos
    {
        private readonly ConsultarCurso _botAlura;
        private readonly WebDriverConfig _driver;
        private readonly CursoResultadoJsonRepository _cursoServico;

        public BotAluraCursos()
        {
            _driver = new WebDriverConfig();
            _botAlura = new ConsultarCurso(_driver.GetWebDriver());
            _cursoServico = new CursoResultadoJsonRepository();
        }

        /// <summary>
        /// Função para consultar os dados de curso no site da Alura, e armazena no banco de dados local.
        /// </summary>
        /// <param name="termopesquisa"></param>
        /// <returns></returns>
        public async Task<bool> ConsultarCursos(string termopesquisa)
        {
            IList<CursoResultado> cursos = new List<CursoResultado>();

            cursos = await _botAlura.CapturarUrlCurso(termopesquisa);

            foreach (var curso in cursos)
            {
                _cursoServico.Add(await _botAlura.DadosCurso(curso));
            }

            return true;
        }

    }
}
