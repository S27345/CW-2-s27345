namespace Cw2;

public abstract class Container
{
    public int PayloadMass { get; set; }
    public int Height { get; set; }
    public int OwnMass { get; set; }
    private static int _num = 0;
    public abstract char ConType {get;}
    public int MaxPayloadMass {get; set;}
    
    public abstract string SerialNumber { get; }

    public static List<Container> Containers = new();

    public Container(int payloadMass, int height, int ownMass, int maxPayloadMass)
    {
        PayloadMass = payloadMass;
        Height = height;
        OwnMass = ownMass;
        MaxPayloadMass = maxPayloadMass;
        Containers.Add(this);
    }

    public virtual void EmptyPayload()
    {
        PayloadMass = 0;
    }

    public virtual void LoadPayload(int mass)
    {
        PayloadMass += mass;
        if (PayloadMass > MaxPayloadMass)
        {
            throw new OverFillException("Container Overflow!");
        }
    }

    protected string SetSerialNumber(char type)
    {
        return $"KON-{type}-{_num++}";
    }

    public static Container FindContainer(string serialNumber)
    {
        return Containers.Find(c => c.SerialNumber.Equals(serialNumber));
    }

    public override string ToString()
    {
        return $"Kontener {{{SerialNumber}}} - Typ {{{ConType}}} - Waga Łączna {{{PayloadMass+OwnMass}}} - Wysokość {{{Height}}}" +
               $" - Max waga {{{MaxPayloadMass}}}";
    }
}

internal class OverFillException : Exception
{
    public OverFillException(string? message) : base(message)
    {
    }
}

