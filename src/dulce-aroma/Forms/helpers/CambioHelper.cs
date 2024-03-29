﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dulce_aroma.Forms.helpers
{
    public partial class CambioHelper : Form
    {
        public decimal Cambio { get; set; }
        public decimal PagoCon { get; set; }
        public decimal Importe { get; set; }
        public CambioHelper(decimal importe)
        {
            this.Importe = importe;
            this.Cambio = 0;
            this.PagoCon = 0;
            InitializeComponent();
        }

        private void CambioHelper_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
            }
            if(e.KeyCode == Keys.Enter)
            {
                var result = MessageBox.Show("¿Imprimir Ticket?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
        }

        private void CambioHelper_Load(object sender, EventArgs e)
        {
            this.txtpagoCon.Select();
            this.txtpagoCon.Focus();
            this.txtpagoCon.LostFocus += TxtpagoCon_LostFocus;
            this.Text = $"CAMBIO DEL IMPORTE: ${this.Importe}";
        }

        private void TxtpagoCon_LostFocus(object sender, EventArgs e)
        {
            this.txtpagoCon.Focus();
        }

        private void txtpagoCon_TextChanged(object sender, EventArgs e)
        {
            if (txtpagoCon.Text.Length == 0) 
            {
                this.PagoCon = 0;
                this.Cambio = 0;
                return;
            }
            // Validar si es < 0
            /*
                SI EL PAGO ES MAYOR AL IMPORTE ?
            */
            var cambio = Convert.ToDecimal(this.txtcambio.Text.Trim());
            var pagoCon = Convert.ToDecimal(this.txtpagoCon.Text.Trim());
            this.PagoCon = pagoCon;
            this.Cambio = (pagoCon - Importe);
            this.txtcambio.Text = (pagoCon - Importe).ToString();
            if(cambio < 0)
            {
                this.Cambio = 0;
                this.txtcambio.Text = "0";
            }
            if(pagoCon < 0)
            {
                this.PagoCon = 0;
                this.txtpagoCon.Text = "0";
            }
            if(pagoCon < this.Importe)
            {
                this.txtcambio.Text = "0";
                this.PagoCon = this.Importe;
                this.Cambio = 0;
            }
        }

        private void txtpagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
