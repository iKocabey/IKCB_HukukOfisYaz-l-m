using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;

namespace IKCB_Law_Office
{
    public partial class frmIstatistikDetay : Form
    {
        public frmIstatistikDetay()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIstatistikDetay_Load(object sender, EventArgs e)
        {
            pvDetayliistatistik.Model = new PlotModel();
            FunctionSeries fs = new FunctionSeries();
            FunctionSeries fs2 = new FunctionSeries();
            fs.Points.Add(new DataPoint(0, 0));
            fs.Points.Add(new DataPoint(10, 10));
            fs.Points.Add(new DataPoint(20, 5));

            fs2.Points.Add(new DataPoint(0, 15));
            fs2.Points.Add(new DataPoint(10, 40));
            fs.Points.Add(new DataPoint(20, 2));
            
            pvDetayliistatistik.Model.Series.Add(fs);
            pvDetayliistatistik.Model.Series.Add(fs2);
            
            //pvDetayliistatistik.Model.Series.Add(new Series(dizi));
            //pvDetayliistatistik.Model.Series.Add(new FunctionSeries(Math., 0, 10, 0.1, "cos(x)"));
            //pvDetayliistatistik.Model.Series.Add(new FunctionSeries(Math.Tan, 0, 10, 0.1, "tan(x)"));

        }
    }
}
