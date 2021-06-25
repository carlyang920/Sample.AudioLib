using System;

namespace Sample.AudioLib.Interfaces
{
    public interface IAudioPlayer : IDisposable
    {
        bool EnableLooping { get; set; }

        void Play();
        void Stop();
        void Pause();
    }
}
