using System.Windows.Forms;

namespace FormStone
{
    public class ReturnForm<T> : Form
    {
        public T ValueResult = default(T);
        public DialogResult ShowDialog(out T result, IWin32Window owner = null)
        {
            var (ret, val) = ShowDialog(owner);
            result = val;
            return ret;
        }
        public new (DialogResult result, T value) ShowDialog(IWin32Window owner = null)
        {
            var res = owner == null ? base.ShowDialog() : base.ShowDialog(owner);
            return (res, ValueResult);
        }
        public new void Close()
        {
            base.Close();
        }
        public void Close(T ret, DialogResult res = DialogResult.OK)
        {
            DialogResult = res;
            ValueResult = ret;
            base.Close();
        }
        public void Close(DialogResult res, T ret = default(T))
        {
            Close(ret, res);
        }
    }
}
