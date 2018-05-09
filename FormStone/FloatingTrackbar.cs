using System;
using System.Windows.Forms;

namespace FormStone
{
    public class FloatingTrackbar : TrackBar
    {
        private double? _value = null;
        public double valMax { get; set; } = 1;
        public double valMin { get; set; } = 0;
        public new double Value
        {
            get
            {
                if (!_value.HasValue)
                    _value = ((base.Value - Minimum) / (double)(Maximum - Minimum)) * (valMax - valMin) + valMin;
                return _value.Value;
            }
            set
            {
                _value = value;
                base.Value = (int)((value - valMin) / (valMax - valMin) * (Maximum- Minimum)) + Minimum;
            }
        }
        public void setResolution(int ticks)
        {
            var value = Value;
            Minimum = 0;
            Maximum = ticks;
            LargeChange = (int)Math.Sqrt(ticks);
            SmallChange = 1;
            TickFrequency = 1;
            this.Value = value;
        }
    }
}
