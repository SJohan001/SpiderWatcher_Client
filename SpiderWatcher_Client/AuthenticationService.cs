﻿namespace SpiderWatcher_Client
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.JSInterop;
    using SpiderWatcher_Client.DTOs.UserDTO;

    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;

        public AuthenticationService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> LoginAsync(LoginUserDTO loginUserDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("User/login", loginUserDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", result.Token);
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
        }

        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }
    }

    public class LoginResult
    {
        public string Token { get; set; }
    }
}
