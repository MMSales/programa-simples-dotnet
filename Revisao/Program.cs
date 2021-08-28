﻿using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "4")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if  (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        } //var: inferência de tipo, o que eu atribuir para nota,ele vai ser
                        else {
                            throw new ArgumentException("Valor da nota deve ser DECIMAL.");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        
                        break;
                    case "2":
                        foreach(var a in alunos ){
                            if (!string.IsNullOrEmpty(a.Nome)){
                            Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }                       
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2){
                            conceitoGeral = Conceito.E;    
                        }
                        else if (mediaGeral < 4){
                            conceitoGeral = Conceito.D;
                        }

                        else if (mediaGeral < 6){
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8){
                            conceitoGeral = Conceito.B;
                        }
                        else {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL DOS ALUNOS: {mediaGeral}- CONCEITO: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1: Inserir um novo aluno");
            Console.WriteLine("2: Listar alunos");
            Console.WriteLine("3: Calcular média geral");
            Console.WriteLine("4: Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine(); //lê o que a pessoa escreveu no console
            Console.WriteLine(); 
            return opcaoUsuario;
        }
    }
}
