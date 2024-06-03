using DesafioAeCAutomacaoApp.Domain.Entities;
using DesafioAeCAutomacaoApp.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDadosLocal.Data.Repositories
{
    public class CursoResultadoJsonRepository : ICursoResultadoRepository
    {
        private const string FilePath = "CursosAlura.json";
        private List<CursoResultado> _cursos;

        public CursoResultadoJsonRepository()
        {
            _cursos = LoadData();
        }

        /// <summary>
        /// Adicionar o dado no banco de dados, criando o ID e informando a data de cadastro.
        /// </summary>
        /// <param name="resultado"></param>
        public void Add(CursoResultado resultado)
        {
            resultado.Id = Guid.NewGuid();
            resultado.DataConsulta = DateTime.UtcNow;
            _cursos.Add(resultado);
            SaveData();
        }

        /// <summary>
        /// Efetua a consulta do curso por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CursoResultado Get(Guid id)
        {
            return _cursos.Find(c => c.Id == id);
        }

        /// <summary>
        /// Retorna todos os cursos cadastrados.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CursoResultado> GetAll()
        {
            return _cursos;
        }

        /// <summary>
        /// salvar dados no banco de dados.
        /// </summary>
        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_cursos, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        /// <summary>
        /// Delte todos os cursos cadastrados no banco de dado. Use apenas para teste!
        /// </summary>
        public void DeleteAll()
        {
            _cursos.Clear();
            SaveData();
        }

        /// <summary>
        /// Informe o Id do curso para o mesmo ser deletado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarCursoId(Guid id)
        {
            var curso = Get(id);
            if (curso != null)
            {
                _cursos.Remove(curso);
                SaveData();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Carregar os dados de um arquivo JSON e desserializá-los em uma lista de objetos CursoResultado.
        /// </summary>
        /// <returns></returns>
        private List<CursoResultado> LoadData()
        {
            if (!File.Exists(FilePath))
            {
                return new List<CursoResultado>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<CursoResultado>>(json);
        }
    }
}
