using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP4
{
    public class MyMessageBox
    {
        //static object locObject;
        //delegate void Del(string text);
        public List<Label> lines;
        public MyMessageBox(Control control)
        {
            lines = new List<Label>();
            MyMessageBoxCreate(control);
            //locObject = new object();
        }
        public void AddMessage(string message)
        {
            for (int i = lines.Count - 1; i >= 1; i--)
            {
                SetTextSafe(lines[i - 1].Text,i);
            }
            //lock(locObject)
            //lines[0].Text = message;
            SetTextSafe(message,0);
        }

        private void SetTextSafe(string newText, int i)
        {
            if (lines[i].InvokeRequired) lines[i].Invoke(new Action<string>((s) => lines[i].Text = s), newText);
            else lines[i].Text = newText;
        }
        private void MyMessageBoxCreate(Control control)
        {
            int d = 2;
            int dist = control.Height;
            Font font = new Font("Arial", 8);
            int h = /*(int)*/font.Height;
            while (dist >= h + d)
            {
                dist -= d;
                Label label = new Label();
                label.AutoSize = true;
                label.Location = new Point(d, control.Height - dist);
                label.Font = font;
                lines.Add(label);
                dist -= h;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                control.Controls.Add(lines[i]);
            }
        }
    }
}
