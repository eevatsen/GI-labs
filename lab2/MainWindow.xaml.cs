using System.Windows;
using System.Windows.Input;
using System.IO;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // прив'язка команди збереження
            CommandBinding saveCmd = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCmd);

            // прив'язка команди відкриття
            CommandBinding openCmd = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(openCmd);

            // прив'язка команди очищення
            CommandBinding clearCmd = new CommandBinding(ApplicationCommands.Delete, execute_Clear, canExecute_Clear);
            CommandBindings.Add(clearCmd);
        }

        // перевірка наявності тексту
        private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtDocument.Text.Trim().Length > 0;
        }

        // збереження у файл
        private void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            File.WriteAllText("document.txt", txtDocument.Text);
            MessageBox.Show("збережено!");
        }

        // перевірка для відкриття
        private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // зчитування з файлу
        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            if (File.Exists("document.txt"))
            {
                txtDocument.Text = File.ReadAllText("document.txt");
            }
        }

        // перевірка для стирання
        private void canExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtDocument.Text.Length > 0;
        }

        // очищення текстового поля
        private void execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            txtDocument.Clear();
        }
    }
}
