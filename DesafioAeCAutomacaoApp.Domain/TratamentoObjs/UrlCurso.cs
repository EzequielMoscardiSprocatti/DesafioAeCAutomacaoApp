using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.Domain.TratamentoObjs
{
    public class UrlCurso
    {
        public string AddUrl { get; }

        /// <summary>
        /// Função para validar a URL do curso, caso o mesmo venha vázio é efetuado um tratamento e não é add a fila de processos
        /// </summary>
        /// <param name="addurl"></param>
        /// <exception cref="ArgumentException"></exception>
        public UrlCurso(string addurl)
        {
            if (string.IsNullOrEmpty(addurl))
            {
                throw new ArgumentException("URL não pode ser vázia", nameof(addurl));
            }

            
            AddUrl = addurl;
        }
    }
}
