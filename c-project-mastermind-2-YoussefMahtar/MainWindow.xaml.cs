using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace c_project_mastermind_2_YoussefMahtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private List<string> code;
        int attempts = 1;
        string codeString = "";
        int sec = 0;
        int score = 100;
        public MainWindow()
        {
            InitializeComponent();
            RandomKleuren();
            LabelBorder();
            TextBoxCode();
            Attempts();
            showScore();

            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += startCountdown;
            timer.Start();
        }

        private void startCountdown(object sender, EventArgs e)
        {
            tijdTextBox.Text = $"Seconden : {sec}";
            sec++;
            stopCountdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            attempts++;
            Attempts();

            sec = 0;


            string checkKleur1 = ComboBox1.SelectedItem?.ToString() ?? "";
            string checkKleur2 = ComboBox2.SelectedItem?.ToString() ?? "";
            string checkKleur3 = ComboBox3.SelectedItem?.ToString() ?? "";
            string checkKleur4 = ComboBox4.SelectedItem?.ToString() ?? "";


            if (checkKleur1 == code[0])
            {
                Label1.BorderBrush = Brushes.DarkRed;
                
                
                

            }
            else if (checkKleur1 == code[1] || checkKleur1 == code[2] || checkKleur1 == code[3])
            {
                Label1.BorderBrush = Brushes.Wheat;
                score = score - 1;
                
            }
            else
            {
                Label1.BorderBrush = Brushes.Transparent;
                score = score - 2;
                
            }
            if (checkKleur2 == code[1])
            {
                Label2.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur2 == code[0] || checkKleur2 == code[2] || checkKleur2 == code[3])
            {
                Label2.BorderBrush = Brushes.Wheat;
                score = score - 1;
            }
            else
            {
                Label2.BorderBrush = Brushes.Transparent;
                score = score - 2;
            }
            if (checkKleur3 == code[2])
            {
                Label3.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur3 == code[0] || checkKleur3 == code[1] || checkKleur3 == code[3])
            {
                Label3.BorderBrush = Brushes.Wheat;
                score = score - 1;
            }
            else
            {
                Label3.BorderBrush = Brushes.Transparent;
                score = score - 2;
            }
            if (checkKleur4 == code[3])
            {
                Label4.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur4 == code[0] || checkKleur4 == code[1] || checkKleur4 == code[2])
            {
                Label4.BorderBrush = Brushes.Wheat;
                score = score - 1;
            }
            else
            {
                Label4.BorderBrush = Brushes.Transparent;
                score = score - 2;
            }

            showScore();

            if (Label1.BorderBrush == Brushes.DarkRed && Label2.BorderBrush == Brushes.DarkRed &&
                Label3.BorderBrush == Brushes.DarkRed && Label4.BorderBrush == Brushes.DarkRed)
            {
                var result = MessageBox.Show
                    ($"code gekraakt in {attempts} pogingen! Wil je nog eens?"
                    , "WINNER!"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    nieuwSpel();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }

        }

        private void RandomKleuren()
        {
            Random random = new Random();
            List<string> kleuren = new List<string> { "rood", "geel", "oranje", "wit", "groen", "blauw" };

            code = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                string randomKleur = kleuren[random.Next(kleuren.Count)];
                code.Add(randomKleur);
            }

            codeString = string.Join(", ", code);


            foreach (string kleur in kleuren)
            {
                ComboBox1.Items.Add(kleur);
                ComboBox2.Items.Add(kleur);
                ComboBox3.Items.Add(kleur);
                ComboBox4.Items.Add(kleur);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;


            string kleurCode = GekozenKleuren(comboBox);
            SolidColorBrush colorBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode);


            if (comboBox == ComboBox1)
            {
                Label1.Background = colorBrush;
            }
            else if (comboBox == ComboBox2)
            {
                Label2.Background = colorBrush;
            }
            else if (comboBox == ComboBox3)
            {
                Label3.Background = colorBrush;
            }
            else if (comboBox == ComboBox4)
            {
                Label4.Background = colorBrush;
            }
        }

        private string GekozenKleuren(ComboBox comboBox)
        {
            if (comboBox != null && comboBox.SelectedItem is string gekozenKleur)
            {

                switch (gekozenKleur.ToLower())
                {
                    case "rood":
                        return "#FF0000";
                    case "groen":
                        return "#008000";
                    case "blauw":
                        return "#0000FF";
                    case "geel":
                        return "#FFFF00";
                    case "oranje":
                        return "#FFA500";
                    case "wit":
                        return "#FFFFFF";
                    default:
                        return "#D3D3D3";
                }
            }

            return "#D3D3D3"; // Kleurcode "LIGHTGRAY". Is hetzelfde als achtergrond voor de kleur wit te kunnen laten zien.
        }

        private void LabelBorder()
        {
            Label1.BorderThickness = new Thickness(5);
            Label2.BorderThickness = new Thickness(5);
            Label3.BorderThickness = new Thickness(5);
            Label4.BorderThickness = new Thickness(5);
        }

        private void textBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12 && Keyboard.IsKeyDown(Key.LeftCtrl) && textBoxCode.Visibility == Visibility.Visible)
            {
                textBoxCode.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.F12 && Keyboard.IsKeyDown(Key.LeftCtrl) && textBoxCode.Visibility == Visibility.Hidden)
            {
                textBoxCode.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxCode()
        {
            textBoxCode.Text = $"{codeString}";
        }

        private void Attempts()
        {
            this.Title = $"Mastermind Attempt: {attempts}";

            if (attempts > 10)
            {
                var result =MessageBox.Show($"You failed! De correcte code was {codeString}." +
                    $"Nog eens proberen?", "FAILED"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    nieuwSpel();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void stopCountdown()
        {
            if (sec > 10)
            {
                MessageBox.Show("Tijd is op.");
                sec = 0;
                attempts++;
                Attempts();
            }
        }
        private void showScore()
        {
            scoreTextBox.Text = "Score: " + score.ToString();
        }

        private void nieuwSpel()
        {
            sec = 0;
            attempts = 1;
            score = 100;

            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            ComboBox4.Items.Clear();
            RandomKleuren();
            updateLabels();
            TextBoxCode();
            Attempts();
        }
        private void updateLabels()
        {
            Label1.BorderBrush = Brushes.Transparent;
            Label1.Background = Brushes.Transparent;

            Label2.BorderBrush = Brushes.Transparent;
            Label2.Background = Brushes.Transparent;

            Label3.BorderBrush = Brushes.Transparent;
            Label3.Background = Brushes.Transparent;

            Label4.BorderBrush = Brushes.Transparent;
            Label4.Background = Brushes.Transparent;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wilt u het spel vroegtijdig beëindigen?", $"Poging {attempts}/10", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }
    }
}
