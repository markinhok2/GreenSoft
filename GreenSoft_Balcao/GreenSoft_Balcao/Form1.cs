using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreenSoft_Balcao.Data;

namespace GreenSoft_Balcao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (dbGreenSoftFinalEntities dx = new dbGreenSoftFinalEntities())
            {
                Cooperativa cooperativa = new Cooperativa();
                cooperativa.Razao = "Cooperativa de Sucata de Garça";
                cooperativa.Cnpj = "25626430000144";
                cooperativa.Ativo = true;
                dx.Cooperativa.Add(cooperativa);
                dx.SaveChanges();
            }

        }
    }
}
