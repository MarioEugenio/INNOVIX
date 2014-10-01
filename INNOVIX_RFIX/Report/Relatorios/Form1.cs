using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbRFixDataSet.tb_item_report' table. You can move, or remove it, as needed.
            this.tb_item_reportTableAdapter.Fill(this.dbRFixDataSet.tb_item_report);
            // TODO: This line of code loads data into the 'dbRFixDataSet.tb_item' table. You can move, or remove it, as needed.
            //this.tb_itemTableAdapter.Fill(this.dbRFixDataSet.tb_item);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtAtualizacao.Text.Length == 0 && origem.Text.Length == 0 && destino.Text.Length == 0 && awb.Text.Length == 0)
            {
                MessageBox.Show("Preencha pelo menos um campo","Aviso");
                this.tb_item_reportTableAdapter.Fill(this.dbRFixDataSet.tb_item_report);
                this.reportViewer1.RefreshReport();
            }
            else
            {

                this.tb_item_reportTableAdapter.allFilter(this.dbRFixDataSet.tb_item_report, awb.Text);
                this.reportViewer1.RefreshReport();
            }


        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
