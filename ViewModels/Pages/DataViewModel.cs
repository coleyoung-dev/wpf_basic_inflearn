using Microsoft.EntityFrameworkCore.Storage;
using System.Windows.Media;
using UiDesktopApp1.Models;
using Wpf.Ui.Abstractions.Controls;
using UiDesktopApp1.Interfaces;
using UiDesktopApp1.Services;

namespace UiDesktopApp1.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        private readonly IDatabase<GangnamguPopulation>? _iDatabase;
        public DataViewModel(IDatabase<GangnamguPopulation>? iDatabase)
        {
            this._iDatabase = iDatabase;
        }

        [ObservableProperty]
        private IEnumerable<DataColor> _colors;
        [ObservableProperty]
        private IEnumerable<GangnamguPopulation>? _gangnamguPopulations;
        [ObservableProperty]
        private IEnumerable<string>? _adminstrativeAgency;

        [ObservableProperty]
        private string _selectedAdministrativeAgency = string.Empty;

        public Task OnNavigatedToAsync()
        {
            if (!_isInitialized)
                InitializeViewModel();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private void InitializeViewModel()
        {
            this.GangnamguPopulations = _iDatabase?.Get();
            this.AdminstrativeAgency = _gangnamguPopulations?.Select(x => x?.AdministrativeAgency);
            _isInitialized = true;
        }
    }
}
