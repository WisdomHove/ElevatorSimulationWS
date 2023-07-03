using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorSimulation.Controller;
using ElevatorSimulation.Model;
using Moq;

namespace ElevatorSimulation.Tests
{
    [TestClass]
    public class ElevatorTests
    {
        private Mock<IElevatorMovement> elevatorMovementMock;
        private Elevator elevator;

        [TestInitialize]
        public void SetUp()
        {
            elevatorMovementMock = new Mock<IElevatorMovement>();
            elevator = new Elevator(1, 5, elevatorMovementMock.Object);
        }

        [TestMethod]
        public void MoveToFloor_ShouldCallElevatorMovement_MoveToFloor()
        {
            int floor = 3;

            elevator.MoveToFloor(floor);

            elevatorMovementMock.Verify(em => em.MoveToFloor(elevator, floor), Times.Once);
        }

        [TestMethod]
        public void SetNumberOfPeople_ShouldSetNumberOfPeople()
        {
            int count = 3;

            elevator.SetNumberOfPeople(count);

            Assert.AreEqual(count, elevator.NumberOfPeople);
        }
    }

    [TestClass]
    public class ElevatorControllerTests
    {
        private ElevatorController elevatorController;
        private Mock<IElevatorMovement> elevatorMovementMock;
        private Elevator elevator1;
        private Elevator elevator2;

        [TestInitialize]
        public void SetUp()
        {
            elevatorMovementMock = new Mock<IElevatorMovement>();
            elevatorController = new ElevatorController(2, 5, elevatorMovementMock.Object);
            elevator1 = elevatorController.GetNearestAvailableElevator(1);
            elevator2 = elevatorController.GetNearestAvailableElevator(2);
        }

        [TestMethod]
        public void GetNearestAvailableElevator_WithMultipleElevators_ShouldReturnNearestElevator()
        {
            var nearestElevator = elevatorController.GetNearestAvailableElevator(2);

            Assert.AreEqual(elevator2, nearestElevator);
        }

        [TestMethod]
        public void GetNearestAvailableElevator_WithNoAvailableElevators_ShouldReturnNull()
        {
            elevator1.MoveToFloor(3); // Occupying elevator1

            var nearestElevator = elevatorController.GetNearestAvailableElevator(1);

            Assert.IsNull(nearestElevator);
        }
    }

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
