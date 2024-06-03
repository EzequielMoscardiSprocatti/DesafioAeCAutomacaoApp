using DesafioAeCAutomacaoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAeCAutomacaoApp.Domain.Interfaces
{
    /// <summary>
    /// Define um contrato para um repositório que gerencia objetos do tipo CursoResultado. 
    /// </summary>
    public interface ICursoResultadoRepository
    {
        void Add(CursoResultado resultado);
        CursoResultado Get(Guid id);
        IEnumerable<CursoResultado> GetAll();
    }
}
