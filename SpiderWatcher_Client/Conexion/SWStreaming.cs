﻿using Grpc.Core;
using Grpc.Net.Client;
using System.IO;
using System.Threading.Tasks;
using static VideoService;


namespace SpiderWatcher_Client.Conexion
{
    public class SWStreaming
    {
        private readonly VideoServiceClient _client;

        public SWStreaming()
        {
            try
            {
                var channel = GrpcChannel.ForAddress("https://grcpsw.azurewebsites.net");
                _client = new VideoServiceClient(channel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating gRPC channel: {ex.Message}");
                throw;
            }
        }

        public async Task<MemoryStream> GetVideoStreamAsync(string videoName)
        {
            // Llama al método gRPC para obtener el stream del video
            var call = _client.downloadVideo(new DownloadFileRequest { Nombre = videoName });

            // Crea un MemoryStream para almacenar los datos del video
            var videoStream = new MemoryStream();

            // Lee cada fragmento de datos y lo escribe en el MemoryStream
            await foreach (var chunk in call.ResponseStream.ReadAllAsync())
                await videoStream.WriteAsync(chunk.Data.ToByteArray(), 0, chunk.Data.Length);

            videoStream.Position = 0;

            return videoStream;
        }
    }
}
