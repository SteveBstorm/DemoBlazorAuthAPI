using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using DemoConsoAPI.Security;
using System.Reflection;

namespace DemoConsoAPI.Pages
{
    public partial class Logout
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider providerService { get; set; }
        [Inject]
        public NavigationManager nav { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await jsRuntime.InvokeVoidAsync("localStorage.clear");
            ((MyStateProvider)providerService).NotifyUserChanged();
            nav.NavigateTo("/");
        }
    }
}
