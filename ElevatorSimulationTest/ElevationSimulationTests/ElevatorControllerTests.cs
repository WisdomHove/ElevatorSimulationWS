using ElevatorSimulation.Controller;
using ElevatorSimulation.Model;
using Moq;

namespace ElevatorSimulationTest.ElevationSimulationTests
{
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
}
