using System;
using System.Runtime.InteropServices;
using VibeNET.Services.AudioServices.Abstract;
using VibeNET.Services.AudioServices.Platforms.Windows;

namespace VibeNET.Services.AudioServices;
internal static class AudioServiceFactory
{
    public static IAudioService CreateAudioService()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return new WindowsNAudioService();
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            throw new PlatformNotSupportedException("Linux platform not supported");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            throw new PlatformNotSupportedException("OSX platform not supported");
        else
            throw new PlatformNotSupportedException("Unknown platform");
    }
}
