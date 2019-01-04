﻿using System;
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
    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
            //Thread newThread = new Thread(new ThreadStart(FormInit));
            //newThread.Start();
            bitmaps = new List<Bitmap>();
            numberOfModels = 0;
            myMessageBox = new MyMessageBox(messageBoxPanel);
            panels = new List<Panel>();// для создания нескольких конвееров
            random = new Random();
            typeOfNextDetail = typeof(Details.SquareDetailDrawing);
            detailBase = new DetailBase(typeOfNextDetail, Convert.ToInt32(maxCountTextBox.Text));
            conveyers = new List<Conveyer>();
            mechanics = new List<IMechanic>();
            //myMessageBox.AddMessage("первый");
            //myMessageBox.AddMessage("второй");
            //myMessageBox.AddMessage("третий");

        }

        private void DrawPicture(Bitmap bitmap, int numberOfConveyer)
        {
            Bitmap nbitmap = new Bitmap(bitmap, bitmaps[numberOfConveyer - 1].Width, bitmaps[numberOfConveyer - 1].Height);
            //bitmaps[numberOfConveyer - 1] = nbitmap;
            panels[numberOfConveyer - 1].BackgroundImage = nbitmap;
            //panels[numberOfConveyer-1].Invalidate();
        }
        private void ConveyerAdd()
        {
            numberOfModels++;

            //typeOfNextDetail = typeof(Details.SquareDetail);
            //detailBase = new DetailBase(typeOfNextDetail, Convert.ToInt32(maxCountTextBox.Text));
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(panel);
            panel.Height = mainPanel.Height;
            panel.Width = mainPanel.Width / numberOfModels;
            panel.Location = new Point((numberOfModels - 1) * panel.Width,0);
            for(int i = 0; i < numberOfModels-1; i++)
            {
                panels[i].Width = panel.Width;
                panels[i].Location= new Point(i * panel.Width, 0);
            }
            panels.Add(panel);
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.BackgroundImage = bitmap;
            bitmaps.Add(bitmap);

            conveyers.Add(new ConveyerDrawing(Convert.ToInt32(maxCountTextBox.Text), detailBase,bitmap,numberOfModels));
            conveyers[numberOfModels-1].SendMessage += myMessageBox.AddMessage;
            ConveyerDrawing conveyer = conveyers[numberOfModels - 1] as ConveyerDrawing;
            conveyer.DrawPicture += DrawPicture;

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
        private void roundDetailRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            typeOfNextDetail = typeof(Details.RoundDetailDrawing);
            detailBase.Type = typeOfNextDetail;
        }

        private void sphereDetailRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            typeOfNextDetail = typeof(Details.SphereDetailDrawing);
            detailBase.Type = typeOfNextDetail;

        }

        private void squareDetailRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            typeOfNextDetail = typeof(Details.SquareDetailDrawing);
            detailBase.Type = typeOfNextDetail;

        }

        private void conveyerStartButton_Click(object sender, EventArgs e)
        {
            ConveyerAdd();
            startConv();
        }

        private async void startConv()
        {
            await Task.Run(()=>conveyers[numberOfModels-1].StartConveyer(mechanics[numberOfModels - 1]));
        }
    }
}
