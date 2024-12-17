using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Euromil; // Namespace gerado automaticamente a partir do euromil.proto

class Program
{
    static async Task Main(string[] args)
    {
        // Dados de entrada
        string betKey = "Aposta123";         // Chave da aposta
        string checkId = "9876543210123456"; // ID do cheque digital

        // Configura��o do canal gRPC
        using var channel = GrpcChannel.ForAddress("https://localhost:5001"); // Substitua pela URL do servidor gRPC
        var client = new Euromil.EuromilClient(channel);

        try
        {
            // Criar mensagem de requisi��o
            var request = new RegisterRequest
            {
                Key = betKey,
                Checkid = checkId
            };

            Console.WriteLine("Registrando aposta no EuroMilRegister...");

            // Chamar o m�todo RegisterEuroMil
            var reply = await client.RegisterEuroMilAsync(request);

            // Exibir a resposta
            Console.WriteLine($"Resposta do servidor: {reply.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
