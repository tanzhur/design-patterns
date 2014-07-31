using System;

namespace Command___Electronic_Device
{
    class Program
    {
        static void Main(string[] args)
        {
            IElectronicDevice device = TVRemoteControl.getDevice();

            var onCommand = new TurnTVOn(device);
            var offCommand = new TurnTVOff(device);
            var volumeUpCommand = new TurnTVVolumeUp(device);
            var volumeDownCommand = new TurnTVVolumeDown(device);

            var onButton = new DeviceButton(onCommand);
            onButton.Press();

            var upButton = new DeviceButton(volumeUpCommand);
            upButton.Press();
            upButton.Press();
            upButton.Press();
            upButton.Press();

            var downButton = new DeviceButton(volumeDownCommand);
            downButton.Press();
            downButton.Press();

            var offButton = new DeviceButton(offCommand);
            offButton.Press();
            offButton.Undo();
            offButton.Press();
        }
    }

    /// <summary>
    /// Receiver interface
    /// </summary>
    public interface IElectronicDevice
    {
        void On();

        void Off();

        void TurnVolumeUp();

        void TurnVolumeDown();
    }


    /// <summary>
    /// Receiver concrete class
    /// </summary>
    public class TV : IElectronicDevice
    {
        private int volume = 0;

        public void On()
        {
            Console.WriteLine("Tv is on.");
        }

        public void Off()
        {
            Console.WriteLine("Tv is off.");
        }

        public void TurnVolumeUp()
        {
            volume++;
            Console.WriteLine("TV volume is at " + volume + ".");
        }

        public void TurnVolumeDown()
        {
            volume--;
            Console.WriteLine("TV volume is at " + volume + ".");
        }
    }


    public interface Command
    {
        void Execute();

        void Undo();
    }

    public class TurnTVOn : Command
    {
        private IElectronicDevice device;

        public TurnTVOn(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.On();
        }

        public void Undo()
        {
            this.device.Off();
        }
    }

    public class TurnTVOff : Command
    {
        private IElectronicDevice device;

        public TurnTVOff(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.Off();
        }

        public void Undo()
        {
           this.device.On();
        }
    }

    public class TurnTVVolumeUp : Command
    {
        private IElectronicDevice device;

        public TurnTVVolumeUp(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.TurnVolumeUp();
        }

        public void Undo()
        {
            this.device.TurnVolumeDown();
        }
    }

    public class TurnTVVolumeDown : Command
    {
        private IElectronicDevice device;

        public TurnTVVolumeDown(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.TurnVolumeDown();
        }

        public void Undo()
        {
            this.device.TurnVolumeUp();
        }
    }


    /// <summary>
    /// Invoker
    /// </summary>
    public class DeviceButton
    {
        private Command command;

        public DeviceButton(Command command)
        {
            this.command = command;
        }

        public void Press()
        {
            this.command.Execute();
        }

        public void Undo()
        {
            this.command.Undo();
        }
    }

    public class TVRemoteControl
    {
        public static IElectronicDevice getDevice()
        {
            return new TV();
        }
    }
}
