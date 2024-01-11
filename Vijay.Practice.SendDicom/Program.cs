using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            var client = DicomClientFactory.Create("127.0.0.1", 1002, false, "SCU", "ANY-SCP");
            client.NegotiateAsyncOps();

            client.NegotiateUserIdentity(new DicomUserIdentityNegotiation { 
                UserIdentityType = DicomUserIdentityType.Jwt,
                PositiveResponseRequested = true,
                PrimaryField = "JWT_TOKEN"
            });

            for(int i = 0; i < 10; i++)
            {
                await client.AddRequestAsync(new DicomCEchoRequest());
            }

            await client.AddRequestAsync(new DicomCStoreRequest(@"test1.dcm"));
            await client.SendAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
}