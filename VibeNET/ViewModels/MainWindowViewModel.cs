using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VibeNET.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _folderPath = string.Empty;

        [ObservableProperty]
        private List<string> _folderItems = [];

        [RelayCommand]
        private async Task PickFolder()
        {
            var folderPickerOptions = new FolderPickerOpenOptions
            {
                Title = "Выберите папку",
                AllowMultiple = false
            };

            // Открываем диалог выбора папки через StorageProvider окна
            var selectedFolders = await new Window().StorageProvider.OpenFolderPickerAsync(folderPickerOptions);

            if (selectedFolders != null && selectedFolders.Any())
            {
                // Получаем путь к первой выбранной папке
                var folderPath = selectedFolders[0].Path.LocalPath;
                FolderPath = folderPath;

                // Получаем список файлов и папок в выбранной папке
                var folderItems = Directory.GetFileSystemEntries(folderPath);
                FolderItems = [.. folderItems.Select(item => Path.GetFileName(item))];
            }
            else
            {
                FolderPath = "Папка не выбрана";
            }
        }
    }
}
