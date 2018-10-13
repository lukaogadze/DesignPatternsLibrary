using System;
using System.ComponentModel;

namespace SimpleMvvm
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Properties

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        private DateTime _lastUpdated = DateTime.Now;
        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                _lastUpdated = value;
                OnPropertyChanged("LastUpdated");
            }
        }

        #endregion //Properties

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged

        #region IDataErrorInfo

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(_firstName))
                        {
                            error = "First Name required";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(_lastName))
                        {
                            error = "Last Name required";
                        }
                        break;
                    case "Age":
                        if ((_age < 18) || (_age > 85))
                        {
                            error = "Age out of range.";
                        }
                        break;
                }
                return (error);
            }
        }

        #endregion //IDataErrorInfo
    }
}
