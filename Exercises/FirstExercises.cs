using System;
using System.Linq;
using ExercisesPlayground;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class FirstExercises
    {
        private Random _random;

        public FirstExercises()
        {
            _random = new Random(DateTime.UtcNow.Millisecond);
        }

        [Fact]
        public void ExerciseOneTest()
        {
            // Arrange
            var toBeTested = new[] {1, 2, 3, 4};
            var expected = new[] {2, 4, 6, 8};

            var randomTestCount = _random.Next(0, 10000);
            var randomArrayToTest = Enumerable.Range(0, randomTestCount)
                .Select(x => _random.Next(0, 10000))
                .ToArray();

            // Act
            var actual = ExerciseOne.Exercise(toBeTested.ToArray());
            var variableActual = ExerciseOne.Exercise(randomArrayToTest.ToArray());

            // Assert
            expected.Zip(actual)
                .Select(firstAndSecond => firstAndSecond.First == firstAndSecond.Second)
                .Should().AllBeEquivalentTo(true);
            randomArrayToTest.Zip(variableActual)
                .Select(firstAndSecond => firstAndSecond.First * 2 == firstAndSecond.Second)
                .Should().AllBeEquivalentTo(true);
        }
    }
}