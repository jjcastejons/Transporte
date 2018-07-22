﻿using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            clsSQL clsSQL = new clsSQL();
            InitializeComponent();
            MessageBox.Show("Revise los mensajes importantes que tiene pendientes de visualizar.");
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListVehiculos formulario = new frmListVehiculos();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmListAgenda formulario = new frmListAgenda();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
           
        }

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRutas formulario = new frmListRutas();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListEmpleados formulario = new frmListEmpleados();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsReport OpenReport = new clsReport();
                string filtro;

                filtro = "{Clientes.id_key_cliente } = 1";
                OpenReport.PrintLogon(mdPrincipal.RPT_Ruta_Informes + "CrystalReport2.rpt", mdPrincipal.RPT_Usuario, mdPrincipal.RPT_Password, mdPrincipal.RPT_Server, filtro);
            

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmListClientes formulario = new frmListClientes();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {

        }

        private void testInformeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsReport OpenReport = new clsReport();
            string filtro;

            filtro = "{Clientes.id_key_cliente } = 1";
            OpenReport.PrintLogon(mdPrincipal.RPT_Ruta_Informes + "CrystalReport2.rpt", mdPrincipal.RPT_Usuario, mdPrincipal.RPT_Password, mdPrincipal.RPT_Server, filtro);

        }
    }
}