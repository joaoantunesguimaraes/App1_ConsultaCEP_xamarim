using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultaCEP.Servico.Modelo;
using App1_ConsultaCEP.Servico;
using Xamarin.Forms.PlatformConfiguration;

//using Java.Lang.Object;
using System.Threading;
using System.Threading.Tasks;



namespace App1_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Evento click do botão
            btn_BOTAO.Clicked += BuscarCEP;
        }

        // Método Privado evento Click do Botão
        private void BuscarCEP(object sender, EventArgs args)
        {

            // TODO - Validações

            // .text -- Propriedade que vai buscar o conteúdo dum campo de entrada de texto
            // Trim() - remover espaços em Branco antes e depois
            string cep = edt_CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    // Servico.Modelo.ViaCEPServico.BuscarEnderecoViaCep(cep);
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        // Propriedade .Text
                        edt_RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1} ", end.localidade, end.uf, end.logradouro, end.bairro);
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
            else
            {
                // Passa o Foco para o campo de entrada de Texto
                edt_CEP.Focus();
            }
        }


        // Método muito tosco - refazer
        private bool isValidCEP(string cep)
        {
            //bool valido = true;
            if (cep.Length != 8)
            {
                // Erro
                DisplayAlert("ERRO!", "CEP Inválido!" + '\n' + "O CEP deve conter 8 caracteres!", "OK");
                //valido = false;
                return false;
            }
            //int NovoCEP;// = 0;
            if (!int.TryParse(cep, out int NovoCEP))
            {
                // Erro
                DisplayAlert("ERRO!", "CEP Inválido! O CEP deve ser composto apenas por números!", "OK");
                //valido = false;
                return false;
            }
            //return valido;
            return true;
        }



        // Sair da aplicação
        // btn_Exit
        // Método Privado evento Click do Botão
        private void btn_Exit_clickable(object sender, EventArgs args)
        {
            DependencyService.Get<IMessage>().LongAlert("O Programa vai ser encerrado!");


            //Thread.Sleep(5000);
            //await 
            Task.Delay(5000);
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            //System.Environment.Exit(0);



        }

    }
}
