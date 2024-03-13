using System;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        public ResultScreen() {
            InitializeComponent();
        }
        private void ResultScreen_KeyDown(object vSender, KeyEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenu"];

            switch (e.KeyCode) {
                case Keys.Y:
                    if (wMainMenuForm != null && wMainMenuForm is MainMenu) {
                        wMainMenuForm.Show();
                    } else {
                        // エラーメッセージを表示して例外をスロー
                        throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
                    }
                    this.Close(); // リザルト画面を閉じる
                    break;

                // Nを押すとすべてのフォームを閉じる
                case Keys.N:
                    Application.Exit();
                    break;
            }
        }
    }
}
