namespace Cw2;

public class LiquidContainer : Container,IHazardNotifier
{


    public override char ConType => 'L';
    public override string SerialNumber { get; }
    private bool DangerousPayload { get; }

    
    public LiquidContainer(int payloadMass, int height, int ownMass, int maxPayloadMass) : base(payloadMass, height, ownMass, maxPayloadMass)
    {
        SerialNumber = SetSerialNumber(ConType);
    }

    public void HazardNotification()
    {
        Console.WriteLine("Hazard notification at: " + SerialNumber);
    }

    public override void LoadPayload(int mass)
    {
        PayloadMass += mass;
        if (PayloadMass > MaxPayloadMass)
        {
            throw new OverFillException("Container Overflow!");
        }
        if(DangerousPayload)
        {
            if (PayloadMass > MaxPayloadMass*0.5)
            {
                HazardNotification();
            }
        }
        else
        {
            if (PayloadMass > MaxPayloadMass*0.9)
            {
                HazardNotification();
            }
        }
    }
}