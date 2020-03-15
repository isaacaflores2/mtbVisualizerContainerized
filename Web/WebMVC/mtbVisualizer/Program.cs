using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace mtbVisualizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try { 
                BuildWebHost(args).Run(); 
            } 
            catch (Exception ex) { 
                Console.WriteLine(ex); 
            }
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    if (context.HostingEnvironment.IsProduction())
                    {

                        var builtConfig = builder.Build();
                        var keyVaultEndpoint = $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/";

                        if (!string.IsNullOrEmpty(keyVaultEndpoint))
                        {
                            var azureServiceTokenProvider = new AzureServiceTokenProvider();
                            var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                    azureServiceTokenProvider.KeyVaultTokenCallback));
                            builder.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                        }
                    }
                })
                .UseStartup<Startup>()
                .Build();       
    }
}
