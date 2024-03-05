using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        public ResultScreen() {
            InitializeComponent();
        }

        private void Form1_KeyDown(object vSender, KeyEventArgs e) {
            // Yキーが押された場合
            if (e.KeyCode == Keys.Y) {
                // 続ける処理を行う
                MessageBox.Show("続けます");
            }
            // Nキーが押された場合+
            else if (e.KeyCode == Keys.N) {
                // 画面を閉じる
                this.Close();
            }
        }





        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
