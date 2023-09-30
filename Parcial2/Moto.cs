using System;

public class Bike
{
    public List<BikePart> parts;
    private bool hasFrontWheel = false;
    private bool hasBackWheel = false;
    private bool hasEngine = false;
    private bool hasMuffler = false;

    public Bike()
    {
        parts = new List<BikePart>();
        parts.Add(new Chassis());
    }
    public void AddPart(BikePart part)
    {
        if (part is frontWheel)
        {
            hasFrontWheel = true;
        }
        else if (part is backWheel)
        {
            hasBackWheel = true;
        }
        else if (part is Engine)
        {
            hasEngine = true;
        }
        else if (part is Muffler)
        {
            hasMuffler = true;
        }

        // Reemplazar la parte si ya existe
        for (int i = 0; i < parts.Count; i++)
        {
            if (parts[i].GetType() == part.GetType())
            {
                parts[i] = part;
                return;
            }
        }

        parts.Add(part);
    }
    public bool CanBeUsedInRace()
    {
        // Verifica si todas las partes esenciales están presentes
        return hasFrontWheel && hasBackWheel && hasEngine && hasMuffler;
    }

    public double GetSpeed()
    {
        double speed = 1.0;
        foreach (var part in parts)
        {
            speed += part.ModifySpeed();
        }
        return speed;
    }

    public double GetAcceleration()
    {
        double acceleration = 1.0;
        foreach (var part in parts)
        {
            acceleration += part.ModifyAcceleration();
        }
        return acceleration;
    }

    public double GetHandling()
    {
        double handling = 1.0;
        foreach (var part in parts)
        {
            handling += part.ModifyHandling();
        }
        return handling;
    }

    public double GetGrip()
    {
        double grip = 1.0;
        foreach (var part in parts)
        {
            grip += part.ModifyGrip();
        }
        return grip;
    }
}