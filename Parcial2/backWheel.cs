using System;

public class backWheel : BikePart
{
    public override double ModifySpeed() { return 2.0; }
    public override double ModifyAcceleration() { return 2.0; }
    public override double ModifyHandling() { return 2.0; }
    public override double ModifyGrip() { return 2.0; }
}
