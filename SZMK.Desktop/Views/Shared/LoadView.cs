using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Views.Shared
{
    public partial class LoadView : Form, ILoadView
    {
        public LoadView()
        {
            InitializeComponent();
        }

        public string Status { set => label1.Text = value; }

        public Form Form => this;
    }
}
