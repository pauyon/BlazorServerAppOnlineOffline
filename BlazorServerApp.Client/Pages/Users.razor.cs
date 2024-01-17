using BlazorServerApp.Client.Services.UserService;
using BlazorServerApp.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Client.Pages
{
    public partial class Users
    {
        private List<User>? _users;

        [Inject]
        public IUserService? UserService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _users = await UserService!.GetAll(ConnectionStatus.IsOnline);
            StateHasChanged();
        }
    }
}
