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
        int numberOfModels;
        MyMessageBox myMessageBox;
        List<Panel> panels;
        List<Conveyer> conveyers;
        DetailBase detailBase;
        Type typeOfNextDetail;
        Type typeOfMechanic;
        List<IMechanic> mechanics;
        Random random;
        List<Bitmap> bitmaps;

        public ConveyerAddition(Panel messageBoxPanel, TextBox maxCountTextBox)
        {
            Bitmaps = new List<Bitmap>();
            NumberOfModels = 0;
            MyMessageBox = new MyMessageBox(messageBoxPanel);
            Panels = new List<Panel>();// для создания нескольких конвееров
            Random = new Random();
            TypeOfNextDetail = typeof(Details.SquareDetailDrawing);
            DetailBase = new DetailBase(TypeOfNextDetail, Convert.ToInt32(maxCountTextBox.Text));
            Conveyers = new List<Conveyer>();
            Mechanics = new List<IMechanic>();
        }

        public int NumberOfModels { get => numberOfModels; set => numberOfModels = value; }
        public MyMessageBox MyMessageBox { get => myMessageBox; set => myMessageBox = value; }
        public List<Panel> Panels { get => panels; set => panels = value; }
        public List<Conveyer> Conveyers { get => conveyers; set => conveyers = value; }
        public DetailBase DetailBase { get => detailBase; set => detailBase = value; }
        public Type TypeOfNextDetail { get => typeOfNextDetail; set => typeOfNextDetail = value; }
        public Type TypeOfMechanic { get => typeOfMechanic; set => typeOfMechanic = value; }
        public List<IMechanic> Mechanics { get => mechanics; set => mechanics = value; }
        public Random Random { get => random; set => random = value; }
        public List<Bitmap> Bitmaps { get => bitmaps; set => bitmaps = value; }

        public void AddConveyer(ref Panel mainPanel,TextBox maxCountTextBox)
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

            conveyers.Add(new ConveyerDrawing(Convert.ToInt32(maxCountTextBox.Text), detailBase, bitmap, numberOfModels));
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
