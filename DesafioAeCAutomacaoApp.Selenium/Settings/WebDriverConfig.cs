using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.Selenium.Settings
{
    public class WebDriverConfig
    {
        private IWebDriver _driver;
        
        //Caso não exista uma pasta com o chromedriver, será usado o chromeDriver do Nuget
        private string _path = "C:\\Driver\\chromiun\\chromedriver.exe";

        /// <summary>
        /// Retorna o driver configurado para consulta.
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetWebDriver()
        {

            if (_driver == null)
            {
                if (Directory.Exists(_path))
                {
                    _driver = new ChromeDriver(_path, OptionsChrome());
                }
                else
                {
                    _driver = new ChromeDriver(OptionsChrome());
                }
            }

            return _driver;
        }

        /// <summary>
        /// Efetua preparação do chrome com adição de argumentos e profile, dessa forma faz parecer que a sessão atual pareça autentica.
        /// </summary>
        /// <returns></returns>
        private ChromeOptions OptionsChrome()
        {

            ChromeOptions options = new ChromeOptions();
            
            //Configurações adicionais para se comportar como um navegador padrão
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--start-maximized"); // Iniciar maximizado
            options.AddArgument("--disable-extensions"); // Desativar extensões
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1); // Permitir notificações
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            return options;
        }
    }
}
