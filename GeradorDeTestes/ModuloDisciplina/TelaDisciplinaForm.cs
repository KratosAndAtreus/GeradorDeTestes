﻿namespace GeradorDeTestes.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;

        private List<Disciplina> disciplinas;
        
        private int? idSelecionado;

        public Disciplina Disciplina
        {
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
            }
            get
            {
                return disciplina;
            }
        }
        public TelaDisciplinaForm(List<Disciplina> disciplinas, int? idSelecionado = null)
        {
            InitializeComponent();
            this.disciplinas = disciplinas;
            this.idSelecionado = idSelecionado;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            disciplina = new Disciplina(nome);

            List<string> erros = disciplina.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            if (disciplina.ExisteDisciplina(disciplinas, idSelecionado))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Já existe uma disciplina com esse nome!");

                DialogResult = DialogResult.None;
            }
        }
    }
}
