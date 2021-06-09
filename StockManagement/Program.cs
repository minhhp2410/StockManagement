namespace StockManagement
{
    using System;
    using System.Windows.Forms;
    using StockManagement.Views;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStockinPlan());
        }
    }
}
