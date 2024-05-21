using DemoConsoAPI.Models;
using DemoConsoAPI.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DemoConsoAPI.Pages.Person
{
    public partial class PersonDetailView : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public HttpClient Client { get; set; }

        [Inject]
        public IHttpClientFactory Factory { get; set; }
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        public Personne CurrentPerson { get; set; }
        public IEnumerable<SimpleMovieModel> Filmo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Console.Out.WriteLineAsync("coucou");
            Console.WriteLine((await State).User.Claims.Count());
            if ((await State).User.Claims.Count() > 0)
            {
                Client = Factory.CreateClient("WithToken");
                Filmo = await Client.GetFromJsonAsync<IEnumerable<SimpleMovieModel>>("movie/byactorid/" + Id);
                CurrentPerson = await Client.GetFromJsonAsync<Personne>("person/" + Id);
            }else
            {
                Nav.NavigateTo("login");
            }
        }
    }
}
