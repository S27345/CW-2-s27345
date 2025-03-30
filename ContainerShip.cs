namespace Cw2;

public class ContainerShip
{
    public List<Container> OnBoardContainers = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainerCapacity { get; set; }
    public int MaxContainerWeight { get; set; }

    public ContainerShip(double maxSpeed, int maxContainerCapacity, int maxContainerWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxContainerWeight = maxContainerWeight;
    }

    public void LoadContainer(Container container)
    {
        OnBoardContainers.Add(container);
        if (OnBoardContainers.Count > MaxContainerCapacity)
        {
            throw new Exception("Container capacity exceeded");
        }

        if (checkWeight() > MaxContainerWeight*1000) // w tonach więc * 1000
        {
            throw new Exception("Container weight exceeded");
        }
        
    }
    
    public void LoadContainer(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
            if (OnBoardContainers.Count > MaxContainerCapacity)
            {
                throw new Exception("Container capacity exceeded");
            }

            if (checkWeight() > MaxContainerWeight*1000) // w tonach więc * 1000
            {
                throw new Exception("Container weight exceeded");
            }
        }
    }

    public int checkWeight()
    {
        int weight = 0;
        for (int i = 0; i < OnBoardContainers.Count; i++)
        {
            weight += OnBoardContainers[i].OwnMass + OnBoardContainers[i].PayloadMass;
        }
        
        return weight;
    }

    public void RemoveContainer(Container container)
    {
        OnBoardContainers.Remove(container);
    }

    public void SwapContainer(string toSwapSerialNumber, string newSerialNumber)
    {
        var con = Container.FindContainer(newSerialNumber);
        
        foreach (var conToRemove in OnBoardContainers)
        {
            if (conToRemove.SerialNumber == toSwapSerialNumber)
            {
                OnBoardContainers.Remove(conToRemove);
                break;
            }
        }
        OnBoardContainers.Add(con);
    }

    public static void SwapBetweenShips(Tuple<ContainerShip, Container> From, Tuple<ContainerShip, Container> To)
    {
        From.Item1.RemoveContainer(From.Item2);
        To.Item1.RemoveContainer(To.Item2);
        
        From.Item1.LoadContainer(To.Item2);
        To.Item1.LoadContainer(From.Item2);
    }

    public override string ToString()
    {
        String tst = string.Join("\n", OnBoardContainers.Select(con => "\t\t" + con)) + "\n";
        var currContainerAmount = OnBoardContainers.Count;
        return $"Kontenerowiec - Max.Prędkość {{{MaxSpeed}}} - Max.Ilość Kontenerów {{{MaxContainerCapacity}}} - Max.Waga Kontenerów {{{MaxContainerWeight}}}\n" +
               $"\tAktualna ilość kontenerów {{{currContainerAmount}}}:\n" + tst;
    }
}