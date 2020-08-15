using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultaCEP.Servico.Modelo;
using App1_ConsultaCEP.Servico;


namespace App1_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Evento click do botão
            BOTAO.Clicked += BuscarCEP;

        }

        // Método Privado evento Click do Botão
        private void BuscarCEP(object sender, EventArgs args)
        {

            // TODO - Validações

            // .text -- Propriedade que vai buscar o conteúdo dum campo de entrada de texto
            // Trim() - remover espaços em Branco antes e depois
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    // Servico.Modelo.ViaCEPServico.BuscarEnderecoViaCep(cep);
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCep(cep);

                    if(end != null)
                    {
                        // Propriedade .Text
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO!", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                   
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro critico!", e.Message, "OK");
                }

            }

        }


        // Método muito tosco - refazer
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                // Erro
                DisplayAlert("ERRO!", "CEP Inválido! O CEP deve contem 8 caracteres!", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(int.TryParse(cep, out NovoCEP))
            {
                // Erro
                valido = false;
                DisplayAlert("ERRO!", "CEP Inválido! O CEP deve ser composto apenas por números!", "OK");
            }

            return valido;
        }
    }
}
