using DemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DemoConsoAPI.Pages
{
    public partial class UserProfil
    {
        [Inject]
        public IJSRuntime js { get; set; }

        public User CurrentUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7158/api/auth");

            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage message = await client.GetAsync(""))
            {
                if(message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentUser = JsonConvert.DeserializeObject<User>(json);
                    StateHasChanged();
                }
            }
        }
    }
}
