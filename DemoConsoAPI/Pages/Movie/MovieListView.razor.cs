using DemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoConsoAPI.Pages.Movie
{
    public partial class MovieListView
    {
        public IEnumerable<SimpleMovieModel> Movies { get; set; }

        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        [Inject]
        public IHttpClientFactory Factory { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Movies = await Client.GetFromJsonAsync<IEnumerable<SimpleMovieModel>>("Movie");
        }

        public async Task Degage(int id)
        {
            await (Factory.CreateClient("WithToken")).DeleteAsync("Movie/"+id);
            OnInitializedAsync();
        }
    }
}
