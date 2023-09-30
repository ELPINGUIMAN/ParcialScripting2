using System;

public class Muffler : BikePart
{
    public override double ModifySpeed() { return 0.0; }
    public override double ModifyAcceleration() { return 5.0; }
    public override double ModifyHandling() { return 0.0; }
    public override double ModifyGrip() { return 0.0; }
}