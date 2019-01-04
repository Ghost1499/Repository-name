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

namespace OOP4.Details
{
    interface IDetailDrawing:IDetail
    {
        Rectangle Rectangle { get; set; }
        //Graphics Graphics { get; }
        void DrawDetail(Graphics graphics);
    }
}
