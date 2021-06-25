using NAudio.Wave;

namespace Sample.AudioLib.Players
{
    public class WavPlayer : AudioPlayer
    {
        public WavPlayer(string filePath) : base(new WaveFileReader(filePath))
        {
            
        }

        ~WavPlayer()
        {
            Dispose(true);
        }
    }
}
