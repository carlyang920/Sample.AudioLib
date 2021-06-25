using System;
using NAudio.Wave;
using Sample.AudioLib.AudioStreams;
using Sample.AudioLib.Interfaces;

namespace Sample.AudioLib.Players
{
    public class AudioPlayer : IAudioPlayer
    {
        private readonly WaveStream _reader;
        private readonly LoopStream _loop;
        private readonly WaveOutEvent _waveOut;

        public bool EnableLooping
        {
            get => _loop.EnableLooping;
            set => _loop.EnableLooping = value;
        }

        public AudioPlayer(WaveStream stream)
        {
            _reader = stream;
            _loop = new LoopStream(_reader);
            _waveOut = new WaveOutEvent();
        }

        ~AudioPlayer()
        {
            Dispose(false);
        }

        public void Play()
        {
            if (_waveOut.PlaybackState == PlaybackState.Stopped)
            {
                _loop.Position = 0;
                _waveOut.Init(_loop);
            }

            _waveOut.Play();
        }

        public void Stop()
        {
            _waveOut.Stop();
        }

        public void Pause()
        {
            _waveOut.Pause();
        }

        public bool IsStop()
        {
            if(_waveOut.PlaybackState == PlaybackState.Stopped)
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reader?.Dispose();
                _loop?.Dispose();
                _waveOut?.Dispose();
            }
        }
    }
}
