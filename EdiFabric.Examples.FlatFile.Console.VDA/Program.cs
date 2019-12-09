namespace EdiFabric.Examples.FlatFile.Console.VDA
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadVDAFile.Run();
            ReadVDAFileAsync.Run();

            WriteVDAFile.Run();
            WriteVDAFileAsync.Run();
        }
    }
}
