using DemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoConsoAPI.Pages
{
    public partial class RegisterUser
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav{ get; set; }

        public RegisterUserForm MyForm { get; set; }

        protected override void OnInitialized()
        {
            MyForm = new RegisterUserForm();
        }

        private async Task OnSubmitForm()
        {
            try
            {
                if(Client.PostAsJsonAsync<RegisterUserForm>("auth/register", MyForm).IsCompleted)
                    Nav.NavigateTo("/login");
            }
            catch(HttpRequestException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }


    }
}
