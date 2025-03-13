using System;

namespace VibeNET.Services.AudioServices.Abstract;
internal interface IAudioService
{
    TimeSpan Duration { get; }
    float Volume { get; set; }

    void Play(string audioFile);
    void Stop();
    void Pause();
    void Resume();
    void Dispose();
}
