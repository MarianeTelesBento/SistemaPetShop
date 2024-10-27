using System;
using System.Collections.Generic;

namespace PetShop.Models
{
    public class Cliente
    {
        public int clienteId { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
    }
    public class Pet
    {
        public int petId { get; set; }
        public string nome { get; set; }
        public string especie { get; set; }
        public string raca { get; set; }
        public int idade { get; set; }
        public int clienteId { get; set; }
    }
    public class Agendamento
    {
        public int agendamentoId { get; set; }
        public int petId { get; set; }
        public string servico { get; set; }
        public DateTime dataAgendada { get; set; }
    }

    public class Gerenciamento
    {
        public int idC = 1;
        public int idP = 1;
        public int idA = 1;
        public string senha = "1234";

        public List<Cliente> listaCliente = new List<Cliente>();
        public List<Pet> listaPet = new List<Pet>();
        public List<Agendamento> listaAgendamento = new List<Agendamento>();

        public void CadastrarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.clienteId = idC++;
            Console.WriteLine("Digite seu nome");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Digite seu telefone");
            cliente.telefone = Console.ReadLine();
           
            if (listaCliente.Any(c => c.telefone == cliente.telefone))
            {
                Console.WriteLine("Esse número de telefone já foi cadastrado.");
            }
            else
            {
                listaCliente.Add(cliente);
                Console.WriteLine("Cliente Cadastrado com sucesso!!!");
                Console.WriteLine($"Seu Id é:{cliente.clienteId}");
            }
            Console.ReadKey();
        }
        public void CadastrarPet()
        {

            Console.WriteLine("Digite o ID do dono");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            Cliente dono = listaCliente.Find(c => c.clienteId == clienteId);
            if (dono == null)
            {
                Console.WriteLine("Cliente não encontrado :/");
                Console.WriteLine("Pressione uma tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Pet pet = new Pet();
            pet.petId = idP++;
            pet.clienteId = clienteId;

            Console.WriteLine("Digite o nome do seu pet");
            pet.nome = Console.ReadLine();
            Console.WriteLine("Digite a espécie do seu pet");
            pet.especie = Console.ReadLine();
            Console.WriteLine("Digite a raça do seu pet");
            pet.raca = Console.ReadLine();
            Console.WriteLine("Digite a idade do seu pet");
            pet.idade = Convert.ToInt32(Console.ReadLine());

            listaPet.Add(pet);
            Console.WriteLine("Pet Cadastrado com sucesso!!!");
            Console.WriteLine($"O Id do seu pet é:{pet.petId}");
            Console.ReadKey();
        }
        public void CadastrarAgendamento()
        {
            bool tipoServico = false;

            Console.WriteLine("Digite o ID do pet");
            int petId = Convert.ToInt32(Console.ReadLine());
            Pet pet = listaPet.Find(p => p.petId == petId);
            if (pet == null)
            {
                Console.WriteLine("Pet não encontrado :/");
                Console.WriteLine("Pressione uma tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Agendamento agendamento = new Agendamento();
            agendamento.agendamentoId = idA++;
            agendamento.petId = petId;
            Console.WriteLine("Selecione o tipo de serviço:");
            Console.WriteLine("1 - Banho");
            Console.WriteLine("2 - Tosa");
            Console.WriteLine("3 - Consulta");
            do
            {
                tipoServico = false;
                switch (Console.ReadLine())
                {
                    case "1":
                        agendamento.servico = "Banho";
                        break;
                    case "2":
                        agendamento.servico = "Tosa";
                        break;
                    case "3":
                        agendamento.servico = "Consulta";
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente:");
                        tipoServico = true;
                        break;
                }
            } while (tipoServico);

            Console.WriteLine("Digite a data do agendamento (ex: 2024-10-28):");
            agendamento.dataAgendada = DateTime.Parse(Console.ReadLine());

            // Verifica se já existe um agendamento para o mesmo pet e data
            if (listaAgendamento.Any(c => c.dataAgendada == agendamento.dataAgendada && c.petId == agendamento.petId))
            {
                do
                {
                    Console.WriteLine("Já existe uma consulta agendada para esse dia. Gostaria de marcar outra? (S/N)");
                    string confirAgenda = Console.ReadLine();

                    if (confirAgenda.ToUpper() == "S")
                    {
                        listaAgendamento.Add(agendamento);
                        Console.WriteLine("Agendamento cadastrado com sucesso!");
                        Console.WriteLine($"O Id da sua consulta é:{agendamento.agendamentoId}");
                        Console.ReadKey();
                        return;
                    }
                    else if (confirAgenda.ToUpper() == "N")
                    {
                        Console.WriteLine("Agendamento cancelado.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, responda apenas com 'S' ou 'N'.");
                    }
                    Console.ReadKey();
                } while (true);
            }
            else
            {
                listaAgendamento.Add(agendamento);
                Console.WriteLine("Agendamento cadastrado com sucesso!");
                Console.WriteLine($"O Id da sua consulta é:{agendamento.agendamentoId}");
                Console.ReadKey();
            }
        }

        public void ListarCliente()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            if (listaCliente.Any())
            {
                Console.WriteLine("Os clientes cadastrados são:");
                foreach (Cliente cliente in listaCliente)
                {
                    Console.WriteLine($"ID: {cliente.clienteId}, Nome: {cliente.nome}, Telefone: {cliente.telefone}");
                }
            }
            else
            {
                Console.WriteLine("Não há clientes cadastrados");
            }
            Console.WriteLine("==========================================");
            Console.ReadKey();
        }
        public void ListarPet()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            if (listaPet.Any())
            {
                Console.WriteLine("Os pets cadastrados são:");
                foreach (Pet pet in listaPet)
                {
                    Console.WriteLine($"ID: {pet.petId}, Nome: {pet.nome}, Especie: {pet.especie}, Raça: {pet.raca}, Idade: {pet.idade}, TutorID: {pet.clienteId}" );
                }
            }
            else
            {
                Console.WriteLine("Não há pets cadastrados");
            }
            Console.WriteLine("==========================================");
            Console.ReadKey();
        }
        public void ListarAgendamento()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            if (listaAgendamento.Any())
            {
                Console.WriteLine("Os agendamentos são:");
                foreach (Agendamento agendamento in listaAgendamento)
                {
                    Console.WriteLine($"ID de agendamento: {agendamento.agendamentoId}, Id do pet: {agendamento.petId}, Serviço: {agendamento.servico}, Data: {agendamento.dataAgendada}.");
                }
            }
            else
            {
                Console.WriteLine("Não há agendamentos.");
            }
            Console.WriteLine("==========================================");
            Console.ReadKey();
        }

        public bool ConfirmaSenha()
        {
            bool senhaIncorreta = true; 
            do
            {
                Console.Clear();
                Console.WriteLine("========================================================================");
                Console.WriteLine("Digite sua senha de administrador, ou (SAIR) para voltar ao menu inicial");
                string senhaDigitada = Console.ReadLine();
                Console.WriteLine("==============================================");
                if (senhaDigitada == senha)
                {
                    Console.WriteLine("Entrando no sistema...");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("Pressione uma tecla para continuar...");

                    Console.ReadKey();
                    return true;
                }
                else if (senhaDigitada.ToUpper() == "SAIR") 
                {
                    Console.WriteLine("Voltando ao menu...");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("Pressione uma tecla para continuar...");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    Console.WriteLine("Senha incorreta.");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("Tente novamente!!!");
                    Console.ReadKey();
                }
            } while (senhaIncorreta); 
            return false;

        }
    }
}
