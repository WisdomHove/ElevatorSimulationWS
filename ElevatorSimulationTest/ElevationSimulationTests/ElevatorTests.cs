using ElevatorSimulation.Model;
using Moq;


namespace ElevatorSimulationTest.ElevationSimulationTests
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
}
