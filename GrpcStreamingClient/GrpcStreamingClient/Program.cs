﻿using Grpc.Core;
using Grpc.Net.Client;
using GrpcStreamingClient;
using System.Text;
// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7215");
var client = new ImageService.ImageServiceClient(channel);
// Open the file for reading

MyData.Info();

Console.WriteLine("\n=============================");
Console.WriteLine("Wybierz opcję");
Console.WriteLine("1 - Wysyłanie pliku");
Console.WriteLine("2 - Pobieranie pliku");
Console.WriteLine("=============================");
Console.Write("Wybór: ");
string choice = Console.ReadLine();
string photosFolder = "C:\\Users\\RPS\\source\\repos\\RSI\\lab05\\GrpcStreamingClient\\GrpcStreamingClient\\Photos\\";
string fileName = "";

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

switch (choice)
{
    case "1":
        try
        {
            Console.Write("Podaj nazwę pliku do wysłania (z rozszerzeniem): ");
            fileName = Console.ReadLine();
            using (var fileStream = File.OpenRead(photosFolder + fileName))
            {
                // Create a stream of ImageData objects
                using (var call = client.StreamToServer())
                {
                    // Stream the file data to the server
                    byte[] buffer = new byte[256];
                    int bytesRead;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await call.RequestStream.WriteAsync(new ImageData { Data = Google.Protobuf.ByteString.CopyFrom(buffer, 0, bytesRead) });
                    }
                    await call.RequestStream.CompleteAsync();

                    // Wait for the server to finish processing the stream
                    await call.ResponseAsync;
                }
            }
            Console.WriteLine("Plik wysłany poprawnie");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Niepoprawna sciezka do pliku!");   
        }
        
        break;

    case "2":
        Console.Write("Podaj nazwę pliku, pod którą ma zostać zapisany (z rozszerzeniem): ");
        fileName = Console.ReadLine();
        using (var call = client.StreamToClient(new Google.Protobuf.WellKnownTypes.Empty()))
        {
            // Create a file stream to write the received data
            try
            {
                using (var fileStream = File.Create(photosFolder + fileName))
                {
                    // Read data from the server stream and write it to the file stream
                    while (await call.ResponseStream.MoveNext())
                    {
                        ImageData imageData = call.ResponseStream.Current;
                        await fileStream.WriteAsync(imageData.Data.ToByteArray());
                        Console.WriteLine(imageData);
                    }
                }
                Console.WriteLine("Plik pobrany poprawnie");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Niepoprawna sciezka do pliku!");
            }
        }
        break;
    default:
        Console.WriteLine("Niepoprawny wybór");
        break;
}

// Shutdown the gRPC channel
await channel.ShutdownAsync();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();