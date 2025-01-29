using System;
using System.Windows.Forms;

namespace Minesweeper
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenuForm());
        }


        public static void FadeIn(Form form)
        {
            form.Opacity = 0;
            form.Show();
            for (double i = 0; i <= 1; i += 0.1)
            {
                form.Opacity = i;
                System.Threading.Thread.Sleep(50);
            }
        }

        public static void FadeOut(Form form)
        {
            for (double i = 1; i >= 0; i -= 0.1)
            {
                form.Opacity = i;
                System.Threading.Thread.Sleep(50);
            }
            form.Close();
        }
    }
}