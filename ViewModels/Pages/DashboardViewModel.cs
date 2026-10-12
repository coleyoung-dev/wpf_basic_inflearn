using UiDesktopApp1.Interfaces;

namespace UiDesktopApp1.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly IDateTime _iDateTime;
        [ObservableProperty]
        private int _counter = 0;
        [ObservableProperty]
        private string? _currentTime = string.Empty;

        public DashboardViewModel(IDateTime dateTime)
        {
            this._iDateTime = dateTime;
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }
        [RelayCommand]
        private void OnTextChanged()
        {
            CurrentTime = _iDateTime.GetCurrentTime()?.ToString();
        }
    }
}
