// See https://aka.ms/new-console-template for more information


using Cw2;

public partial class Program
{
    public static void Main(string[] args)
    {
        LiquidContainer lq = new LiquidContainer(1000,200,300,2000);
        LiquidContainer lq2 = new LiquidContainer(2000,500,200,5000);
        CoolingContainer cl = new CoolingContainer(800, 400, 500, 5000,"Bananas",12);
        GasContainer gc = new GasContainer(1000,200,300,2000);
        
        Console.WriteLine(lq.SerialNumber);
        Console.WriteLine(lq2.SerialNumber);
        Console.WriteLine(cl.SerialNumber);
        Console.WriteLine(gc.SerialNumber);

        lq.LoadPayload(500);
        Console.WriteLine(lq.PayloadMass);
        
        ContainerShip ship = new ContainerShip(10,4,10);
        ship.LoadContainer(lq2);
        
        ship.LoadContainer(new List<Container> { lq, cl });

        ship.RemoveContainer(lq);
        
        lq.EmptyPayload();
        
        ship.SwapContainer("KON-C-2","KON-G-3");
        
        ContainerShip ship2 = new ContainerShip(10,4,10);
        ship2.LoadContainer(cl);
        
        ContainerShip.SwapBetweenShips(new Tuple<ContainerShip, Container>(ship,gc), new Tuple<ContainerShip, Container>(ship2,cl));
        
        Console.WriteLine(cl);
        Console.WriteLine(ship);
        
    }
}