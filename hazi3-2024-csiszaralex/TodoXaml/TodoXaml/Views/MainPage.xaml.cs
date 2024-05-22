using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System;
using TodoXaml.Models;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TodoXaml.Views;

public sealed partial class MainPage : Page, INotifyPropertyChanged
{
    public List<Priority> Priorities { get; } = Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList();
    public ObservableCollection<TodoItem> Todos { get; set; } = new()
    {
        new()
        {
            Id = 3,
            Title = "Add Neptun code to neptun.txt",
            Description = "PL4XKM",
            Priority = Priority.Normal,
            IsDone = false,
            Deadline = new DateTime(2024, 11, 08)
        },
        new()
        {
            Id = 1,
            Title = "Buy milk",
            Description = "Should be lactose and gluten free!",
            Priority = Priority.Low,
            IsDone = true,
            Deadline = DateTimeOffset.Now + TimeSpan.FromDays(1)
        },
        new()
        {
            Id = 2,
            Title = "Do the Computer Graphics homework",
            Description = "Ray tracing, make it shiny and gleamy! :)",
            Priority = Priority.High,
            IsDone = false,
            Deadline = new DateTime(2024, 11, 08)
        },
    };
    private TodoItem newT = null;
    public TodoItem newTodo
    {
        get => newT;
        set
        {
            newT = value;
            if (newT == null) isFormVisible = false;
            else isFormVisible = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isFormVisible)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(newTodo)));
        }
    }
    public bool isFormVisible;
    public int? selectedIndex;

    public event PropertyChangedEventHandler PropertyChanged;

    public MainPage()
    {
        InitializeComponent();
    }
    public static Brush GetForeground(Priority p)
    {
        switch (p)
        {
            case Priority.Low:
                return new SolidColorBrush(Colors.LightSkyBlue);
            case Priority.Normal:
                return (Brush)App.Current.Resources["ApplicationForegroundThemeBrush"];
            case Priority.High:
                return new SolidColorBrush(Colors.IndianRed);
            default:
                return new SolidColorBrush(Colors.Black);
        }
    }
    public static int GetPriorityIndex(Priority p)
    {
        return p switch
        {
            Priority.Low => 0,
            Priority.Normal => 1,
            Priority.High => 2,
            _ => 1
        };
    }

    private void AppBarButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        newTodo = new();
    }

    private void Add_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        //save vagy update
        if (newTodo.Id == null)
        {
            int maxId = Todos.Max(x => x.Id) ?? -1;
            newTodo.Id = maxId + 1;
            Todos.Add(newTodo);
            newTodo = null;
        }
        else
        {
            Todos[newTodo.Id.Value] = newTodo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todos)));
            newTodo = null;
        }
    }


    private void todo_list_ItemClick(object sender, ItemClickEventArgs e)
    {
        newTodo = e.ClickedItem as TodoItem;
    }
}
