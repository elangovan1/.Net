using NUnit.Framework;
using PMS.Utility.Validation;
using System;

namespace PMS.Utility.Test.Validation
{

    [TestFixture]
    public class EnsureTests
    {
        [Test]        
        public void Ensure_IsNotNullMethod_Returns_ArgumentNullException_When_InputIsNull()
        {
            string input = null;
            var exception = Assert.Throws<ArgumentNullException>(()=>Ensure.IsNotNull(input, nameof(input)));            
            Assert.AreEqual("Argument input cannot be null.", exception.Message);
        }
        [Test]
        public void Ensure_IsNotNullMethod_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            string input = "FakeValue";
            Ensure.IsNotNull(input, nameof(input));            
        }
        [Test]
        [TestCase(null)]        
        [TestCase("")]
        public void Ensure_IsNotNullOrEmpty_Returns_ArgumentNullException_When_InputIsNull(string input)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Ensure.IsNotNullOrEmpty(input, nameof(input)));            
            Assert.AreEqual("Argument input cannot be null or empty.", exception.Message);
        }
        [Test]
        public void Ensure_IsNotNullOrEmpty_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            string input = "FakeValue";
            Ensure.IsNotNullOrEmpty(input, nameof(input));
        }
        [Test]
        public void Ensure_IsNullOrWhiteSpace_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            string input = "FakeValue";
            Ensure.IsNullOrWhiteSpace(input, nameof(input));
        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void Ensure_IsNullOrWhiteSpace_Returns_ArgumentNullException_When_InputIsNull(string input)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Ensure.IsNullOrWhiteSpace(input, nameof(input)));            
            Assert.AreEqual("Argument input cannot be null or whitespace.", exception.Message);
        }
        [Test]
        public void Ensure_IsNotZero_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            int input = 1;
            Ensure.IsNotZero(input, nameof(input));
        }
        [Test]
        public void Ensure_IsNotZero_ShuldNotReturn_ArgumentNullException_When_InputIsInvalid()
        {
            int input = 0;
            var exception = Assert.Throws<ArgumentException>(() => Ensure.IsNotZero(input, nameof(input)));            
            Assert.AreEqual("Argument input cannot be zero.", exception.Message);
        }
        [Test]
        public void Ensure_IsLessThan_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            int input = 10;
            Ensure.IsLessThan(20, input, nameof(input));
        }
        [Test]
        public void Ensure_IsLessThan_ShuldNotReturn_ArgumentNullException_When_InputIsInvalid()
        {
            int input = 20;
            var exception = Assert.Throws<ArgumentException>(() => Ensure.IsLessThan(10, input, nameof(input)));
            Assert.AreEqual("Argument input cannot exceed.", exception.Message);
        }
        [Test]
        public void Ensure_IsMoreThan_ShuldNotReturn_ArgumentNullException_When_InputIsValid()
        {
            int input = 10;
            Ensure.IsMoreThan(5, input, nameof(input));
        }
        [Test]
        public void Ensure_IsMoreThan_ShuldNotReturn_ArgumentNullException_When_InputIsInvalid()
        {
            int input = 0;
            var exception = Assert.Throws<ArgumentException>(() => Ensure.IsMoreThan(10, input, nameof(input)));
            Assert.AreEqual("Argument input cannot be lower than 10.", exception.Message);
        }
    }
}
