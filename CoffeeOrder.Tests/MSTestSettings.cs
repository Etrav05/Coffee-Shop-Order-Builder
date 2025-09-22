[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class OrderValidatorTests
    {
        [TestMethod]
        public void Validate_MissingBase_ReturnsInvalid()
        {
            // Arrange
            var order = new Order(); // Assume Order is in CoffeeOrder project
            var validator = new OrderValidator();

            // Act
            var result = validator.Validate(order);

            // Assert
            Assert.IsFalse(result.IsValid);
        }
    }
}
