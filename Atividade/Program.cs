using csharp_senai;

// Menu
bool condicao = true;

do {

    Console.WriteLine("\nMENU DE CADASTRAMENTO\n\n1 - Cadastrar Pessoas\n2 - Imprimir Pessoas Cadastradas\n3 - Sair\n\nEscolha uma opção: ");
    
    var opcao = Console.ReadLine();
    Console.Clear();

    if(opcao == "1") {
        Console.Clear();
        float val_pag;
        Console.WriteLine("Informe o seu nome: ");
        string var_nome = Console.ReadLine();

        Console.WriteLine("Pessoa Física (f) ou Jurídica (j) ?");
        string var_tipo = Console.ReadLine();

        while(var_tipo != "f" && var_tipo != "j"){
            Console.WriteLine("Pessoa Física (f) ou Jurídica (j) ?");
            var_tipo = Console.ReadLine();
        }
        
        if(var_tipo == "f") {  
            Console.Clear(); 
            Pessoa_Fisica pf = new Pessoa_Fisica();
            pf.nome = var_nome;

            Console.WriteLine("Digite a sua data de nascimento:");
            pf.data_nascimento = Console.ReadLine();
            Console.WriteLine("Informar CPF: ");
            string cpf = Console.ReadLine();

            while(cpf.Length != 11 || !cpf.All(char.IsDigit)) {
                Console.WriteLine("Analise se voccê está digitando apenas números e se existem 11 caracteres\n\nInformar CPF: ");
                cpf = Console.ReadLine();
            }
            pf.cpf = cpf;

            Console.WriteLine("Informar Valor de Compra: ");
            val_pag = float.Parse(Console.ReadLine());

            Console.WriteLine("Deseja pagar o seu imposto (s) SIM (n) NÃO");
            string pagamento = Console.ReadLine();

            while(pagamento != "s" && pagamento != "n") {
                Console.WriteLine("Analise se você está digitando apenas 's' para sim ou 'n' para Não\n\n");
                Console.WriteLine("Deseja pagar o seu imposto (s) SIM (n) NÃO:");
                pagamento = Console.ReadLine();
            }

            if (pagamento == "s"){
                Console.WriteLine("Você pagou o seu imposto!\n");
                pf.Pagar_Imposto(val_pag);
                pf.pagamento = true;
                pf.salvarInformacoes(pf);
            }else {
                Console.WriteLine("Você não pagou o seu imposto!\n");
                pf.Pagar_Imposto(val_pag);
                pf.pagamento = false;
                pf.salvarInformacoes(pf);
            }
        }

        if(var_tipo == "j") {
            Console.Clear();
            Pessoa_Juridica pj = new Pessoa_Juridica();
            pj.nome = var_nome;

            Console.WriteLine("Informar CNPJ:");
            string cnpj = Console.ReadLine();

            while(cnpj.Length != 14 || !cnpj.All(char.IsDigit)) {
                Console.WriteLine("Analise se voccê está digitando apenas números e se existem 14 caracteres!!\n\n");
                cnpj = Console.ReadLine();
            }
            pj.cnpj = cnpj;

            Console.WriteLine("Informar IE:");
            string ie = Console.ReadLine();

            while(ie.Length != 9 || !ie.All(char.IsDigit)) {
                Console.WriteLine("Analise se voccê está digitando apenas números e se existem 9 caracteres!!\n\n"); 
                Console.WriteLine("Informar IE: ");
                ie = Console.ReadLine();
            }

            pj.ie = ie;

            Console.WriteLine("Informar Valor de Compra:");
            val_pag = float.Parse(Console.ReadLine());

            
            Console.WriteLine("Deseja pagar o seu imposto (s) SIM (n) NÃO");
            string pagamento = Console.ReadLine();

            while(pagamento != "s" && pagamento != "n") {
                Console.WriteLine("Analise se você está digitando apenas 's' para sim ou 'n' para Não\n\n");
                Console.WriteLine("Deseja pagar o seu imposto (s) SIM (n) NÃO:");
                pagamento = Console.ReadLine();
            }

            if (pagamento == "s"){
                Console.WriteLine("Você pagou o seu imposto");
                pj.Pagar_Imposto(val_pag);
                pj.pagamento = true;
                pj.salvarInformacoes(pj);
            }else {
                Console.WriteLine("Você não pagou o seu imposto!\n");
                pj.Pagar_Imposto(val_pag);
                pj.pagamento = false;
                pj.salvarInformacoes(pj);
            }
            
        }
    }

    else if(opcao == "2"){
        Console.Clear();
        string caminho = @"\Pessoas Cadastradas\Pessoas_Cadastradas.txt";

        try{

            using(StreamReader sr = new StreamReader(caminho)){

                string dados = sr.ReadToEnd();

                if (dados != null ){
                    Console.WriteLine(dados);
                }
            }
        }catch{
            Console.WriteLine("Ainda não possuem pessoas cadastradas!");
        }
    }
    
    else if(opcao == "3"){
        Console.Clear();
        condicao = false;
        Console.WriteLine("Até a próxima!");
    }
    else{
        Console.Clear();
        Console.WriteLine("Credenciais inválidas");
    }
}
while(condicao);