using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace Grpc.Demo.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Instantiating a Channel containing the information for creating the connection to the gRPC service.
            // The port number(50051) must match the port of the gRPC server.
            var channel = new Channel("localhost:50051",
                                       ChannelCredentials.Insecure);

            // Using the Channel to construct the Greeter client
            var client = new Greeter.GreeterClient(channel);

            // The Greeter client calls the asynchronous SayHello method
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });

            // The result of the SayHello call is displayed
            Console.WriteLine("Greeting: " + reply.Message);

            // Shut down the Channel used by the client when operations have finished to release all resources
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
