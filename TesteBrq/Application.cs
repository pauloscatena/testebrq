using TesteBrq.Entities;
using TesteBrq.Interfaces.Entities;
using TesteBrq.Interfaces.Services;
using TesteBrq.Services;

namespace TesteBrq;

public static class Application
{
    public static ITradeClassifier Start()
    {
        ITradeClassifier classifier = null;
        var manualInput = Environment.GetEnvironmentVariable("MANUAL_INPUT");

        if ((manualInput ?? string.Empty) == "1")
        {
            Console.WriteLine("Enter Reference Date");
            var referenceDateIn = Console.ReadLine();

            Console.WriteLine("Enter qty of trades");
            int.TryParse(Console.ReadLine(), out var tradeCountIn);

            classifier = new TradeClassifier();
            classifier.SetReferenceDate(referenceDateIn);


            for (int i = 0; i < tradeCountIn; i++)
            {
                Console.WriteLine($"Enter trade #{(i + 1)}");
                Trade tradeStr = Console.ReadLine() ?? string.Empty;
                classifier.AddTrade(tradeStr);
            }
        }
        else
        {
            string[] commandLineArguments = Environment.GetCommandLineArgs();
            string fileName = commandLineArguments.Length > 1 ? commandLineArguments.Last() : Path.Combine("Resources", "TradeInput.txt");

            classifier = TradeClassifier.FromFile(fileName);
        }

        return classifier;
    }

    public static void PrintOut(ITradeClassifier classifier)
    {
        try
        {
            IClassificationService classificationService = new ClassificationService();
            var result = classificationService.Run(classifier);


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}