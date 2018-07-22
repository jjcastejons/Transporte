using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportes
{
    public partial class frmVerInformes : Form
    {
        public frmVerInformes()
        {
            InitializeComponent();
        }

        public void visorRPT_Load(System.Object sender, System.EventArgs e)
        {
            visorRPT.Zoom(2);
        }
    }
}
