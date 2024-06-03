﻿using DesafioAeCAutomacaoApp.AppService.Servicos;
using DesafioAeCAutomacaoApp.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioAeCAutomacaoApp.UI.Views
{
    public partial class FrmBotAlura : Form
    {
        private readonly CursoAluraServicos _cursoServico;

        public FrmBotAlura()
        {
            InitializeComponent();
            _cursoServico = new CursoAluraServicos();
        }  

        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            var ret = await _cursoServico.ConsultarCursos(txtCampoTermo.Text);
            CarregaDgv();
        }

        private void BtnDgv_Click(object sender, EventArgs e)
        {
            CarregaDgv();
        }

        /// <summary>
        /// Preenche os dados do banco no datagridview para exporta.
        /// </summary>
        private void CarregaDgv()
        {
            CursoResultado curso = new CursoResultado();
            List<CursoResultado> ListaCuros = new List<CursoResultado>();

            var cursos = _cursoServico.ObterTodosCursos();

            foreach (var item in cursos)
            {
                ListaCuros.Add(item);
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(Guid));
            dataTable.Columns.Add("UrlCurso", typeof(string));
            dataTable.Columns.Add("Titulo", typeof(string));
            dataTable.Columns.Add("Professor", typeof(string));
            dataTable.Columns.Add("CargaHora", typeof(string));
            dataTable.Columns.Add("Descricao", typeof(string));
            dataTable.Columns.Add("DataConsulta", typeof(DateTime));

            foreach (CursoResultado resultado in ListaCuros)
            {
                DataRow row = dataTable.NewRow();
                row["Id"] = resultado.Id;
                row["UrlCurso"] = resultado.UrlCurso;
                row["Titulo"] = resultado.Titulo;
                row["Professor"] = resultado.Professor;
                row["CargaHora"] = resultado.CargaHora;
                row["Descricao"] = resultado.Descricao;
                row["DataConsulta"] = resultado.DataConsulta;
                dataTable.Rows.Add(row);
            }

            DgvBaseDados.DataSource = dataTable;
        }
    }
}
