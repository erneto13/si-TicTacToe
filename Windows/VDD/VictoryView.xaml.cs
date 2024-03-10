using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace si_TicTacToe.Windows.VDD
{
    /// <summary>
    /// Lógica de interacción para VictoryView.xaml
    /// </summary>
    public partial class VictoryView : Window
    {

        // Variable 
        private string currentWinner;
        private MainWindow mainMenu = new MainWindow();

        // Constructor para usar métodos o var. de la clase TicTacToe
        TicTacToe ticTacToe;
        public VictoryView(TicTacToe ticTacToe)
        {
            InitializeComponent();
            this.ticTacToe = ticTacToe;
        }


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        public VictoryView()
        {
            InitializeComponent();
        }

        private void pnlBarraControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void onLoadView(object sender, RoutedEventArgs e)
        {
            if (ticTacToe != null)
            {
                if (ticTacToe.winnerName == ticTacToe.drawRound)
                {
                    symbolWinner.Text = ticTacToe.symbolSelector;
                    currentWinner = ticTacToe.winnerName;
                }
                else
                {
                    symbolWinner.Text = ticTacToe.symbolSelector;
                    currentWinner = ticTacToe.winnerName + " ha ganado la ronda";
                }

                playerNameWin.Text = currentWinner;

                int finalRoundCount = ticTacToe.roundCount - 1;
                string formatRoundCountTitle = "¡Ronda " + finalRoundCount + " terminada!";
                roundCountTitle.Text = formatRoundCountTitle;
            }
        }


        private void buttonNewRound(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonRageQuit(object sender, RoutedEventArgs e)
        {
            this.Close();
            ticTacToe.Close();
            mainMenu.Show();
        }
    }
}
