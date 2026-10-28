using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Metadata;
using AvaloniaApplication2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApplication2.Views;

public partial class MainWindow : Window
{

    private ObservableCollection<TaskItem> _tasks = new();
    private readonly AppDbContext dbContext;
    public MainWindow()
    {
        InitializeComponent();

        this.Loaded += (s, e) => 
        {
            if (DataContext is MainViewModel vm)
            {
                vm.InitPictures(); 
            }
        };
        
        TextElement.SetFontFamily(this, new FontFamily("Consolas"));
        MinWidth = 800;
        MinHeight = 500;

        MaxWidth = 800;
        MaxHeight = 500;

        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        dbContext = new AppDbContext();
        dbContext.Database.EnsureCreated();

        LoadTasks();

        ListBox_1.ItemsSource = _tasks;

    }
    public void AddToListOnKey(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            AddTask();
        }
    }

    public void RemoveFromList(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is TaskItem task)
        {
            _tasks.Remove(task);
            dbContext.Remove(task);
            dbContext.SaveChanges();
        }
    }

    private void CompleteButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is TaskItem task)
        {
            task.IsCompleted = !task.IsCompleted;
            if (task.IsCompleted)
            {
                button.Content = "Complete";
                button.Foreground = new SolidColorBrush(Colors.SpringGreen);
            }

        }
    }

    private void LoadTasks()
    {
        var tasks = dbContext.Items.OrderBy(t => t.Id).ToList();
        _tasks.Clear();

        foreach (var task in tasks)
        {
            _tasks.Add(task);
        }
    }

    private void AddTask()
    {
        var text = TextBox_1.Text?.Trim();
        if (DataContext is MainViewModel vm)
        {
            vm.SetEmoteO();
        }

        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        var newTask = new TaskItem
        {
            Text = text,
            IsCompleted = false
        };

        dbContext.Items.Add(newTask);
        dbContext.SaveChanges();  // Здесь выполняется INSERT в SQLite

        // Добавляем в список для отображения
        _tasks.Add(newTask);

        TextBox_1.Text = string.Empty;
        TextBox_1.Focus();
    }

}