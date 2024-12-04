using System;
using System.Data; // Per usar DataTable per a les operacions matemàtiques.
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = ""; // Per mantenir el que l'usuari està escrivint.
        private string operation = ""; // Per emmagatzemar l'operació completa.
        private bool isResultDisplayed = false; // Indica si el resultat ha estat mostrat i es pot començar una nova operació.

        public MainWindow()
        {
            InitializeComponent();
        }

        // Gestiona els botons de números.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            // Si el resultat ha estat mostrat, reinicia l'entrada i l'operació.
            if (isResultDisplayed)
            {
                operation = "";
                isResultDisplayed = false;
            }
            currentInput += button.Content.ToString();
            operation += button.Content.ToString();
            Display.Text = operation; // Actualitza el display.
        }

        // Gestiona els botons d'operadors (+, -, *, /).
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            // Evita que dos operadors siguin encadenats (p. ex., "5 + *").
            if (!string.IsNullOrEmpty(currentInput) || isResultDisplayed)
            {
                currentInput = ""; // Restableix l'entrada actual.
                operation += $" {button.Content.ToString()} ";
                Display.Text = operation; // Actualitza el display.
                isResultDisplayed = false; // Permet afegir més operadors després de mostrar el resultat.
            }
        }

        // Gestiona el botó "=".
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Usa DataTable per calcular l'operació.
                var result = new DataTable().Compute(operation, null);
                Display.Text = result.ToString();
                operation = result.ToString(); // Mostra el resultat com a nou punt de partida.
                currentInput = "";
                isResultDisplayed = true; // Marca que el resultat s'ha mostrat, permetent començar una nova operació.
            }
            catch
            {
                Display.Text = "Error"; // Mostra un error en cas d'entrada no vàlida.
                operation = "";
                currentInput = "";
            }
        }

        // Gestiona el botó "C".
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            operation = "";
            Display.Text = "0"; // Restableix el display.
            isResultDisplayed = false; // Restableix l'estat després de l'esborrat.
        }
    }
}
