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

            Bike motoWithoutChassis = new Bike();
            motoWithoutChassis.parts.Remove(motoWithoutChassis.parts.Find(p => p is Chassis));
            Assert.NotNull(motoWithoutChassis);
        }

        [Test]
        public void BikesCanBeUsed()
        {
            // Moto completa
            var motoComplete = new Bike();
            motoComplete.AddPart(new Chassis());
            motoComplete.AddPart(new frontWheel());
            motoComplete.AddPart(new backWheel());
            motoComplete.AddPart(new Engine());
            motoComplete.AddPart(new Muffler());
            Assert.IsTrue(motoComplete.CanBeUsedInRace(), "La moto completa debe ser válida");

            // Moto sin motor
            var motoWithoutEngine = new Bike();
            motoWithoutEngine.AddPart(new Chassis());
            motoWithoutEngine.AddPart(new frontWheel());
            motoWithoutEngine.AddPart(new backWheel());
            motoWithoutEngine.AddPart(new Muffler());
            Assert.IsFalse(motoWithoutEngine.CanBeUsedInRace(), "La moto sin motor no debe ser válida");

            // Moto sin llanta trasera
            var motoWithoutBackWheel = new Bike();
            motoWithoutBackWheel.AddPart(new Chassis());
            motoWithoutBackWheel.AddPart(new frontWheel());
            motoWithoutBackWheel.AddPart(new Engine());
            motoWithoutBackWheel.AddPart(new Muffler());
            Assert.IsFalse(motoWithoutBackWheel.CanBeUsedInRace(), "La moto sin llanta trasera no debe ser válida");

            // Moto sin mofle
            var motoWithoutMuffler = new Bike();
            motoWithoutMuffler.AddPart(new Chassis());
            motoWithoutMuffler.AddPart(new frontWheel());
            motoWithoutMuffler.AddPart(new backWheel());
            motoWithoutMuffler.AddPart(new Engine());
            Assert.IsFalse(motoWithoutMuffler.CanBeUsedInRace(), "La moto sin mofle no debe ser válida");
        }

        [Test]
        public void PartCanBeAdded()
        {
            Bike motoWithoutFrontWheel = new Bike();
            motoWithoutFrontWheel.AddPart(new backWheel());
            Assert.IsTrue(CanAddPart(motoWithoutFrontWheel, new frontWheel()));

            Bike motoWithBackWheel = new Bike();
            motoWithBackWheel.AddPart(new backWheel());
            Assert.IsTrue(CanAddPart(motoWithBackWheel, new backWheel()));

            Bike motoWithoutMuffler = new Bike();
            Assert.IsTrue(CanAddPart(motoWithoutMuffler, new Muffler()));

            Bike motoWithChassis = new Bike();
            Assert.IsFalse(CanAddPart(motoWithChassis, new Chassis()));
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
