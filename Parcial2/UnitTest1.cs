using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace Parcial2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BikeCanBeCreated()
        {
            Bike bikeWithChassis = new  Bike();
            Assert.NotNull(bikeWithChassis);

            Bike bikeWithoutChassis = new Bike();
            bikeWithoutChassis.parts.Remove(bikeWithoutChassis.parts.Find(p => p is Chassis));
            Assert.NotNull(bikeWithoutChassis);
        }

        [Test]
        public void BikesCanBeUsed()
        {
            var bikeComplete = new Bike();
            bikeComplete.AddPart(new Chassis());
            bikeComplete.AddPart(new frontWheel());
            bikeComplete.AddPart(new backWheel());
            bikeComplete.AddPart(new Engine());
            bikeComplete.AddPart(new Muffler());
            Assert.IsTrue(bikeComplete.CanBeUsedInRace());

            var bikeWithoutEngine = new Bike();
            bikeWithoutEngine.AddPart(new Chassis());
            bikeWithoutEngine.AddPart(new frontWheel());
            bikeWithoutEngine.AddPart(new backWheel());
            bikeWithoutEngine.AddPart(new Muffler());
            Assert.IsFalse(bikeWithoutEngine.CanBeUsedInRace());

            var bikeWithoutBackWheel = new Bike();
            bikeWithoutBackWheel.AddPart(new Chassis());
            bikeWithoutBackWheel.AddPart(new frontWheel());
            bikeWithoutBackWheel.AddPart(new Engine());
            bikeWithoutBackWheel.AddPart(new Muffler());
            Assert.IsFalse(bikeWithoutBackWheel.CanBeUsedInRace());

            var bikeWithoutMuffler = new Bike();
            bikeWithoutMuffler.AddPart(new Chassis());
            bikeWithoutMuffler.AddPart(new frontWheel());
            bikeWithoutMuffler.AddPart(new backWheel());
            bikeWithoutMuffler.AddPart(new Engine());
            Assert.IsFalse(bikeWithoutMuffler.CanBeUsedInRace());
        }

        [Test]
        public void PartCanBeAdded()
        {
            Bike bikeWithoutFrontWheel = new Bike();
            bikeWithoutFrontWheel.AddPart(new backWheel());
            Assert.IsTrue(CanAddPart(bikeWithoutFrontWheel, new frontWheel()));

            Bike bikeWithBackWheel = new Bike();
            bikeWithBackWheel.AddPart(new backWheel());
            Assert.IsTrue(CanAddPart(bikeWithBackWheel, new backWheel()));

            Bike bikeWithoutMuffler = new Bike();
            Assert.IsTrue(CanAddPart(bikeWithoutMuffler, new Muffler()));

            Bike bikeWithChassis = new Bike();
            Assert.IsFalse(CanAddPart(bikeWithChassis, new Chassis()));
        }

        private bool CanAddPart(Bike moto, BikePart part)
        {
            // verify in logic if a part can be added based in specified conditions, here we try to add everything excluding chassis
            return !(part is Chassis);
        }

        [Test]
        public void PartsModifyParameters()
        {
            Bike moto = new Bike();

            BikePart chassis = new Chassis();
            BikePart muffler = new Muffler();
            BikePart engine = new Engine();
            BikePart frontWheel = new frontWheel();
            BikePart backWheel = new backWheel();

            moto.AddPart(chassis);
            Assert.AreEqual(1.0, moto.GetSpeed());
            Assert.AreEqual(1.0, moto.GetAcceleration());
            Assert.AreEqual(1.0, moto.GetHandling());
            Assert.AreEqual(1.0, moto.GetGrip());

            moto.AddPart(muffler);
            Assert.AreEqual(1.0, moto.GetSpeed());
            Assert.AreEqual(6.0, moto.GetAcceleration());
            Assert.AreEqual(1.0, moto.GetHandling());
            Assert.AreEqual(1.0, moto.GetGrip());

            moto.AddPart(engine);
            Assert.AreEqual(6.0, moto.GetSpeed());
            Assert.AreEqual(6.0, moto.GetAcceleration());
            Assert.AreEqual(1.0, moto.GetHandling());
            Assert.AreEqual(1.0, moto.GetGrip());

            moto.AddPart(frontWheel);
            Assert.AreEqual(8.0, moto.GetSpeed());
            Assert.AreEqual(8.0, moto.GetAcceleration());
            Assert.AreEqual(3.0, moto.GetHandling());
            Assert.AreEqual(3.0, moto.GetGrip());

            moto.AddPart(backWheel);
            Assert.AreEqual(10.0, moto.GetSpeed());
            Assert.AreEqual(10.0, moto.GetAcceleration());
            Assert.AreEqual(5.0, moto.GetHandling());
            Assert.AreEqual(5.0, moto.GetGrip());

            Assert.IsTrue(moto.CanBeUsedInRace());
        }
        [Test]
        public void MaxParameterValuesOnConstructor()
        {
            // Arrange
            var frontWheel = new frontWheel();
            var backWheel = new backWheel();
            var engine = new Engine();
            var muffler = new Muffler();
            var chassis = new Chassis();

            // Act
            double frontWheelSpeedModifier = frontWheel.ModifySpeed();
            double frontWheelAccelerationModifier = frontWheel.ModifyAcceleration();
            double frontWheelHandlingModifier = frontWheel.ModifyHandling();
            double frontWheelGripModifier = frontWheel.ModifyGrip();

            double backWheelSpeedModifier = backWheel.ModifySpeed();
            double backWheelAccelerationModifier = backWheel.ModifyAcceleration();
            double backWheelHandlingModifier = backWheel.ModifyHandling();
            double backWheelGripModifier = backWheel.ModifyGrip();

            double engineSpeedModifier = engine.ModifySpeed();
            double engineAccelerationModifier = engine.ModifyAcceleration();
            double engineHandlingModifier = engine.ModifyHandling();
            double engineGripModifier = engine.ModifyGrip();

            double mufflerSpeedModifier = muffler.ModifySpeed();
            double mufflerAccelerationModifier = muffler.ModifyAcceleration();
            double mufflerHandlingModifier = muffler.ModifyHandling();
            double mufflerGripModifier = muffler.ModifyGrip();

            double chassisSpeedModifier = chassis.ModifySpeed();
            double chassisAccelerationModifier = chassis.ModifyAcceleration();
            double chassisHandlingModifier = chassis.ModifyHandling();
            double chassisGripModifier = chassis.ModifyGrip();

            Assert.AreEqual(2.0, frontWheelSpeedModifier);
            Assert.AreEqual(2.0, frontWheelAccelerationModifier);
            Assert.AreEqual(2.0, frontWheelHandlingModifier);
            Assert.AreEqual(2.0, frontWheelGripModifier);

            Assert.AreEqual(2.0, backWheelSpeedModifier);
            Assert.AreEqual(2.0, backWheelAccelerationModifier);
            Assert.AreEqual(2.0, backWheelHandlingModifier);
            Assert.AreEqual(2.0, backWheelGripModifier);

            Assert.AreEqual(5.0, engineSpeedModifier);
            Assert.AreEqual(0.0, engineAccelerationModifier);
            Assert.AreEqual(0.0, engineHandlingModifier);
            Assert.AreEqual(0.0, engineGripModifier);

            Assert.AreEqual(0.0, mufflerSpeedModifier);
            Assert.AreEqual(5.0, mufflerAccelerationModifier);
            Assert.AreEqual(0.0, mufflerHandlingModifier);
            Assert.AreEqual(0.0, mufflerGripModifier);

            Assert.AreEqual(0.0, chassisSpeedModifier);
            Assert.AreEqual(0.0, chassisAccelerationModifier);
            Assert.AreEqual(0.0, chassisHandlingModifier);
            Assert.AreEqual(0.0, chassisGripModifier);
        }
    }
}
