using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Заметки.Models
{
    class NotesModel : INotifyPropertyChanged
    {
        public DateTime CreatDate { get; set; } = DateTime.Now; // добавление текущей даты и времени


        private bool _CheckNot;
        public bool CheckNot 
        { 
            get { return _CheckNot; } 
            set 
            { 
                if (_CheckNot == value)
                {
                    return;
                }
                _CheckNot = value;
                OnPropertyChanged("CheckNot");
            }
        }


        private string _ListNot;


        public string ListNot
        {
            get { return _ListNot; }
            set 
            {
                if (_ListNot == value)
                {
                    return;
                }
                _ListNot = value;
                OnPropertyChanged("ListNot");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
