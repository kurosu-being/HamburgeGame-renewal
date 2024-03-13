using System;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        public ResultScreen() {
            InitializeComponent();
        }
        private void ResultScreen_KeyDown(object vSender, KeyEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenu"];

            // Enterを押すとメインフォームを表示
            if (e.KeyCode == Keys.Enter) {

                if (wMainMenuForm != null && wMainMenuForm is MainMenu) {
                    wMainMenuForm.Show();
                } else {// エラーメッセージを表示して例外をスロー
                    throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
                }
                // 現在のフォームを閉じる
                this.Close();
            }
        }
    }
}
