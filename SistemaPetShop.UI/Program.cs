using System;
using PetShop.Models;

class Program
{
    static void Main(string[] args) 
    {
        string opcao = string.Empty;
        bool exibirMenu = true;
        Gerenciamento ge = new Gerenciamento();

        Console.WriteLine("===============================");
        Console.WriteLine("Bem vindo ao PETSHOP");
        Console.WriteLine("===============================");

        Console.WriteLine("Pressione uma tecla para continuar...");
        Console.ReadKey();

        while (exibirMenu) {

            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cliente");
            Console.WriteLine("2 - Pet");
            Console.WriteLine("3 - Agendamento");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    bool exibirMenuCliente = true;
                    while (exibirMenuCliente)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite a sua opção:");
                        Console.WriteLine("1 - Cadastrar Cliente");
                        Console.WriteLine("2 - Listar Clientes");
                        Console.WriteLine("3 - Remover Cliente");
                        Console.WriteLine("4 - Voltar ao menu inicial");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                ge.CadastrarCliente();
                                break;
                            case "2":
                                if(ge.ConfirmaSenha() == true)
                                {
                                    ge.ListarCliente();
                                }             
                                break;
                            case "3":
                                //implementar remover
                                break;
                            case "4":
                                exibirMenuCliente = false;
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case "2":
                    bool exibirMenuPet = true;
                    while (exibirMenuPet)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite a sua opção:");
                        Console.WriteLine("1 - Cadastrar Pet");
                        Console.WriteLine("2 - Listar Pet");
                        Console.WriteLine("3 - Remover Pet");
                        Console.WriteLine("4 - Voltar ao menu inicial");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                ge.CadastrarPet();
                                break;
                            case "2":
                                if (ge.ConfirmaSenha() == true)
                                {
                                    ge.ListarPet();
                                }
                                break;
                            case "3":
                                //implementar remover
                                break;
                            case "4":
                                exibirMenuPet = false;
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                Console.ReadKey();
                                break;        
                        }
                    }
                    break;
                case "3":
                    bool exibirMenuAgendamento = true;
                    while (exibirMenuAgendamento)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite a sua opção:");
                        Console.WriteLine("1 - Cadastrar Agendamento");
                        Console.WriteLine("2 - Listar Agendamento");
                        Console.WriteLine("3 - Remover Agendamento");
                        Console.WriteLine("4 - Voltar ao menu inicial");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                ge.CadastrarAgendamento();
                                break;
                            case "2":
                                if (ge.ConfirmaSenha() == true)
                                {
                                    ge.ListarAgendamento();
                                }
                                break;
                            case "3":
                                //implementar remover
                                break;
                            case "4":
                                exibirMenuAgendamento = false;
                                break;
                            default:
                                Console.WriteLine("Opção inválida");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case "4":
                    exibirMenu = false;
                    break;
                    Console.ReadKey();
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
        Console.WriteLine("O programa se encerrou");
        Console.ReadKey();
    }
}
