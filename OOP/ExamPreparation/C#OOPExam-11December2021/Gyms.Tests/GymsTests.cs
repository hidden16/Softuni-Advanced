using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Constructor_If_Name_Is_Null_Or_Empty_Should_Throw_ArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 15);
            });
        }
         [Test]
        public void Test_Constructor_If_Capacity_Is_Less_Than_0_Should_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("asd", -1);
            });
        }
          [Test]
        public void Test_Constructor_If_Initializes_Properly()
        {
            Gym gym = new Gym("Peshkata", 15);
            Assert.AreEqual("Peshkata", gym.Name);
            Assert.AreEqual(15, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }
          [Test]
        public void Test_AddAthlete_If_Try_To_Add_When_There_Is_No_Capacity_Should_Throw_InvalidOperationException()
        {
            Gym gym = new Gym("Peshkata", 0);
            Athlete athlete = new Athlete("Serjo");
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete);
            });
        }
        [Test]
        public void Test_AddAthlete_If_Adds_Correctly()
        {
            Gym gym = new Gym("Peshkata", 5);
            Athlete athlete = new Athlete("Serjo");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void Test_RemoveAthlete_If_Given_AthleteName_That_Doesnt_Exist_Should_Throw_InvalidOperationException()
        {
            Gym gym = new Gym("Peshkata", 5);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("ads");
            });
        }
        [Test]
        public void Test_RemoveAthlete_If_Removes_Correctly_Should_Decrease_Count()
        {
            Gym gym = new Gym("Peshkata", 5);
            Athlete athlete = new Athlete("Serjo");
            gym.AddAthlete(athlete);
            Athlete athlete2 = new Athlete("Gergo");
            gym.AddAthlete(athlete2);
            gym.RemoveAthlete("Gergo");
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void Test_InjureAthlete_If_Recieves_Name_That_Doesnt_Exist_Should_Throw_InvalidOperationException()
        {
            Gym gym = new Gym("TheGym", 6);
            Athlete athlete = new Athlete("Chehula");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("ASD");
            });
        }
        [Test]
        public void Test_InjureAthlete_If_Works_IsInjured_Should_Be_True()
        {
            Gym gym = new Gym("TheGym", 6);
            Athlete athlete = new Athlete("Chehula");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Chehula");
            Assert.IsTrue(athlete.IsInjured);
        }
         [Test]
        public void Test_InjureAthlete_If_Returns_Correct_Athlete()
        {
            Gym gym = new Gym("TheGym", 6);
            Athlete athlete = new Athlete("Chehula");
            gym.AddAthlete(athlete);
            var test = gym.InjureAthlete("Chehula");
            Assert.AreEqual(athlete, test);
        }
         [Test]
        public void Test_Report_If_Returns_Athletes_That_Arent_Injured()
        {
            Gym gym = new Gym("Peshkata", 5);
            Athlete athlete = new Athlete("Serjo");
            gym.AddAthlete(athlete);
            Athlete athlete2 = new Athlete("Gergo");
            gym.AddAthlete(athlete2);
            Athlete athlete3 = new Athlete("Chehula");
            gym.AddAthlete(athlete3);
            gym.InjureAthlete("Chehula");
            var test = gym.Report();
            Assert.AreEqual($"Active athletes at Peshkata: Serjo, Gergo",test);
        }

    }
}
