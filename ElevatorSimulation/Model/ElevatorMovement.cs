using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ElevatorSimulation.Model
{
    public class ElevatorMovement : IElevatorMovement
    {
        public void MoveToFloor(Elevator elevator, int floor)
        {
            if (elevator.CurrentFloor < floor)
            {
                elevator.CurrentDirection = Direction.Up;
                for (int i = elevator.CurrentFloor; i <= floor; i++)
                {
                    Console.WriteLine($"Elevator {elevator.ElevatorId} moving up to floor {i}...");
                    elevator.CurrentFloor = i;
                }
            }
            else if (elevator.CurrentFloor > floor)
            {
                elevator.CurrentDirection = Direction.Down;
                for (int i = elevator.CurrentFloor; i >= floor; i--)
                {
                    Console.WriteLine($"Elevator {elevator.ElevatorId} moving down to floor {i}...");
                    elevator.CurrentFloor = i;
                }
            }

            elevator.CurrentDirection = Direction.None;
            Console.WriteLine($"Elevator {elevator.ElevatorId} has arrived at floor {elevator.CurrentFloor}.");
        }
    }
}
