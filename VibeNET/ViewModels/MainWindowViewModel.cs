using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VibeNET.Services.AudioServices;
using VibeNET.Services.AudioServices.Abstract;

namespace VibeNET.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _audioFilePath;

        private readonly IAudioService _audioService = AudioServiceFactory.CreateAudioService();

        [RelayCommand]
        private void Play()
        {
            if (AudioFilePath is null)
                return;
            _audioService.Play(AudioFilePath.Trim('"'));
        }

        [RelayCommand]
        private void Stop()
        {
            _audioService.Stop();
        }

        [RelayCommand]
        private void Pause()
        {
            _audioService.Pause();
        }

        [RelayCommand]
        private void Resume()
        {
            _audioService.Resume();
        }
    }
}
