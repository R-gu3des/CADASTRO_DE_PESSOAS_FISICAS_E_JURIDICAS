namespace csharp_senai
{
    class Pessoa_Fisica : Clientes {
        public string cpf {get; set;}
        public string data_nascimento {get; set;}
        public bool pagamento {get; set;}

        public override string ToString(){
            return "-------- Pessoa Física ---------" + "\n" +
            "Nome ..........: " + this.nome + "\n" +
            "Nascimento ....: " + this.data_nascimento + "\n" +
            "CPF ...........: " + this.cpf + "\n" +
            "Valor de Compra: " + this.valor.ToString("C") + "\n" +
            "Imposto .......: " + this.valor_imposto.ToString("C") + "\n" +
            "Total a Pagar : " + this.total.ToString("C") + "\n" +
            "Pagamento Confirmado: "+ this.pagamento +"\n";
        }

        public void salvarInformacoes(Pessoa_Fisica pf){

            string caminho = @"Pessoas Cadastradas\Pessoas_Cadastradas.txt";

            using (StreamWriter sw = File.AppendText(caminho)){
                sw.WriteLine(pf.ToString());
            };

        }
    }
    
}