using Microsoft.AspNetCore.Components;

namespace Toasts.Data
{
    public class ToastComponent : ComponentBase, IDisposable
    {
        [Inject]
        public ToastBase ToastBase { get; set; } = default!;

        protected string Heading { get; private set; } = default!;
        protected string Message { get; set; } = default!;
        protected bool IsVisible { get; set; } = false;
        protected string BackgroundCssClass { get; set; } = default!;
        protected string IconCssClass { get; set; } = default!;


        protected override void OnInitialized()
        {
            ToastBase.OnShow += ShowToast;
            ToastBase.OnHide += HideToast;
        }

        private void ShowToast(string message, ToastLevel level)
        {
            BuildToastSettings(level, message);
            IsVisible = true;
            StateHasChanged();
        }

        private void HideToast()
        {
            IsVisible = false;
            StateHasChanged();
        }


        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Success:
                    BackgroundCssClass = "bg-success";
                    IconCssClass = "check";
                    Heading = "Success";
                    break;

                case ToastLevel.Fail:
                    BackgroundCssClass = "bg-danger";
                    IconCssClass = "times";
                    Heading = "Error";
                    break;

                default: break;
            }

            Message = message;
        }


        public void Dispose()
        {
            ToastBase.OnShow -= ShowToast;
            ToastBase.OnHide -= HideToast;

            ToastBase.Dispose();

        }
    }
}
