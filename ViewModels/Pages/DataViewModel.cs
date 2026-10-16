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
        #region FIELDS
        private bool isInitialized = false;
        private readonly IDatabase<GangnamguPopulation>? iDatabase;
        #endregion

        #region PROPERTIES
        [ObservableProperty] private IEnumerable<DataColor> colors;
        [ObservableProperty] private IEnumerable<GangnamguPopulation>? gangnamguPopulations;
        [ObservableProperty] private IEnumerable<string?> adminstrativeAgency;
        [ObservableProperty] private string selectedAdministrativeAgency = string.Empty;
        #endregion

        #region CONSTRUCTOR
        public DataViewModel(IDatabase<GangnamguPopulation>? iDatabase)
        {
            this.iDatabase = iDatabase;
        }
        #endregion

        #region COMMANDS
        #endregion

        #region METHODS
        public Task OnNavigatedToAsync()
        {
            if (!isInitialized)
                InitializeViewModelAsync();

            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync() => Task.CompletedTask;

        private async Task InitializeViewModelAsync()
        {
            this.GangnamguPopulations = await Task.Run(() => this.iDatabase?.Get());

            if (this.GangnamguPopulations != null)
            {
                this.AdminstrativeAgency = gangnamguPopulations?.Select(x => x?.AdministrativeAgency).ToList();
            }
            isInitialized = true;
        }
        #endregion
        


    }
}
