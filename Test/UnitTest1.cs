using NUnit.Framework;
using DataGridPlayground.ViewModel;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var sut = new AddNewEmployeeViewModel();

            Assert.That(sut.AddNumbers(2, 3), Is.EqualTo(5));
        }
    }
}