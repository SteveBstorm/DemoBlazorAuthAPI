using DemoConsoAPI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DemoConsoAPI.Pages.Movie
{
    public partial class MovieDetailView
    {
        [Parameter]
        public int Id { get; set; }
        public CompleteMovieModel Movie { get; set; }

        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Movie = await Client.GetFromJsonAsync<CompleteMovieModel>("Movie/"+Id);
        }
    }
}
