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

                // MainMenuフォーム
                using (var wMainMenuForm = new MainMenu()) {
                    wMainMenuForm.Show();

                // MainFormフォームのリソースを解放する
                wMainMenuForm.Dispose();
                }

                // 現在のフォームを閉じる
                this.Close();
                    
            }
            // Nキーが押された場合
            if (e.KeyCode == Keys.N) {
                // 画面を閉じる
                this.Close();
            }
        }
    }
}
