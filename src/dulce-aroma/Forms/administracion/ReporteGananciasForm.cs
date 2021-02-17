﻿using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dulce_aroma.Forms.administracion
{
    public partial class ReporteGananciasForm : Form
    {
        public ReporteGananciasForm(List<ProductoGananciaModel> articulosEnTurno, GananciaPorTurnoModel ganancia)
        {
            InitializeComponent();
            var rptH = new ReportClass();
            rptH.FileName = @"C:\dulce-aroma-reportes\ReporteGananciasPorTurnoCrv.rpt";
            rptH.Load();
            rptH.SetDataSource(articulosEnTurno);
            rptH.SetParameterValue("pNoTurno", ganancia.NoTurno);
            rptH.SetParameterValue("pFechaApertura", ganancia.FechaApertura);
            rptH.SetParameterValue("pHoraApertura", ganancia.HoraApertura);
            rptH.SetParameterValue("pFechaCierre", ganancia.FechaCierre);
            rptH.SetParameterValue("pHoraCierre", ganancia.HoraCierre);
            rptH.SetParameterValue("pEmpleado", ganancia.Empleado);
            rptH.SetParameterValue("pCantProductos", ganancia.CantProductos);
            rptH.SetParameterValue("pImportePorPrecio", ganancia.ImportePorPrecio);
            rptH.SetParameterValue("pImportePorCosto", ganancia.ImportePorCosto);
            rptH.SetParameterValue("pGananciaTurno", ganancia.GananciaTurno);
            crv.ReportSource = rptH;
            crv.Refresh();
        }
    }
}
