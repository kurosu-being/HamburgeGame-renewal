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

        private void ResultScreen_KeyDown(object vSender, KeyEventArgs e) {
            // Yキーが押された場合
            if (e.KeyCode == Keys.Y) {
                // MainMenuフォームを作成
                //var wMainMenuForm = new MainMenu();
                var wHamburgerGAME = new HamburgerGAME();
                // MainMenuフォームを表示
                //wMainMenuForm.Show();
                wHamburgerGAME.Show();

                // 現在のフォームを非表示にする
                this.Hide();
            }
            // Nキーが押された場合
            else if (e.KeyCode == Keys.N) {
                // 画面を閉じる
                this.Close();
            }
        }
    }
}

