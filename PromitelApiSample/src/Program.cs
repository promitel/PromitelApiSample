using PromitelApiSample.src.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PromitelApiSample.src;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Najprostrza implementacja z użyciem NSwag do utworzenia
        // klienta i kontrolera. Poniższy przyklad przedstawia 
        // implementacje tylko dla klasy Client (Sampler nie zawiera implementacji dla IController).
        //
        // Wygenerowany klient w NSwag należy zmodyfikować aby przyjmować w
        // nagłówku Token tak jak dla metody 'await client.AllProductsAuthenticateAsync(token, request);'
        // if (!string.IsNullOrWhiteSpace(token))
        // {
        //     request_.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        // }

        string url = "https://api.promitel.pl";

        try
        {
            using HttpClient httpClient = new HttpClient();

            Client client = new Client(url, httpClient);

            Console.WriteLine($"Base Url: {client.BaseUrl}\n");

            // Url: /api/test/all-products:
            await AllProductsAsync(client);

            // Url: /api/test/all-products-authenticate: (należy podmienić dane uwierzytelnienia)
            await AllProductsAuthenticateAsync(client);

            // Url: /api/test/all-products-authenticate: (zwróci błąd - brak autoryzacji)
            await AllProductsAuthenticateErrorAsync(client);

        }
        catch (Exception ex)
        {
            var error = ex as ApiException;
            if (error is null)
                throw new Exception($"Błąd: {ex.Message}");

            var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(error.Response);
            if (errorResponse == null)
                throw new Exception($"Błąd: {ex.Message}");

            var errorCode = errorResponse.Code;
            var errorMessage = errorResponse.Message;

            Console.WriteLine($"\nPrzechwycony wyjątek:\nCode: {errorCode}\nMessage: {errorMessage}");
        }
    }

    private static async Task AllProductsAsync(Client client)
    {
        try
        {
            var productTest = await client.AllProductsAsync();
            if (productTest != null)
            {
                Console.WriteLine(nameof(AllProductsAsync));

                foreach (var (index, product) in productTest.Index())
                {
                    Console.WriteLine($"{index + 1}. {product.Name}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async Task AllProductsAuthenticateAsync(Client client)
    {
        try
        {
            var request = new RecordRequest
            {
                Strona = 1,
                RekordowNaStronie = 2,
            };

            // Login i hasło należy podmienić na te uzyskane od osoby
            // kontaktowej w Promitel

            var login = new LoginRequest
            {
                Login = "LOGIN_POZIOM_I",
                Password = "HASLO_POZIOM_I"
            };

            // ETAP I: AUTORYZACJA
            var authorize = await client.AuthorizeAsync(login);

            // ETAP II: UZYSKANIE TOKENA
            string token = string.Empty;
            if (authorize != null)
            {
                var authenticationRequest = new AuthenticationRequest
                {
                    Data = new LoginRequest
                    {
                        Login = "LOGIN_POZIOM_2",
                        Password = "HASLO_POZIOM_2"
                    },
                    Token = authorize.Token
                };

                var authentication = await client.AuthenticateAsync(authenticationRequest);
                token = authentication.Token;
            }

            var productTestAutheticate = await client.AllProductsAuthenticateAsync(token, request);
            if (productTestAutheticate != null)
            {
                Console.WriteLine($"\n{nameof(AllProductsAuthenticateAsync)}");
                foreach (var (index, product) in productTestAutheticate.Rekordy.Index())
                {
                    Console.WriteLine($"{index + 1}. {product.Name}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static async Task AllProductsAuthenticateErrorAsync(Client client)
    {
        try
        {
            var request = new RecordRequest
            {
                Strona = 1,
                RekordowNaStronie = 2,
            };

            var productTestAutheticate = await client.AllProductsAuthenticateAsync("", request);
            if (productTestAutheticate != null)
            {
                Console.WriteLine("/api/test/all-products:");
                foreach (var (index, product) in productTestAutheticate.Rekordy.Index())
                {
                    Console.WriteLine($"{index + 1}. {product.Name}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

