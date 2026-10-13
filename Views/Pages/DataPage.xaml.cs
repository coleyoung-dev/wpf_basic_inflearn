using UiDesktopApp1.ViewModels.Pages;
using Wpf.Ui.Abstractions.Controls;
using System.ComponentModel;

namespace UiDesktopApp1.Views.Pages
{
    public partial class DataPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

        public DataPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AdminstrativeAgency":
                    this.searchGridLoadingControl.Visibility = Visibility.Collapsed;
                    this.searchGrid.Visibility = Visibility.Visible;
                    break;

                case "GangnamguPopulations":
                    this.dgGridLoadingControl.Visibility = Visibility.Collapsed;
                    this.dgGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
