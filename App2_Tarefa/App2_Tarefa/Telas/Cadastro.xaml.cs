﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2_Tarefa.Modelos;

namespace App2_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public byte Prioridade { get; set; }
        public Cadastro()
        {
            InitializeComponent();
        }
        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;

            foreach (var Linha in Stacks)
            {
                Label LblPriodade = ((StackLayout)Linha).Children[1] as Label;
                LblPriodade.TextColor = Color.Gray;

            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            String Prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("a", "");
            //String Prioridade  = Source.File.ToString().Replace("Resources/", "").Replace(".png", "");

            this.Prioridade = byte.Parse(Prioridade);
        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool ErroExiste = false;
            if ( !(TxtNome.Text.Trim().Length > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO!", "Nome não foi informado!", "OK");
            }              
            
               
            if( !(this.Prioridade > 0))
            {
                ErroExiste = true;
                DisplayAlert("ERRO!", "Prioridade não informada", "OK");
            }
            
            if(ErroExiste == false)
            {
                //Salva
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());

            }
        }

    }
}