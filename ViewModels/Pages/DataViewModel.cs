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
        [ObservableProperty] private int? seletedTotalPopuplation;
        [ObservableProperty] private int? seletedMalePopulation;
        [ObservableProperty] private int? selectedFeMalePopulation;
        [ObservableProperty] private double? selectedSexRatio;

        [ObservableProperty] private int? selectedNumberOfHouseholds;
        [ObservableProperty] private double? selectedNumberOfPeoplePerHouseholds;

        #endregion

        #region CONSTRUCTOR
        public DataViewModel(IDatabase<GangnamguPopulation>? iDatabase)
        {
            this.iDatabase = iDatabase;
        }
        #endregion

        #region COMMANDS
        [RelayCommand]
        private void CreateNewData()
        {
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation();
            gangnamguPopulation.AdministrativeAgency = this.SelectedAdministrativeAgency;
            gangnamguPopulation.TotalPopulation = this.SeletedTotalPopuplation;
            gangnamguPopulation.MalePopulation = this.SeletedMalePopulation;
            gangnamguPopulation.FemalePopulation = this.SelectedFeMalePopulation;
            gangnamguPopulation.SexRatio = this.SelectedSexRatio;
            gangnamguPopulation.NumberOfHouseholds = this.SelectedNumberOfHouseholds;
            gangnamguPopulation.NumberOfPeoplePerHousehold = this.SelectedNumberOfPeoplePerHouseholds;
            this.iDatabase?.Create(gangnamguPopulation);
        }
        [RelayCommand]
        private void ReadAllData()
        {
            this.GangnamguPopulations = this.iDatabase?.Get();
            //this.GangnamguPopulations = await Task.Run(() => this.iDatabase?.Get());
        }
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
