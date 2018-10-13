using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SimpleMvvm
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        private Person _modelPerson;
        public Person ModelPerson
        {
            get { return _modelPerson; }
            set
            {
                _modelPerson = value;
                OnPropertyChanged("ModelPerson");
            }
        }

        private SavePersonCommand _savePersonCommand;
        public SavePersonCommand SavePersonCommand
        {
            get { return _savePersonCommand; }
            set
            {
                _savePersonCommand = value;
                OnPropertyChanged("SavePersonCommand");
            }
        }

        #endregion //Properties

        #region Constructors

        public MainViewModel()
        {
            InitializeCommands();
            LoadPerson();
        }

        #endregion //Constructors

        #region Methods

        private void LoadPerson()
        {
            ModelPerson = new Person()
            {
                FirstName = "Brian",
                LastName = "Lagunas",
                Age = 30
            };
        }

        private void InitializeCommands()
        {
            SavePersonCommand = new SavePersonCommand(UpdatePerson);
        }

        private void UpdatePerson()
        {
            ModelPerson.LastUpdated = DateTime.Now;
        }

        #endregion //Methods

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged
    }

    public class SavePersonCommand : ICommand
    {
        Action _executeMethod;

        public SavePersonCommand(Action executeAction)
        {
            _executeMethod = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeMethod.Invoke();
        }
    }
}