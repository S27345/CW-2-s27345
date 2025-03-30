namespace Cw2;

public class CoolingContainer : Container
{


    public override char ConType => 'C';
    public override string SerialNumber { get; }
    private static string Produce {get; set;}
    private static double Temperature { get; set; }

    public static Dictionary<string, double> CoolingValues = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", -15 },
        { "Ice cream", -18 },
        { "Frozen Pizza", -30 },
        {"Cheese",7.2},
        {"Sausages",5},
        {"Butter",20.5},
        {"Eggs",19},
    };


    public CoolingContainer(int payloadMass, int height, int ownMass,int maxPayloadMass, string produce, double temperature) : base(payloadMass, height, ownMass,maxPayloadMass)
    {
        Temperature = temperature;
        Produce = produce;
        SerialNumber = SetSerialNumber(ConType);

        if (!CoolingValues.ContainsKey(produce))
        {
            throw new ArgumentException("Invalid produce");
        }

        if (temperature > CoolingValues[produce])
        {
            throw new ArgumentException("Temperature too high");
        }
    }
}