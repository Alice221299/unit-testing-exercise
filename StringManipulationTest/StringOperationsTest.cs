using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip = "Right now this is not valid")]
        public void ConcatenateStrings()
        {
            //Arrange
            var strOperation = new StringOperations();

            //Act
            var result = strOperation.ConcatenateStrings("Hello", "World");

            //Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal("Hello World", result);

        }

        [Fact]
        public void IsPalindrome_True()
        {
            var strOperation = new StringOperations();
            var result = strOperation.IsPalindrome("tenet");
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            var strOperation = new StringOperations();
            var result = strOperation.IsPalindrome("apple");
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var strOperation = new StringOperations();
            var result = strOperation.QuantintyInWords("apple", 6);

            Assert.StartsWith("six", result);
            Assert.Contains("apple", result, StringComparison.Ordinal);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperation = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperation.GetStringLength(null));
        }

        [Theory]
        [InlineData("Apple", 5)]
        [InlineData("I am Tired", 10)]
        public void GetStringLength(string receivedString, int shownNumber)
        {
            var strOperation = new StringOperations();
            var result = strOperation.GetStringLength(receivedString);

            Assert.Equal(shownNumber, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var moqLogger = new Mock<ILogger<StringOperations>>();
            var strOperation = new StringOperations(moqLogger.Object);
            
            var result = strOperation.CountOccurrences("Hello world", 'o');

            Assert.Equal(2, result);
        }

        [Fact]
        public void ReadFile()
        {
            var moqFileReader = new Mock<IFileReaderConector>();
            moqFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");
            var strOperation = new StringOperations();

            var result = strOperation.ReadFile(moqFileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);
        }

        [Fact]
        public void FromRomanToNumber()
        {
            var strOperation = new StringOperations();

            var result = strOperation.FromRomanToNumber("V");

            Assert.Equal(5, result);
        }

        [Fact]
        public void Pluralize()
        {
            var strOperation = new StringOperations();

            var result = strOperation.Pluralize("cat");

            Assert.Equal("cats", result);
        }

        [Fact]
        public void ReverseString()
        {
            var strOperation = new StringOperations();

            var result = strOperation.ReverseString("apple");

            Assert.Equal("elppa", result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperation = new StringOperations();

            var result = strOperation.RemoveWhitespace("Hello world, Anna here");

            Assert.Equal("Helloworld,Annahere", result);
        }

        [Fact]
        public void TruncateString_Correct()
        {
            var strOperation = new StringOperations();

            var result = strOperation.TruncateString("Hello world, Anna here", 5);

            Assert.Equal("Hello", result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperation = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperation.TruncateString("Hello world, Anna here", 0));
        }

        [Fact]
        public void TruncateString_BadInput()
        {
            var strOperation = new StringOperations();

            var result = strOperation.TruncateString("Hello world, Anna here", 200);

            Assert.Equal("Hello world, Anna here", result);
        }
    }
}
