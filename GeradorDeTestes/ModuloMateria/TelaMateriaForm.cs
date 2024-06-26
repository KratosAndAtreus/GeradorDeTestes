﻿using GeradorDeTestes.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        private Materia materia;
        public Materia Materia
        {
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                cmbDisciplina.Text = value.Disciplina.ToString();
            }

            get { return materia; }
        }

        public TelaMateriaForm()
        {
            InitializeComponent();
        }

        public void CarregarDisciplina(List<Disciplina> disciplinas)
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            string serie = "";

            if (rbPrimeiraSerie.Checked)
                serie = rbPrimeiraSerie.Text;

            else if (rbSegundaSerie.Checked)
                serie = rbSegundaSerie.Text;

            materia = new Materia(nome, disciplina, serie);

            materia.Disciplina.Materias.Add(materia);

            List<string> erros = materia.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
