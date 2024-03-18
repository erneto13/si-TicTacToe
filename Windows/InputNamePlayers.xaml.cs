using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace si_TicTacToe.Windows
{
    /// <summary>
    /// Lógica de interacción para InputNamePlayers.xaml
    /// </summary>
    public partial class InputNamePlayers : Window
    {
        // Constructores
        TicTacToe ticTacToe;

        // Variables
        public static string nameFirstPlayer;
        public static string nameSecondPlayer;

        public InputNamePlayers()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pnlBarraControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void superSecretEvent(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void buttonNewGame(object sender, RoutedEventArgs e)
        {
            if (txtJugadorX.Text == string.Empty || txtJugadorO.Text == string.Empty)
            {
                MessageBox.Show("Debe introducir un nombre de usuario para ambos jugadores", "Error encontrado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                TicTacToe ticTacToe = new TicTacToe(txtJugadorX.Text, txtJugadorO.Text);
                ticTacToe.Show();
                this.Close();
            }
        }
    }
}
