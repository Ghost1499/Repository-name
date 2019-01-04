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
    public class ConveyerAddition
    {
        public static void AddConveyer(ref int numberOfModels, ref Panel mainPanel, List<Panel> panels,List<Bitmap> bitmaps, List<Conveyer> conveyers, int maxDetailsCount, DetailBase detailBase, MyMessageBox myMessageBox,List<IMechanic> mechanics, Random random, Type typeOfMechanic )
        {
            numberOfModels++;

            //typeOfNextDetail = typeof(Details.SquareDetail);
            //detailBase = new DetailBase(typeOfNextDetail, Convert.ToInt32(maxCountTextBox.Text));
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(panel);
            panel.Height = mainPanel.Height;
            panel.Width = mainPanel.Width / numberOfModels;
            panel.Location = new Point((numberOfModels - 1) * panel.Width, 0);
            for (int i = 0; i < numberOfModels - 1; i++)
            {
                panels[i].Width = panel.Width;
                panels[i].Location = new Point(i * panel.Width, 0);
            }
            panels.Add(panel);
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.BackgroundImage = bitmap;
            bitmaps.Add(bitmap);

            conveyers.Add(new ConveyerDrawing(maxDetailsCount, detailBase, bitmap, numberOfModels));
            conveyers[numberOfModels - 1].SendMessage += myMessageBox.AddMessage;
            

            if (mechanics.Count <= 2)
            {
                int mechanicCase = random.Next(0, 2);
                switch (mechanicCase)
                {
                    case 0:
                        {
                            typeOfMechanic = typeof(Mechanics.GoodMechanic);
                            break;
                        }
                    case 1:
                        {
                            typeOfMechanic = typeof(Mechanics.MediumMechanic);
                            break;
                        }
                    case 2:
                        {
                            typeOfMechanic = typeof(Mechanics.BadMechanic);
                            break;
                        }
                }
                ConstructorInfo constructor = typeOfMechanic.GetConstructor(new Type[] { typeof(Conveyer) });
                mechanics.Add((IMechanic)constructor.Invoke(new object[] { conveyers[numberOfModels - 1] }));
            }
            else
            {
                mechanics.Add(mechanics[random.Next(0, mechanics.Count)]);
            }
        }
    }
}
