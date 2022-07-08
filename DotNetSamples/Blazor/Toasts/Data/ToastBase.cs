using System.Timers;
using Timer = System.Timers.Timer;

namespace Toasts.Data
{
    public enum ToastLevel
    {
        Success, 
        Fail
    }

    public class ToastBase : IDisposable
    {

        public event Action<string, ToastLevel> OnShow = default!;
        public event Action OnHide = default!;
        private Timer _timer = default!;


        public void ShowToast(string message, ToastLevel level)
        { 
            OnShow?.Invoke(message, level);
            StartCountDown();
        }

        public void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {          
            _timer?.Dispose();            
        }

        private void StartCountDown()
        {
            SetCountDown();

            if (_timer.Enabled)
            {
                _timer.Stop();
                _timer.Start();
            }
            else 
            {
                _timer.Start();
            }
        }

        private void SetCountDown()
        {
            if (_timer == null)
            {
                _timer = new Timer(3000);
                _timer.Elapsed += HideToast;
                _timer.AutoReset = false;
            }
        }
    }
}
