namespace Programming_03_Assignment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialise application configuration.
            ApplicationConfiguration.Initialize();

            // Initialise the SQLite library.
            SQLitePCL.Batteries.Init();

            // Run main form of application.
            Application.Run(new IndexPage());
        }
    }
}