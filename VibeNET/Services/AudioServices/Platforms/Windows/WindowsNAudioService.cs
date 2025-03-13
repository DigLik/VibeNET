using NAudio.Wave;
using System;
using VibeNET.Services.AudioServices.Abstract;

namespace VibeNET.Services.AudioServices.Platforms.Windows;
internal class WindowsNAudioService : IAudioService
{
    public TimeSpan Duration => _audioFileReader?.TotalTime ?? TimeSpan.Zero;
    public float Volume
    {
        get => _wasapiOut?.Volume ?? 0;
        set
        {
            if (_wasapiOut != null)
                _wasapiOut.Volume = value;
        }
    }

    private AudioFileReader? _audioFileReader;
    private WasapiOut? _wasapiOut;

    public void Play(string audioFile)
    {
        Dispose();
        _audioFileReader = new AudioFileReader(audioFile);
        _wasapiOut = new WasapiOut();
        _wasapiOut.Init(_audioFileReader);
        _wasapiOut.Play();
    }
    public void Stop()
    {
        Dispose();
    }
    public void Pause()
    {
        _wasapiOut?.Pause();
    }
    public void Resume()
    {
        _wasapiOut?.Play();
    }
    public void Dispose()
    {
        _audioFileReader?.Dispose();
        _wasapiOut?.Dispose();
    }
}
