﻿using CalculationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class ConnectDataBaseForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> ConnectEvent;

        public ConnectDataBaseForm()
        {
            InitializeComponent();
        }

        private void ConnectDataBaseLoad(object sender, EventArgs e)
        {
            NameServer.Text = @"DESKTOP-M77O4Q0\SQLEXPRESS";
            NameDB.Text = "CharacteristicsDB";
        }

        private void ConnectDataBaseClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ConnectDBClick(object sender, EventArgs e)
        {
            string connectionString = DataBaseQuerys.ConnectToDB(NameServer.Text, NameDB.Text);
            ConnectEvent.Invoke(this, connectionString);
            this.Close();
        }

        private void CancellationClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}