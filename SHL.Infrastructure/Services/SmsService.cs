using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Extensions.Options;
using SHL.Application.DTO.SendEmail;
using SHL.Application.IServices;

namespace SHL.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        private readonly SmsSettings _settings;
        private readonly HttpClient _httpClient;
    
        public SmsService(IOptions<SmsSettings> settings, HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
        }

        public async Task<bool> SendSmsAsync(string recipient, string message)
        {
            var random = new Random();
            int randomNumber = random.Next(0, 1001);
            var sm = new SmsMessage
            {
                id = randomNumber.ToString(),
                receiver = recipient,
                sender = _settings.Organisation,
                message ="Your otp code is "+ message,
                type = "sms"
            };
            var request = new SmsRequest { sms = new List<SmsMessage>() };
            request.sms.Add(sm);
            var json = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var credentials = $"{_settings.V2nUsername}:{_settings.V2nPassword}";
            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);

            var response = await _httpClient.PostAsync($"{_settings.V2nSmsBaseUrl}/api/push", content);

            return response.IsSuccessStatusCode;
            
        }
    }

}
