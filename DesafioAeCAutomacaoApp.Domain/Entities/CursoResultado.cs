using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.Domain.Entities
{
    public class CursoResultado
    {
        public Guid Id { get; set; }
        public string? UrlCurso { get; set; }
        public string? Titulo { get; set; }
        public string? Professor { get; set; }
        public string? CargaHora { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataConsulta { get; set; }

        public CursoResultado() { }

        public CursoResultado(string UrlCurso, string Titulo, string Professor, string CargaHora, string Descricao)
        {
            Id = Guid.NewGuid();
            UrlCurso = string.Empty;
            Titulo = string.Empty;
            Professor = string.Empty;
            CargaHora = string.Empty;
            Descricao = string.Empty;

        }
    }
}
