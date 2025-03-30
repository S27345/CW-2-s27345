namespace Cw2;

public class GasContainer : Container, IHazardNotifier
{
    public override char ConType => 'G';
    public override string SerialNumber { get; }
    
    public GasContainer(int payloadMass, int height, int ownMass, int maxPayloadMass) : base(payloadMass, height, ownMass, maxPayloadMass)
    {
        SerialNumber = SetSerialNumber(ConType);
    }

    public override void EmptyPayload()
    {
        PayloadMass = Convert.ToInt32(PayloadMass * 0.05);
    }


    public void HazardNotification()
    {
        Console.WriteLine("Hazard notification at: " + SerialNumber);
    }
}