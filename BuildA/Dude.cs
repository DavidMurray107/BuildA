using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BuildA
{

    public class CheckedListItem<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;
        private T item;

        public CheckedListItem()
        { }

        public CheckedListItem(T item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }

        public T Item
        {
            get { return item; }
            set
            {
                item = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
            }
        }


        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
    public class Dude
    {
        public int Shirt { get; set; }
        public int Eyes { get; set; }
        public int Mouth { get; set; }
        public int Star { get; set; }
        public int Eyebrow { get; set; }

        public string ID { get; set; }
        public Dude(int s, int e, int m, int st, int ey) { Shirt = s; Eyes = e; Mouth = m; Star = st; Eyebrow = ey; ID = this.ToString(); }

        public override string ToString()
        {
            string retString = Shirt + " " + Eyes + " " + Mouth + " " + Star + " " + Eyebrow;
            return retString;
        }
    }
}
