using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP4.Details;
using System.Threading;
using System.Reflection;

namespace OOP4
{
    class ConveyerDrawing: Conveyer
    {
        Bitmap bitmap;
        Graphics graphics;
        int h;
        int w;
        int d;
        List<Rectangle> rectangles;

        public ConveyerDrawing(int maxDetailsCount, DetailBase detailBase, Bitmap bitmap, int numberOfConveyer) : base(maxDetailsCount, detailBase, numberOfConveyer)
        {
            this.bitmap = bitmap;
            graphics = Graphics.FromImage(bitmap);
            h = bitmap.Height * 5 / 6 / maxDetailsCount;
            d = bitmap.Height / 6 / (maxDetailsCount + 1);
            w = bitmap.Width / 3;
            rectangles = new List<Rectangle>();
            for(int i = 0; i < maxDetailsCount; i++)
            {
                rectangles.Add(new Rectangle(bitmap.Width / 2 - w / 2, bitmap.Height - (i * (d + h)), w, h));
            }
            
        }
        public delegate void Drawhandler(Bitmap bitmap, int numberOfConveyer);
        public event Drawhandler DrawPicture;
        protected override void ShapeDetail(object obj)
        {
            ConveyerMove();
            base.ShapeDetail(obj);
        }

        public override void StartConveyer(IMechanic mechanic)
        {
            //ConveyerMove();
            base.StartConveyer(mechanic);
        }
        private void ConveyerMove()
        {
            bitmap = new Bitmap(bitmap.Height,bitmap.Width);
            graphics = Graphics.FromImage(bitmap);
            for(int i= production.MaxDetailsCount-1; (i >= 0)&&(production.Details.Count - ((production.MaxDetailsCount - 1) - i) - 1)>=0; i--)
            {

                IDetailDrawing detailDrawing = production.Details.ElementAt(production.Details.Count-((production.MaxDetailsCount-1)-i)-1) as IDetailDrawing;
                //IDetailDrawing ldetailDrawing = production.Details.ElementAt(i + 1) as IDetailDrawing;
                detailDrawing.Rectangle = rectangles[i];
                detailDrawing.DrawDetail(graphics);
            }
            DrawPicture(bitmap, numberOfConveyer);
        }
    }
}
