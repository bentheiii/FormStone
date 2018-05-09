using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStone
{
    public class ReturnControlReturnedEventArgs<T> : EventArgs
    {
        public ReturnControlReturnedEventArgs(T data)
        {
            this.data = data;
        }
        public T data { get; }
    }
    public delegate void ReturnControlReturned<T>(object sender, ReturnControlReturnedEventArgs<T> eventArgs);
    public class ReturnControl<T> : UserControl
    {
        public bool SelfDispose { get; set; }

        public event ReturnControlReturned<T> Returned;
        protected void Return(T ret)
        {
            Returned.Invoke(this, new ReturnControlReturnedEventArgs<T>(ret));

            if (SelfDispose)
                Dispose();
        }
    }
}
