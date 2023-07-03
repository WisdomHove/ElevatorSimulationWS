using ElevatorSimulation.Model;

namespace ElevatorSimulationTest.ElevationSimulationTests
{
    [TestClass]
    public class ElevatorMovementTests
    {
        private Elevator elevator;
        private IElevatorMovement elevatorMovement;

        [TestInitialize]
        public void SetUp()
        {
            elevator = new Elevator(1, 5, new ElevatorMovement());
            elevatorMovement = (IElevatorMovement)elevator;
        }

        [TestMethod]
        public void MoveToFloor_ShouldChangeCurrentFloorAndDirection_WhenMovingUp()
        {
            int floor = 3;

            elevatorMovement.MoveToFloor(elevator, floor);

            Assert.AreEqual(floor, elevator.CurrentFloor);
            Assert.AreEqual(Direction.None, elevator.CurrentDirection);
        }

        [TestMethod]
        public void MoveToFloor_ShouldChangeCurrentFloorAndDirection_WhenMovingDown()
        {
            int floor = 1;

            elevator.CurrentFloor = 3; // Start at floor 3

            elevatorMovement.MoveToFloor(elevator, floor);

            Assert.AreEqual(floor, elevator.CurrentFloor);
            Assert.AreEqual(Direction.None, elevator.CurrentDirection);
        }
    }
}
