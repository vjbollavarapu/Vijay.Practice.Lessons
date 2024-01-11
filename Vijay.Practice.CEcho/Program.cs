using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var cancellationToken = CancellationToken.None;

        using var server = DicomServerFactory.Create<DicomCEchoProvider>(12345);


    }
}