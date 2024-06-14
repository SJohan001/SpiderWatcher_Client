﻿using Newtonsoft.Json;

namespace SpiderWatcher_Client.DTOs.ContentDTO
{
    public class ReadContentDTO
    {
        public int IdContent { get; init; }
        public string Title { get; init; }
        public string Director { get; init; }
        public string Description { get; init; }
        public DateOnly ReleaseDate { get; init; }
        public DateOnly PublicationDate { get; init; }
        public TimeOnly Duration { get; init; }
        public int Rating { get; init; }
        public string ImageReference { get; init; }
        public string VideoReference { get; init; }

        [JsonIgnore]
        public byte[] ImageData { get; set; }  // Nueva propiedad para almacenar los datos de la imagen
    }
}
