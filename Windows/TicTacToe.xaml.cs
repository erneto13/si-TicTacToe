using si_TicTacToe.Windows;
using si_TicTacToe.Windows.VDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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
using System.Windows.Threading;

namespace si_TicTacToe
{
    /// <summary>
    /// Lógica de interacción para TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : Window
    {
        // Constructor de la clase InputNamePlayer
        InputNamePlayers inputNamePlayers;
        public TicTacToe(InputNamePlayers inputNamePlayers)
        {
            this.inputNamePlayers = inputNamePlayers;
        }

        // Instancias
        private VictoryView victoryView;

        // Variables
        Button[,] buttons = new Button[4, 4]; // Definimos un array 2D que representan los botones del juego

        public int roundCount = 1; // Variable para controlar el número de rondas
        public int buttonCount = 1; // Variable para controlar el número de pulsaciones de botones
        public int playerPointsX = 0; // Variable para definir los puntos del jugador de las X
        public int playerPointsO = 0; // Variable para definir los puntos del jugador de las Y
        public int checkingFlag = 1; // Variable para salir de ciclos, hacer verificaciones, etc

        public string symbolSelector; // Variable para definir el simbolo que jugarán los jugadores [X,O]
        public string playerX = "Ernesto"; // Variable para definir el nombre del jugador X
        public string playerO = "Josue"; // Variable para definir el nombre del jugador O
        public string drawRound = "Ningun jugador gano, ronda empatada"; // Variable para indicar cuando haya un empate

        private DispatcherTimer dispatcherTimer;
        private int seconds;

        public string winnerName { get; private set; }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Método para inicializar el tablero
        public void inicializarTablero()
        {
            // Se asignan los botones correspondientes al array en orden 0,1,2,3,4,5,6,7,8
            buttons[1, 1] = buttonPosicionZero;
            buttons[1, 2] = buttonPosicionOne;
            buttons[1, 3] = buttonPosicionTwo;
            buttons[2, 1] = buttonPosicionTree;
            buttons[2, 2] = buttonPosicionFour;
            buttons[2, 3] = buttonPosicionFive;
            buttons[3, 1] = buttonPosicionSix;
            buttons[3, 2] = buttonPosicionSeven;
            buttons[3, 3] = buttonPosicionEight;

            playerNameO.Text = playerO;
            playerNameX.Text = playerX;

        }

        public TicTacToe()
        {
            InitializeComponent();
            inicializarTablero();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += cronometrajeGenerador;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            seconds = 0;
        }

        private void loadingTicTacToe(object sender, RoutedEventArgs e)
        {
            inicializarTablero();
        }

        // Método para determinar el turno
        private void determinarTurno()
        {
            if (buttonCount % 2 == 0) {

                symbolSelector = "O";
                turnoJugadores.Text = "↩";

            } else {

                symbolSelector = "X";
                turnoJugadores.Text = "↪";

            }
        }

        // EventHandlers para cada botón del tablero
        private void buttonPosicionZero_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionZero.Content = symbolSelector;
            buttonCount++;
            buttonPosicionZero.IsEnabled = false;

            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
            }

            if (buttonCount >= 5)
            {
                comprobarGanador(1, 1);
            }
        }

        private void buttonPosicionOne_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionOne.Content = symbolSelector;
            buttonCount++;
            buttonPosicionOne.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(1, 2);
            }
        }

        private void buttonPosicionTwo_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionTwo.Content = symbolSelector;
            buttonCount++;
            buttonPosicionTwo.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(1, 3);
            }
        }

        private void buttonPosicionTree_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionTree.Content = symbolSelector;
            buttonCount++;
            buttonPosicionTree.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(2, 1);
            }
        }

        private void buttonPosicionFour_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionFour.Content = symbolSelector;
            buttonCount++;
            buttonPosicionFour.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(2, 2);
            }
        }

        private void buttonPosicionFive_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionFive.Content = symbolSelector;
            buttonCount++;
            buttonPosicionFive.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(2, 3);
            }
        }

        private void buttonPosicionSix_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionSix.Content = symbolSelector;
            buttonCount++;
            buttonPosicionSix.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(3, 1);
            }
        }

        private void buttonPosicionSeven_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionSeven.Content = symbolSelector;
            buttonCount++;
            buttonPosicionSeven.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(3, 2);
            }
        }

        private void buttonPosicionEight_Click(object sender, RoutedEventArgs e)
        {
            determinarTurno();
            buttonPosicionEight.Content = symbolSelector;
            buttonCount++;
            buttonPosicionEight.IsEnabled = false;
            if (buttonCount >= 5)
            {
                comprobarGanador(3, 3);
            }
        }

        // Método para comprobar quien gano en base a la lógica
        /*
         * 0 1 2 
         * 3 4 5
         * 6 7 8
         * 
         * - Una comprobación va a recorrer el array del 0-2, 3-5, 6-7 de 
         *   igual manera para las combinaciones del 0-6, 1-7, 2-8 y viceversa
         * 
         * - La otra comprobación sería para los diagonales, serían las combinaciones
         *   0,4,8 y 2,4,6 y de manera viceversa para ver si los jugadores ganan con eso.
         *   
        */
        private void comprobarGanador(int fila, int columna)
        {
            if (buttons[fila, columna].Content == "O")
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (buttons[i, 1].Content == "O" && buttons[i, 2].Content == "O" && buttons[i, 3].Content == "O")
                    {
                        winnerName = playerO;
                        playerPointsO++;
                        otrosComprobadores();
                        reiniciarJuego();

                        victoryView = new VictoryView(this);
                        victoryView.ShowDialog();
                    }
                    if (buttons[1, i].Content == "O" && buttons[2, i].Content == "O" && buttons[3, i].Content == "O")
                    {
                        winnerName = playerO;
                        playerPointsO++;
                        otrosComprobadores();
                        reiniciarJuego();

                        victoryView = new VictoryView(this);
                        victoryView.ShowDialog();
                    }
                }
                if (buttons[1, 1].Content == "O" && buttons[2, 2].Content == "O" && buttons[3, 3].Content == "O")
                {
                    winnerName = playerO;
                    playerPointsO++;
                    otrosComprobadores();
                    reiniciarJuego();

                    victoryView = new VictoryView(this);
                    victoryView.ShowDialog();
                }
                if (buttons[1, 3].Content == "O" && buttons[2, 2].Content == "O" && buttons[3, 1].Content == "O")
                {
                    winnerName = playerO;
                    playerPointsO++;
                    otrosComprobadores();
                    reiniciarJuego();

                    victoryView = new VictoryView(this);
                    victoryView.ShowDialog();
                }
            }
            if (buttons[fila, columna].Content == "X")
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (buttons[i, 1].Content == "X" && buttons[i, 2].Content == "X" && buttons[i, 3].Content == "X")
                    {
                        winnerName = playerX;
                        playerPointsX++;
                        otrosComprobadores();
                        reiniciarJuego();

                        victoryView = new VictoryView(this);
                        victoryView.ShowDialog();
                    }
                    if (buttons[1, i].Content == "X" && buttons[2, i].Content == "X" && buttons[3, i].Content == "X")
                    {
                        winnerName = playerX;
                        playerPointsX++;
                        otrosComprobadores();
                        reiniciarJuego();

                        victoryView = new VictoryView(this);
                        victoryView.ShowDialog();
                    }
                }
                if (buttons[1, 1].Content == "X" && buttons[2, 2].Content == "X" && buttons[3, 3].Content == "X")
                {
                    winnerName = playerX;
                    playerPointsX++;
                    otrosComprobadores();
                    reiniciarJuego();

                    victoryView = new VictoryView(this);
                    victoryView.ShowDialog();
                }
                if (buttons[1, 3].Content == "X" && buttons[2, 2].Content == "X" && buttons[3, 1].Content == "X")
                {
                    winnerName = playerX;
                    playerPointsX++;
                    otrosComprobadores();
                    reiniciarJuego();

                    victoryView = new VictoryView(this);
                    victoryView.ShowDialog();
                }
                if (buttonCount > 9)
                {
                    symbolSelector = "-";
                    winnerName = drawRound;
                    otrosComprobadores();
                    reiniciarJuego();

                    victoryView = new VictoryView(this);
                    victoryView.ShowDialog();
                }
            }
        }

        // Método para hacer otras comprobaciones
        private void otrosComprobadores()
        {
            roundCount++; // Se aumenta en +1 el número de la ronda
            contadorRondas.Text = roundCount.ToString(); // Establece el número de rondas a la vista

            // Se le asignan los puntos a los jugadores
            pointsPlayerX.Text = playerPointsX.ToString();
            pointsPlayerO.Text = playerPointsO.ToString();
            buttonCount = 1; // Se reinicia la cuenta del botón a 1

        }

        // Un método simple que recorre el array y
        // borra el texto y los habilita de nuevo
        private void reiniciarJuego()
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    buttons[i, j].Content = " ";
                    buttons[i, j].IsEnabled = true;
                }
            }
            turnoJugadores.Text = "↩";
        }

        // Método para controlar el tiempo
        private void cronometrajeGenerador(object? sender, EventArgs e)
        {
            seconds++;
            actualizarCronometro();
        }

        // Método para establecer iniciar el tiempo
        private void actualizarCronometro()
        {
            int minutes = seconds / 60;
            int secondsRemaining = seconds % 60;

            cronometro.Text = $"{minutes:D2}:{secondsRemaining:D2}";
        }

        // Método para controlar la barra/cinta de la ventana
        private void pnlBarraControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        // Método para cerrar la ventana
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Método para minimizar la ventana
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
