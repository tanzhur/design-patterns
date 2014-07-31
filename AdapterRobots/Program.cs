using System;

namespace AdapterRobots
{
    static class Program
    {
        static void Main()
        {
            IEnemyAttacker rx7Tank = new EnemyTank();
            Robot fred = new Robot();
            IEnemyAttacker robotAdapter = new RobotAdapter(fred);

            Console.WriteLine("Robot");
            fred.Smash();
            fred.Walk();
            fred.ReactToHuman("Peter");
            Console.WriteLine();

            Console.WriteLine("Tank");
            rx7Tank.FireWeapon();
            rx7Tank.DriveForward();
            rx7Tank.AssignDriver("Julian");
            Console.WriteLine();

            Console.WriteLine("Robot Adapter");
            robotAdapter.FireWeapon();
            robotAdapter.DriveForward();
            robotAdapter.AssignDriver("Mark");
        }
    }

    /// <summary>
    /// Target interface
    /// </summary>
    public interface IEnemyAttacker
    {
        void FireWeapon();
        
        void DriveForward();
        
        void AssignDriver(String name);
    }

    /// <summary>
    /// Target
    /// </summary>
    public class EnemyTank : IEnemyAttacker
    {
        Random random = new Random();

        public void FireWeapon()
        {
            int attackDamage = random.Next(10) + 1;
            Console.WriteLine("Enemy tank does " + attackDamage + " damage");
        }

        public void DriveForward()
        {
            int distance = random.Next(5) + 1;
            Console.WriteLine("Enemy tank moves " + distance + " distance");
        }

        public void AssignDriver(String name)
        {
            Console.WriteLine("Driver name is " + name);
        }
    }


    /// <summary>
    /// Adaptee class
    /// </summary>
    public class Robot
    {
        private Random random = new Random();
        public void Smash()
        {
            int attackDamage = random.Next(10) + 1;
            Console.WriteLine("Enemy robot causes " + attackDamage + " damage.");
        }


        public void Walk()
        {
            int movement = random.Next(5) + 1;
            Console.WriteLine("Robot walks " + movement + " spaces.");
        }


        public void ReactToHuman(String name)
        {
            Console.WriteLine("Enemy robot Tramps on " + name);
        }
    }


    /// <summary>
    /// Adapter
    /// </summary>
    public class RobotAdapter : IEnemyAttacker
    {
        private Robot robot;

        public RobotAdapter(Robot robot)
        {
            this.robot = robot;
        }

        public void FireWeapon()
        {
            robot.Smash();
        }

        public void DriveForward()
        {
            robot.Walk();
        }

        public void AssignDriver(string name)
        {
            robot.ReactToHuman(name);
        }
    }
}