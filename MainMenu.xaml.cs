using NAudio.Wave;
using si_TicTacToe.Windows;
using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Navigation;

namespace si_TicTacToe
{
    public partial class MainWindow : Window
    {
        // Variables
        private InputNamePlayers inputNamePlayers;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public MainWindow()
        {
            InitializeComponent();
        }

        // Método para minimizar la ventana.
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Método para cerrar la ventana.
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Método para controlar/mover la ventana.
        private void pnlBarraControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        // Método para abrir la URL de hipervínculo.
        private void hyperLinkRequestNaviagate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Excepción encontrada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para mostrar las opciones de jugar.
        private void MostrarOpcionesJugar_Click(object sender, RoutedEventArgs e)
        {
            botonesPanel.Visibility = botonesPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            jugarPanel.Visibility = jugarPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        // Método para regresar a la ventana principal
        private void RegresarMenu2(object sender, RoutedEventArgs e)
        {
            botonesPanel.Visibility = botonesPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            jugarPanel.Visibility = jugarPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        // Método para el jugador contra jugador
        private void JugarJCJ(object sender, RoutedEventArgs e)
        {
            try
            {
                if (inputNamePlayers == null)
                {
                    inputNamePlayers = new InputNamePlayers();
                }

                this.Hide();
                inputNamePlayers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en JugarJCJ: {ex.Message}", "Excepción encontrada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
