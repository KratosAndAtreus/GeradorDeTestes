﻿using eAgenda.ConsoleApp.Compartilhado;
using GeradorDeTestes.ModuloDisciplina;
using GeradorDeTestes.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.ModuloTeste
{
    public class Teste : EntidadeBase
    {

        public string Titulo { get; set; }

        public Disciplina Disciplina { get; set; }

        public Materia Materia { get; set; }

        public int QuantidadeQuestoes { get; set; }

        public Teste(string titulo, Disciplina disciplina, Materia materia, int quantidadeQuestoes)
        {
            Titulo = titulo;
            Disciplina = disciplina;
            Materia = materia;
            QuantidadeQuestoes = quantidadeQuestoes;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Teste teste = (Teste) novoRegistro;

            Titulo = teste.Titulo;
            Disciplina = teste.Disciplina;
            Materia = teste.Materia;
            QuantidadeQuestoes = teste.QuantidadeQuestoes;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Titulo}, {Disciplina}, {Materia}, {QuantidadeQuestoes}";
        }
    }
}