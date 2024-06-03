using DesafioAeCAutomacaoApp.Domain.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.Selenium.BotCursoAlura
{
    public class ConsultarCurso
    {
        private int LimiteUrls;
        public IWebDriver driver { get; set; }
        public ConsultarCurso(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Busca URL's e armazena numa lista.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="termocurso"></param>
        /// <returns></returns>
        public async Task<IList<UrlCursos>> UrlCursos(string termocurso)
        {
            IList<UrlCursos> urlCursos = new List<UrlCursos>();
            UrlCursos curso = null;
            bool proxPg = false;           

            IWebElement cpCampoBusca = null, Paginacao = null;
            string urlprincipal = "";
            await AcessarUrl("https://www.alura.com.br/");

            try
            {
                cpCampoBusca = driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));
                cpCampoBusca.SendKeys(termocurso);
                cpCampoBusca.Submit();
                PageLoadDirver();

                urlprincipal = driver.Url+ "&typeFilters=COURSE";
                await AcessarUrl(urlprincipal);
            }
            catch (Exception)
            {

            }

            try
            {
                while (proxPg)
                {

                    Paginacao = driver.FindElement(By.ClassName("paginacao-pagina"));
                    IList<IWebElement> li = Paginacao.FindElements(By.TagName("li"));

                    foreach (IWebElement element in li)
                    {
                        UrlCursos url = new UrlCursos
                        {
                            URlCursos = element.FindElement(By.TagName("a")).GetAttribute("href")
                        };

                        urlCursos.Add(url);
                    }

                    IWebElement btnprox = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/nav/a[2]"));
                    string disabledAttribute = btnprox.GetAttribute("disabled");

                    if (disabledAttribute != null && disabledAttribute.Equals("disabled"))
                    {
                        proxPg = false;
                    }
                    else
                    {
                        proxPg = true;
                        btnprox.Click();
                    }


                } 

            }
            catch (Exception)
            {

            }


            return urlCursos;
        }

        /// <summary>
        /// Efetua a busca das URL's dos cursos, e armazena numa lista para processar posteriormente.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="termocurso"></param>
        /// <returns></returns>
        public async Task<IList<CursoResultado>> CapturarUrlCurso(string termocurso)
        {
            IList<CursoResultado> cursosLista = new List<CursoResultado>();
            UrlCursos curso = null;
            bool proxPg = true;
            IWebElement cpCampoBusca = null, Paginacao = null;
            string urlprincipal = "";
            await AcessarUrl("https://www.alura.com.br/");

            LimiteUrls = 0;

            try
            {
                cpCampoBusca = driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));
                cpCampoBusca.SendKeys(termocurso);
                cpCampoBusca.Submit();
                PageLoadDirver();

                //urlprincipal = driver.Url + "&typeFilters=COURSE";
                //await AcessarUrl(driver, urlprincipal);

            }
            catch (Exception)
            {

            }

            try
            {
                while (proxPg)
                {
                    

                    Paginacao = driver.FindElement(By.ClassName("paginacao-pagina"));
                    IList<IWebElement> li = Paginacao.FindElements(By.TagName("li"));

                    foreach (IWebElement element in li)
                    {
                        CursoResultado cursos = new CursoResultado
                        {
                            UrlCurso = element.FindElement(By.TagName("a")).GetAttribute("href"),
                            Titulo = element.FindElement(By.ClassName("busca-resultado-nome")).Text,
                            Descricao = element.FindElement(By.ClassName("busca-resultado-descricao")).Text,
                        };

                        cursosLista.Add(cursos);
                    }

                    IWebElement btnprox = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/nav/a[2]"));
                    string disabledAttribute = btnprox.GetAttribute("disabled");

                    if (disabledAttribute != null && disabledAttribute.Equals("disabled"))
                    {
                        proxPg = false;
                    }
                    else
                    {
                        proxPg = true;
                        btnprox.Click();
                    }

                    ///Adicionado Limite para uso interno
                    LimiteUrls++;
                    if(LimiteUrls == 2)
                    {
                        proxPg = false;
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return cursosLista;
        }

        /// <summary>
        /// Efetua a busca de curso através de URL's, após a consulta o mesmo salva as informações no banco de dados.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="curso"></param>
        /// <returns></returns>
        public async Task<CursoResultado> DadosCurso(CursoResultado curso)
        {
            await AcessarUrl(curso.UrlCurso);

            string urlsite = driver.Url;

            IList<IWebElement> prof = null;
            IList<IWebElement> CgHr = null;

            if(urlsite.Contains("loginForm"))
            {
                curso.Professor = "Sem dados do Professor";
                curso.CargaHora = "Sem dados da Carga Horária do Curso";
                return curso;
            }

            if(urlsite.Contains("alura.com.br/artigos/"))
            {
                try
                {
                    prof = driver.FindElements(By.ClassName("cosmos-author-name"));                    

                    foreach (var el in prof)
                    {
                        curso.Professor += el.Text + ", ";
                    }

                    curso.CargaHora = "Sem dados da Carga Horária do Curso";

                    return curso;
                }
                catch (Exception ex)
                {
                    curso.Professor = "Erro ao pegar os dados do Professor";
                    curso.CargaHora = "Erro ao pegar os dados da Carga Horária do Curso";
                    return curso;
                }
            }


            if (urlsite.Contains("alura.com.br/podcast/"))
            {
                try
                {
                    prof = driver.FindElements(By.XPath("/html/body/main/section[1]/div/ul[1]/li[1]"));

                    foreach (var el in prof)
                    {
                        curso.Professor += el.Text + ", ";
                    }

                    curso.CargaHora = "Sem dados da Carga Horária do Curso";

                    return curso;
                }
                catch (Exception ex)
                {
                    try
                    {
                        IWebElement professores = driver.FindElement(By.XPath("/html/body/main/section[1]/div/ul[1]"));

                        curso.Professor = professores.Text;
                        curso.CargaHora = "Sem dados da Carga Horária do Curso";

                        return curso;
                    }
                    catch (Exception e)
                    {
                        curso.Professor = "Erro ao tentar localizar o professor";
                        curso.CargaHora = "Sem dados da Carga Horária do Curso";
                        return curso;
                    }
                   
                }
            }

            if (curso.UrlCurso.Contains("curso"))
            {
                try
                {
                    prof = driver.FindElements(By.ClassName("instructor-title--name"));
                    CgHr = driver.FindElements(By.ClassName("couse-container--spacing"));

                    foreach (var el in prof)
                    {
                        curso.Professor += el.Text + ", ";
                    }

                    foreach (var el in CgHr)
                    {
                        if (el.Text.Contains("h Para conclusão") || el.Text.Contains("h"))
                        {
                            curso.CargaHora += el.Text.Replace("\r\n", " ") + ". ";
                        }
                    }

                    return curso;
                }
                catch (Exception ex)
                {
                    curso.Professor = "Erro ao pegar os dados do Professor";
                    curso.CargaHora = "Erro ao pegar os dados da Carga Horária do Curso";
                    return curso;
                }

            }

            if(curso.UrlCurso.Contains("formacao"))
            {
                try
                {
                    prof = driver.FindElements(By.ClassName("formacao-instrutor-nome"));
                    CgHr = driver.FindElements(By.ClassName("formacao__info-conclusao"));

                    foreach(var el in prof)
                    {
                        curso.Professor += el.Text + ", ";
                    }

                    foreach (var el in CgHr)
                    {
                        curso.CargaHora += el.Text.Replace("\r\n"," ") + ". ";
                    }

                    return curso;
                }
                catch (Exception ex)
                {
                    curso.Professor = "Erro ao pegar os dados do Professor";
                    curso.CargaHora = "Erro ao pegar os dados da Carga Horária do Curso";
                    return curso;
                }

            }

            return curso;
        }
                
        /// <summary>
        /// Função para acessar o site e aguarda a página carregar por completo.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task AcessarUrl(string url)
        {          
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            System.Threading.Thread.Sleep(2000);
            PageLoadDirver();
        }

        /// <summary>
        /// Aguarde a página carregar por completo
        /// </summary>
        /// <param name="driver"></param>
        private void PageLoadDirver()
        {
            int timeoutInSeconds = 10;

            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv =>
                {
                    try
                    {
                        return ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").ToString() == "complete";
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
        }
    }
}
