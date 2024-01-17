using BlazorServerApp.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace BlazorServerApp.Client.Components
{
    /// <summary>
    /// Component that displays whether there is Internet connection
    /// </summary>
    public partial class Connection
    {
        [Inject]
        public IJSRuntime? JsRuntime { get; set; }

        [Inject]
        public IDialogService? DialogService { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        private void OpenDialog()
        {
            var parameters = new DialogParameters<ConnectionDialog>
            {
                { x => x.IsOnline, IsOnline }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };
            DialogService!.Show<ConnectionDialog>("Connection Info", parameters, options);
        }

        public bool IsOnline { get; set; }

        [JSInvokable("Connection.StatusChanged")]
        public void OnConnectionStatusChanged(bool isOnline)
        {
            var refreshPage = ConnectionStatus.IsOnline != isOnline;

            if (IsOnline != isOnline)
            {
                IsOnline = isOnline;
                ConnectionStatus.IsOnline = isOnline;
            }

            if (refreshPage)
            {
                NavigationManager!.NavigateTo(NavigationManager.Uri, true);
            }

            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            JsRuntime!.InvokeVoidAsync("Connection.Initialize", DotNetObjectReference.Create(this));
        }

        public void Dispose()
        {
            JsRuntime!.InvokeVoidAsync("Connection.Dispose");
        }
    }
}
