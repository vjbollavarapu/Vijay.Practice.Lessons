using PCSC;
using PCSC.Monitoring;
using System.ComponentModel.DataAnnotations;
/*
https://github.com/danm-de/pcsc-sharp/tree/master/Examples
https://gist.github.com/aa6my/7eb3cf2d2f120c8b4ae017f0ea779aa1
https://www.jpn.gov.my/en/mykad-eng/94-informasi/informasi-mykad/2739-info-alat-pembaca-mykad-eng
*/
var contextFactory = ContextFactory.Instance;
using(var context = contextFactory.Establish(SCardScope.System))
{
    Console.WriteLine("Currently connected readers");
    var readers = context.GetReaders();
    foreach(var readerName in readers)
    {
        try
        {
            using (var reader = context.ConnectReader(readerName, SCardShareMode.Shared, SCardProtocol.Any))
            {
                var cardAtr = reader.GetAttrib(SCardAttribute.AtrString);
                Console.WriteLine("ATR: {0}", BitConverter.ToString(cardAtr));
                Console.ReadKey();
            }
        }
        catch(Exception ex) {
            Console.WriteLine("Reader connection failed {0}. No smart card presend {1}", readerName, ex.GetType());
        }
    }

    /*
    using(var reader = context.ConnectReader("Feitian SCR301 0", SCardShareMode.Shared, SCardProtocol.Any))
    {
        var cardAtr = reader.GetAttrib(SCardAttribute.AtrString);
        Console.WriteLine("ATR: {0}", BitConverter.ToString(cardAtr));
        Console.ReadKey();
    }*/
}

var monitorFactory = MonitorFactory.Instance;
var monitor = monitorFactory.Create(SCardScope.System);

// connect events here..
monitor.StatusChanged += (sender, args) =>
    Console.WriteLine($"New state: {args.NewState}");

//monitor.Start("OMNIKEY CardMan 5x21-CL 0");
monitor.Start("Feitian SCR301 0");

Console.ReadKey(); // Press any key to exit

monitor.Cancel();
monitor.Dispose();