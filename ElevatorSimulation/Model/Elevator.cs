using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Model
{
    public enum Direction
    {
        Up,
        Down,
        None
    }

    public class Elevator
    {
        public int ElevatorId { get; }
        public int CurrentFloor { get; set; }
        public Direction CurrentDirection { get; set; }
        public int NumberOfPeople { get; private set; }
        public int MaxCapacity { get; }

        private readonly IElevatorMovement elevatorMovement;

        public Elevator(int elevatorId, int maxCapacity, IElevatorMovement elevatorMovement)
        {
            ElevatorId = elevatorId;
            MaxCapacity = maxCapacity;
            CurrentFloor = 1;
            CurrentDirection = Direction.None;
            NumberOfPeople = 0;
            this.elevatorMovement = elevatorMovement;
        }

        public void MoveToFloor(int floor)
        {
            elevatorMovement.MoveToFloor(this, floor);
        }

        public void SetNumberOfPeople(int count)
        {
            NumberOfPeople = count;
        }
    }
}

