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
                    // 現在のフォームを閉じる
                    this.Close();
                } else {// エラーメッセージを表示して例外をスロー
                    throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
                }
            }
        }

        private void ResultScreen_FormClosing(object sender, FormClosingEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenu"];
            var wHamburgerGAME = Application.OpenForms["HamburgerGAME"];

            if (wMainMenuForm == null || !(wMainMenuForm is MainMenu)) {
                throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
            }

            if (wHamburgerGAME == null || !(wHamburgerGAME is HamburgerGAME)) {
                throw new Exception("ハンバーガーゲームフォームが見つかりませんでした。開発者に連絡してください。");
            }

            // クローズ理由がユーザーによる×ボタンのクリックかどうかを確認
            if (e.CloseReason == CloseReason.UserClosing) {
                // 確認ダイアログを表示
                DialogResult wResult = MessageBox.Show("MainMenuに戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // ダイアログの結果によって処理を分岐
                if (wResult == DialogResult.Yes) {

                    // メインメニューフォームを表示
                    wMainMenuForm.Show();

                    // ゲーム画面が存在する場合、破棄する
                    if (wHamburgerGAME != null) {
                        wHamburgerGAME.Dispose();
                    }
                }
            }
        }
    }
}
