﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelos.Context;
using controladores;
using dulce_aroma.Forms.turnos;

namespace dulce_aroma.Forms.menu
{
    public partial class MenuForm : Form
    {
        public Empleados Empleado { get; set; }
        public MenuForm(Empleados e)
        {
            this.Empleado = e;
            InitializeComponent();
        }

        private void bienvenida()
        {
            this.Text = $"SISTEMA DULCE AROMA - {this.Empleado.nombre_completo}";
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            bienvenida();
            if(this.Empleado.idNivel != 1)
            {
                toolStripLabel1.Enabled = false;
                nuevaEntradaToolStripMenuItem.Enabled = false;
                nuevoProductoToolStripMenuItem.Enabled = false;
                nuevoProveedorToolStripMenuItem1.Enabled = false;
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var empFrm = new empleados.EmpleadosForm();
            empFrm.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inventarios.InventarioForm();
            frm.ShowDialog();
        }

        private void nuevoProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var provFrm = new proveedores.ProveedorForm();
            provFrm.ShowDialog();
        }

        private void nuevaEntradaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new entradas.EntradasForm(this.Empleado);
            frm.ShowDialog();
        }

        private void turnoActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new turnos.TurnoForm(this.Empleado);
            frm.ShowDialog();
        }

        private async void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnoController tc = new TurnoController();
            var turno = await tc.ObtenerActivo();
            if (turno.isActive)
            {
                var frm = new ventas.FormVenta(this.Empleado);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay turno activo.","Abra un turno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void informeDeTurnoActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vCtrl = new VentasController();
            var tCtrl = new TurnoController();
            var hayTurno = await tCtrl.ObtenerUltimoTurnoConcluido();
            if(!hayTurno.exists)
            {
                MessageBox.Show("No hay turno.", "Abra un turno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var turno = hayTurno.turno;
            var ventasPorTurno = await vCtrl.ObtenerPorTurno(turno.id);
            var ventasR = ventasPorTurno.Select(v => new ReporteVentaModel()
            {
                fecha = v.fecha,
                hora = v.hora,
                id = v.id,
                importe = v.importe
            }).ToList();
            var totalVentas = ventasR.Count();
            decimal importeVentas = 0;
            foreach (var v in ventasR)
            {
                importeVentas += v.importe;
            }

            var frmRpt = new ReporteDeTurno(ventasR, turno.Empleados.nombre_completo, turno.fecha_apertura.ToString("d"), turno.hora_apertura.ToString("t"), turno.fecha_cierre?.ToString("d"), turno.hora_cierre?.ToString("t"), totalVentas.ToString(), importeVentas.ToString());
            frmRpt.ShowDialog();
        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new helpers.CambiarPassHelper(this.Empleado);
            frm.ShowDialog();
        }
    }
}
