using System;

namespace Builder___Robot
{
    static class BuilderExampleRobot
    {
        static void Main()
        {
            var shop = new Shop();
            var oldRobotBuilder = new OldRobotBuilder();

            shop.Construct(oldRobotBuilder);
            var robot = oldRobotBuilder.GetResult();
            robot.Show();
        }
    }

    /// <summary>
    /// Director
    /// </summary>
    public class Shop
    {
        public void Construct(RobotBuilder robotBuilder)
        {
            robotBuilder.BuildHead();
            robotBuilder.BuildTorso();
            robotBuilder.BuildLegs();
            robotBuilder.BuildArms();
        }
    }

    /// <summary>
    /// Product
    /// </summary>
    public class Robot
    {
        private string head;
        private string torso;
        private string arms;
        private string legs;

        public string Head
        {
            get { return head; }
            set { head = value; }
        }

        public string Torso
        {
            get { return torso; }
            set { torso = value; }
        }

        public string Arms
        {
            get { return arms; }
            set { arms = value; }
        }

        public string Legs
        {
            get { return legs; }
            set { legs = value; }
        }

        public void Show()
        {
            Console.WriteLine("Head: {0}", this.Head);
            Console.WriteLine("Torso: {0}", this.Torso);
            Console.WriteLine("Arms: {0}", this.Arms);
            Console.WriteLine("Legs: {0}", this.Legs);
        }
    }

    /// <summary>
    /// Abstract builder
    /// </summary>
    public abstract class RobotBuilder
    {
        public abstract void BuildHead();

        public abstract void BuildTorso();

        public abstract void BuildLegs();

        public abstract void BuildArms();

        public abstract Robot GetResult();
    }

    /// <summary>
    /// Concrete builder
    /// </summary>
    public class OldRobotBuilder : RobotBuilder
    {
        private Robot robot;

        public OldRobotBuilder()
        {
            this.robot = new Robot();
        }

        public override void BuildHead()
        {
            this.robot.Head = "Tin head";
        }

        public override void BuildTorso()
        {
            this.robot.Torso = "Tin torso";
        }

        public override void BuildLegs()
        {
            this.robot.Legs = "Tin legs";
        }

        public override void BuildArms()
        {
            this.robot.Arms = "Tin arms";
        }

        public override Robot GetResult()
        {
            return robot;
        }
    }
}