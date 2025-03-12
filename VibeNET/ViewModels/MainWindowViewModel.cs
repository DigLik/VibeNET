using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace VibeNET.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _counter;

        [RelayCommand]
        private void Increment()
        {
            Counter++;
        }
    }
}
