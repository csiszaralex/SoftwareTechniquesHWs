using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HelloXaml.Models;
using System.Collections.ObjectModel;

namespace HelloXaml.ViewModels
{
    public partial class PersonListPageViewModel : ObservableObject
    {
        public Person NewPerson { get; set; }
        public ObservableCollection<Person> People { get; set; }
        //public readonly RelayCommand DecreaseAgeCommand;
        public readonly RelayCommand IncreaseAgeCommand;

        public PersonListPageViewModel()
        {
            NewPerson = new Person()
            {
                Name = "Eric Cartman",
                Age = 8
            };

            People = new ObservableCollection<Person>()
            {
                new Person() { Name = "Peter Griffin", Age = 40 },
                new Person() { Name = "Homer Simpson", Age = 42 },
            };

            NewPerson.PropertyChanged += (s, e) => OnPropertyChanged(nameof(IsAddPersonEnabled));
            NewPerson.PropertyChanged += (s, e) => IncreaseAgeCommand.NotifyCanExecuteChanged();
            NewPerson.PropertyChanged += (s, e) => DecreaseAgeCommand.NotifyCanExecuteChanged();

            //DecreaseAgeCommand = new RelayCommand(() => NewPerson.Age--, () => NewPerson.Age > 0);
            IncreaseAgeCommand = new RelayCommand(() => NewPerson.Age++, () => NewPerson.Age < 150);
        }

        public void AddPersonToList()
        {
            People.Add(new Person()
            {
                Name = NewPerson.Name,
                Age = NewPerson.Age,
            });

            NewPerson.Name = string.Empty;
            NewPerson.Age = 0;
        }
        [RelayCommand(CanExecute = nameof(IsDecrementEnabled))]
        public void DecreaseAge()
        {
            NewPerson.Age--;
        }
        public bool IsDecrementEnabled()
        {
            return NewPerson.Age > 0;
        }
        public bool IsAddPersonEnabled
        {
            get { return !string.IsNullOrWhiteSpace(NewPerson.Name); }
        }
    }
}
