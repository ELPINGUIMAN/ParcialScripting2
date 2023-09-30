using System;

public class Chassis : BikePart
{
    public override double ModifySpeed() { return 0.0; }
    public override double ModifyAcceleration() { return 0.0; }
    public override double ModifyHandling() { return 0.0; }
    public override double ModifyGrip() { return 0.0; }
}