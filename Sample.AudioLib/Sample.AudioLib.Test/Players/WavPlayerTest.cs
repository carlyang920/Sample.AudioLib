using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.AudioLib.Interfaces;
using Sample.AudioLib.Players;

namespace Sample.AudioLib.Test.Players
{
    [TestClass]
    public class WavPlayerTest
    {
        private readonly IAudioPlayer _player;

        public WavPlayerTest()
        {
            _player = new WavPlayer(@".\AudioFiles\alarm.wav");
        }

        ~WavPlayerTest()
        {
            _player.Dispose();
        }

        [TestMethod]
        [Description("Test audio play function.")]
        public void PlayTest()
        {
            try
            {
                _player.Play();

                //播放5秒鐘
                Thread.Sleep(3000);

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                Assert.IsTrue(false);
            }
            finally
            {
                _player.Stop();
            }
        }

        [TestMethod]
        [Description("Test audio stop function.")]
        public void StopTest()
        {
            try
            {
                _player.Play();

                //播放5秒鐘
                Thread.Sleep(3000);

                _player.Stop();

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        [Description("Test audio pause function.")]
        public void PauseTest()
        {
            try
            {
                _player.Play();

                //播放5秒鐘
                Thread.Sleep(3000);

                _player.Pause();

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                Assert.IsTrue(false);
            }
            finally
            {
                _player.Stop();
            }
        }

        [TestMethod]
        [Description("Test audio dispose function.")]
        public void DisposeTest()
        {
            try
            {
                _player.Dispose();

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                Assert.IsTrue(false);
            }
        }
    }
}
