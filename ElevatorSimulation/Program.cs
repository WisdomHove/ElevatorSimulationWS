using ElevatorSimulation.Controller;
using ElevatorSimulation.Model;

namespace ElevatorSimulation
{

    public class Program
    {
        private static ElevatorController elevatorController;

        static void Main(string[] args)
        {
            IElevatorMovement elevatorMovement = new ElevatorMovement();
            // Create elevator controller with 3 elevators, each with a max capacity of 5 people
            elevatorController = new ElevatorController(3, 5, elevatorMovement);

            // Set the number of people waiting on each floor
            Dictionary<int, int> peopleWaiting = new Dictionary<int, int>()
            {
                { 1, 3 },
                { 2, 0 },
                { 3, 2 },
                { 4, 1 },
                // Add more floors and people if needed
            };

            // Simulate elevator operations
            foreach (var entry in peopleWaiting)
            {
                int floor = entry.Key;
                int numberOfPeople = entry.Value;

                Elevator elevator = elevatorController.GetNearestAvailableElevator(floor);
                if (elevator != null)
                {
                    elevator.SetNumberOfPeople(numberOfPeople);
                    elevator.MoveToFloor(floor);
                }
                else
                {
                    Console.WriteLine("No available elevator. Please wait.");
                }
            }

            Console.WriteLine("Simulation completed.");
            Console.WriteLine();


            // Interactive menu to interact with elevators
            Console.WriteLine("Interactive Menu:");
            Console.WriteLine("1. Call elevator to a specific floor");
            Console.WriteLine("2. Set the number of people waiting on a floor");
            Console.WriteLine("3. Exit");

            bool exit = false;
            while (!exit)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CallElevator();
                        break;
                    case "2":
                        SetPeopleWaiting();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CallElevator()
        {
            Console.Write("Enter the floor number: ");
            int floor = Convert.ToInt32(Console.ReadLine());

            Elevator elevator = elevatorController.GetNearestAvailableElevator(floor);
            if (elevator != null)
            {
                Console.WriteLine($"Elevator {elevator.ElevatorId} is arriving at floor {floor}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No available elevator. Please wait.");
                Console.WriteLine();
            }
        }

        static void SetPeopleWaiting()
        {
            Console.Write("Enter the floor number: ");
            int floor = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of people waiting: ");
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());

            Elevator elevator = elevatorController.GetNearestAvailableElevator(floor);
            if (elevator != null)
            {
                elevator.SetNumberOfPeople(numberOfPeople);
                Console.WriteLine($"Number of people waiting on floor {floor} set to {numberOfPeople}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No available elevator. Please wait.");
                Console.WriteLine();
            }
        }

    }
}
