using System;
using EasyKey.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyKey.BL.Test
{
    [TestClass]
    public class StringManagerTest
    {
        [TestMethod]
        public void ValidatePasswordValidTest()
        {
            var password = "Password0";
            var expected = true;

            var actual = StringManager.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The password cannot be empty.")]
        public void ValidatePasswordInvalidEmptyTest()
        {
            var password = "";
            var actual = StringManager.ValidatePassword(password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The password must contain atleast one Uppercase letter.")]
        public void ValidatePasswordInvalidNoUppercaseTest()
        {
            var password = "password0";

            var actual = StringManager.ValidatePassword(password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The password must contain atleast one number.")]
        public void ValidatePasswordInvalidNoNumberTest()
        {
            var password = "Password";
            
            var actual = StringManager.ValidatePassword(password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The password must have atleast 8 characters.")]
        public void ValidatePasswordInvalidNoCorrectLenghtTest()
        {
            var password = "Passwor";

            var actual = StringManager.ValidatePassword(password);
        }

        public void ValidateGenerateIDTest()
        {
            var expectedDifferent = StringManager.GenerateID();
            var actual = StringManager.GenerateID();

            Assert.AreNotEqual(expectedDifferent, actual);
        }
    }
}
