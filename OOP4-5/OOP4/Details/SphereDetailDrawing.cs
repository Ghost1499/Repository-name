using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Details
{
    class SphereDetailDrawing : SphereDetail, IDetailDrawing
    {
        //public Graphics Graphics { get; }
        public Rectangle Rectangle { get; set; }

        public void DrawDetail(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, Rectangle);
        }
    }
}
