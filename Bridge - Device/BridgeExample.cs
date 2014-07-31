using System;

namespace Bridge___Device
{
    static class BridgeExample
    {
        private static void Main()
        {
            Remote muteRemote = new TvRemoteMute(new Television(200));
            Console.WriteLine("Remote with mute.");
            muteRemote.ButtonSixPressed();
            muteRemote.ButtonSevenPressed();
            muteRemote.ButtonSevenPressed();
            muteRemote.ButtonSevenPressed();
            muteRemote.ButtonSevenPressed();
            muteRemote.ButtonSevenPressed();
            muteRemote.ButtonSixPressed();
            muteRemote.ButtonEightPressed();
            muteRemote.ButtonEightPressed();
            muteRemote.ButtonFivePressed();
            muteRemote.ButtonNinePressed();
            muteRemote.ShowInfo();
            Console.WriteLine();

            Console.WriteLine("Remote with pause.");
            Remote pauseRemote = new TvRemotePause(new Television(200));
            pauseRemote.ButtonSixPressed();
            pauseRemote.ButtonSixPressed();
            pauseRemote.ButtonSixPressed();
            pauseRemote.ButtonSevenPressed();
            pauseRemote.ButtonSevenPressed();
            pauseRemote.ButtonSevenPressed();
            pauseRemote.ButtonSevenPressed();
            pauseRemote.ButtonSevenPressed();
            pauseRemote.ButtonEightPressed();
            pauseRemote.ButtonEightPressed();
            pauseRemote.ButtonEightPressed();
            pauseRemote.ButtonSixPressed();
            pauseRemote.ButtonSixPressed();
            pauseRemote.ButtonNinePressed();
            pauseRemote.ButtonFivePressed();
            pauseRemote.ShowInfo();
        }
    }

    public abstract class EntertainmentDevice
    {
        private int channel;
        private int volume;

        protected EntertainmentDevice(int maxVolume)
        {
            this.Channel = 1;
            this.MaxVolume = maxVolume;
            this.Volume = 0;
        }

        protected int Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        private int MaxVolume { get; set; }

        private int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                if (value < 0)
                {
                    this.volume = 0;
                }
                else if (value > this.MaxVolume)
                {
                    this.volume = this.MaxVolume;
                }
                else
                {
                    this.volume = value;
                }

            }
        }

        public abstract void ButtonFivePressed();

        public abstract void ButtonSixPressed();

        public void GetState()
        {
            Console.WriteLine("Channel {0}", this.Channel);
            Console.WriteLine("Volume {0}", this.Volume);
        }

        public void ButtonSevenPressed()
        {
            this.Volume++;
            Console.WriteLine("Volume at level {0}.", this.Volume);
        }

        public void ButtonEightPressed()
        {
            this.Volume--;
            Console.WriteLine("Volume at level {0}.", this.Volume);
        }
    }

    public class Television : EntertainmentDevice
    {
        public Television(int maxVolume)
            : base(maxVolume)
        {
        }

        public override void ButtonFivePressed()
        {
            Console.WriteLine("Channel down.");
            this.Channel--;
        }

        public override void ButtonSixPressed()
        {
            Console.WriteLine("Channel up.");
            this.Channel++;
        }
    }

    public abstract class Remote
    {
        private readonly EntertainmentDevice device;

        protected Remote(EntertainmentDevice device)
        {
            this.device = device;
        }


        public void ButtonFivePressed()
        {
            this.device.ButtonFivePressed();
        }

        public void ButtonSixPressed()
        {
            this.device.ButtonSixPressed();
        }

        public void ButtonSevenPressed()
        {
            this.device.ButtonSevenPressed();
        }

        public void ButtonEightPressed()
        {
            this.device.ButtonEightPressed();
        }

        public void ShowInfo()
        {
            this.device.GetState();
        }

        public abstract void ButtonNinePressed();
    }


    public class TvRemoteMute : Remote
    {
        public TvRemoteMute(EntertainmentDevice device)
            : base(device)
        {
        }

        public override void ButtonNinePressed()
        {
            Console.WriteLine("TV was muted.");
        }
    }


    public class TvRemotePause : Remote
    {
        public TvRemotePause(EntertainmentDevice device)
            : base(device)
        {
        }

        public override void ButtonNinePressed()
        {
            Console.WriteLine("TV was paused.");
        }
    }
}
