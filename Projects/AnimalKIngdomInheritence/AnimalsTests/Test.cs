using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalKIngdomApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AnimalsTests
{
    [TestClass]
    public class AnimalInheritanceTests
    {

        //TESTING ANIMAL SOUNDS
        [TestMethod]
        public void Bird_MakeSound_ReturnsCorrectSound()
        {
            //Arrange
            var bird = new Bird("Parrot", 5);
            var expectedSound = "Parrot chirps.";

            //Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); 
                //Makes it so Console.Write writes to sw instead of the console. allows you to do stuff such as log what is said

                bird.MakeSound(); //Runs the method for the StringWriter to collect lines basically

                var result = sw.ToString().Trim(); //Trim removes excessive lines

                Assert.AreEqual(expectedSound, result);
            } 
        }

        [TestMethod]
        public void Fish_MakeSound_ReturnsCorrectSound()
        {
            //Arrange
            var fish = new Fish("Goldfish", 1);
            var expectedSound = "Goldfish bubbles.";

            //Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fish.MakeSound();

                //Assert
                var result = sw.ToString().Trim();
                Assert.AreEqual(expectedSound, result);
            }
        }

        //TESTING CORRECT VALUES
        [TestMethod]
        public void Bird_InitializeWithCorrectValues()
        {
            //Arrange
            var bird = new Bird("Parrot", 5);

            //Act and Assert
            Assert.AreEqual("Parrot", bird.Name); //enter the expected value, then the vlaue for better read maintainability
            Assert.AreEqual(5, bird.Age); 
        }

        [TestMethod]
        public void Fish_InitializeWithCorrectValues()
        {
            //Arrange
            var fish = new Fish("Goldfish", 1);

            //Act and Assert
            Assert.AreEqual("Goldfish", fish.Name); //enter the expected value, then the vlaue for better read maintainability
            Assert.AreEqual(1, fish.Age);
        }
    }
}
