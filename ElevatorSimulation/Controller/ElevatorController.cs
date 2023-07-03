using ElevatorSimulation.Model;

namespace ElevatorSimulation.Controller
{
    public class ElevatorController
    {
        private List<Elevator> elevators;

        public ElevatorController(int numberOfElevators, int maxCapacity, IElevatorMovement elevatorMovement)
        {
            elevators = new List<Elevator>();
            for (int i = 1; i <= numberOfElevators; i++)
            {
                elevators.Add(new Elevator(i, maxCapacity, elevatorMovement));
            }
        }

        public Elevator GetNearestAvailableElevator(int floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                int distance = Math.Abs(elevator.CurrentFloor - floor);
                if (distance < minDistance)
                {
                    nearestElevator = elevator;
                    minDistance = distance;
                }
            }

            return nearestElevator;
        }
    }
}
