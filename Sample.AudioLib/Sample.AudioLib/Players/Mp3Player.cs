using NAudio.Wave;

namespace Sample.AudioLib.Players
{
    public class Mp3Player : AudioPlayer
    {
        public Mp3Player(string filePath) : base(new Mp3FileReader(filePath))
        {

        }

        ~Mp3Player()
        {
            Dispose(true);
        }
    }
}
