﻿using DemoConsoAPI.Models;
using DemoConsoAPI.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text;

namespace DemoConsoAPI.Pages
{
    public partial class Login
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider providerService { get; set; }
        [Inject]
        public NavigationManager nav{ get; set; }
        public LoginForm MyForm { get; set; }
        public HttpClient client { get; set; }
        private string ApiUrl = "https://localhost:7158/api/";
        protected override void OnInitialized()
        {
            MyForm = new LoginForm();
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiUrl);
        }

        public async void SubmitLogin()
        {
            string json = JsonConvert.SerializeObject(MyForm);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage message = await client.PostAsync("Auth/login", content))
            {
                if (message.IsSuccessStatusCode)
                {
                    string token = message.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(token);
                    await jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
                    ((MyStateProvider)providerService).NotifyUserChanged();
                    nav.NavigateTo("/");
                }
                else
                {
                    Console.WriteLine(message);
                }
                //if(message.StatusCode == System.Net.HttpStatusCode.OK) { }
            }

        } 
    }
}
