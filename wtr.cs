using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUNYNE
{
    public partial class wtr : Form
    {
        public wtr()
        {
            InitializeComponent();
            this.BackColor = Color.Gray; // Цвет, который будет прозрачным
            this.TransparencyKey = Color.Gray; // Устанавливаем прозрачный цвет
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(5, 10);
            this.FormBorderStyle = FormBorderStyle.None; // Можно сделать форму без возможности изменения размера
            this.MaximizeBox = false; // Запретить кнопку "Развернуть"
            this.MinimizeBox = false; // Запретить кнопку "Свернуть"
            this.TopMost = true;
        }

        private void wtr_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
