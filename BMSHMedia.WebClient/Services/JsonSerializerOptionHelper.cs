﻿using System.Text.Json;

namespace BMSHMedia.WebClient.Services
{
    public class JsonSerializerOptionHelper
    {
        public static JsonSerializerOptions GetOption()
        {
            var op = new JsonSerializerOptions
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };
            op.Converters.Add(new DateTimeJsonConverter());

            return op;
        }
    }
}
