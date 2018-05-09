using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormStone
{
    public static class LocationMaintainance
    {
        public static double partVisible(this Rectangle @this, IEnumerable<Rectangle> workingAreas = null)
        {
            workingAreas = workingAreas ?? Screen.AllScreens.Select(a => a.WorkingArea);
            return workingAreas.Select
                (area => Rectangle.Intersect(@this, area))
                .Sum(r => (r.Width * r.Height));
        }
        public static void Maintain(this Form @this, System.Configuration.ApplicationSettingsBase settings, string recPropertyId, bool checkWorkingArea = true)
        {
            @this.Load += (sender, args) =>
            {
                Rectangle rec = (Rectangle)settings[recPropertyId];
                if (checkWorkingArea)
                {
                    if (partVisible(rec) < 0.01)
                        return;
                }
                if (!rec.IsEmpty)
                {
                    @this.Location = rec.Location;
                    @this.Size = rec.Size;
                }
            };
            @this.Closing += (sender, args) =>
            {
                Point loc = @this.Location;
                var s = @this.WindowState == FormWindowState.Normal ? @this.Size : @this.RestoreBounds.Size;
                settings[recPropertyId] = new Rectangle(loc, s);
                settings.Save();
            };
        }
    }
}
