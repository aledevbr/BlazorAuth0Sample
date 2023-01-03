using Microsoft.AspNetCore.Components;

namespace BlazorAuth0Sample.Client.Pages
{
    public partial class Authentication : ComponentBase
    {
        [Parameter] public string Action { get; set; } = null!;

        private void Logout()
        {
            var authority = Configuration["Auth0:Authority"];
            var clientId = Configuration["Auth0:ClientId"];
            Navigation.NavigateTo($"{authority}/v2/logout?client_id={clientId}");
        }
    }
}