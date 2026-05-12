using System;
using System.Windows;
using System.Windows.Input;

namespace lab3
{
    // модель запису
    public class Note
    {
        public string Text { get; set; }
        public string Timestamp { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // перевірка можливості додавання
        private void AddNote_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtNoteEntry != null && !string.IsNullOrWhiteSpace(txtNoteEntry.Text);
        }

        // логіка фіксації запису
        private void AddNote_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var newNote = new Note
            {
                Text = txtNoteEntry.Text.Trim(),
                Timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")
            };

            lbJournal.Items.Insert(0, newNote); // додаємо на початок списку
            txtNoteEntry.Clear();               // очищуємо поле
            txtNoteEntry.Focus();               // повертаємо фокус
        }

        // перевірка можливості очищення
        private void Clear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = lbJournal != null && lbJournal.Items.Count > 0;
        }

        // очищення журналу
        private void Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Видалити всі записи?", "Підтвердження", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                lbJournal.Items.Clear();
            }
        }
    }
}