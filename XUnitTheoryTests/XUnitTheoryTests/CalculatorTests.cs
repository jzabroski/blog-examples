using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTheoryTests
{
    public class CalculatorTests
    {
        [Theory]
        [JsonFileData("all_data.json")]
        public void CanAddTheoryJsonFile(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("data.json", "AddData")]
        public void CanAddTheoryJsonFileFromProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [JsonFileData("data.json", "SubtractData")]
        public void CanSubtractTheoryJsonFileFromProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(value1, value2);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
            };

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };

            return allData.Take(numTests);
        }
    }
}

