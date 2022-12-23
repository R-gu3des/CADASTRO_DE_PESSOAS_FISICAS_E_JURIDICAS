namespace csharp_senai
{
    public class Pessoa_Juridica : Clientes
    {
        public string cnpj {get; set;}
        public string ie {get; set;}
        public bool pagamento {get; set;}

        public override void Pagar_Imposto(float val) {
            this.valor = val;
            this.valor_imposto = (float)(this.valor * 0.2);
            this.total = this.valor + this.valor_imposto;
        }

        public override string ToString(){
            return "-------- Pessoa Jurídica ---------" + "\n" +
            "Nome ..........: " + this.nome +"\n" +
            "CNPJ ..........: " + this.cnpj + "\n" +
            "IE ............: " + this.ie + "\n" +
            "Valor de Compra: " + this.valor.ToString("C") + "\n" +
            "Imposto .......: " + this.valor_imposto.ToString("C") + "\n" +
            "Total a Pagar : " + this.total.ToString("C") + "\n" +
            "Pagamento Confirmado: "+ this.pagamento +"\n";
        }


        public void salvarInformacoes(Pessoa_Juridica  pj){

            string caminho = @"Pessoas Cadastradas\Pessoas_Cadastradas.txt";

            using (StreamWriter sw = File.AppendText(caminho)){
                sw.WriteLine(pj.ToString());
            };
        }
    }
}