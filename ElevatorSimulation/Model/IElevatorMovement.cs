using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Model
{
    // Interface for elevator actions
    public interface IElevatorMovement
    {
        void MoveToFloor(Elevator elevator, int floor);
    }
}
