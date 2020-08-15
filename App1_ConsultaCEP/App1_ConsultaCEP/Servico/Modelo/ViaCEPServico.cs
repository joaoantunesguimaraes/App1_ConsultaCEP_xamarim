using System;
using System.Collections.Generic;
using System.Text;
using System.Net; // WebClient
using App1_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json; // JsonConvert



// Usada para fazer o download da informação
// Obter o endereço preenchido do site ViaCEP

namespace App1_ConsultaCEP.Servico.Modelo
{
    public class ViaCEPServico        
    {
        // Variáveis de Classe
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        // Método de Classe
        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            
            //System.Net.WebClient wc = new System.Net.WebClient();
            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoURL);


            //Endereco end = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(conteudo);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;

        }


        
 



    }
}
