using DemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace DemoConsoAPI.Pages.Movie
{
    public partial class MovieCreateView
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public IHttpClientFactory Factory { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        public IEnumerable<Personne> Persons { get; set; }

        public MovieCreateModel MyForm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Persons = await Client.GetFromJsonAsync<IEnumerable<Personne>>("person");
            MyForm = new MovieCreateModel();
        }

        public async Task OnSubmitForm()
        {
            foreach(Actor a in MyForm.Casting)
            {
                Personne Current = Persons.FirstOrDefault(x => x.Id == a.Id);
                a.Firstname = Current.Firstname;
                a.Lastname = Current.Lastname;
                a.PictureURL = Current.PictureURL;
            }
            await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(MyForm));
            Client = Factory.CreateClient("WithToken");
          

            await Client.PostAsJsonAsync("movie", MyForm);

        }

        public void AddPersonToCasting()
        {
            MyForm.Casting.Add(new Actor());
            StateHasChanged();
        }
    }
}
