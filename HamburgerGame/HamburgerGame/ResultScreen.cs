using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        public ResultScreen() {
            InitializeComponent();
        }
        private void ResultScreen_KeyDown(object vSender, KeyEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenu"];
            // Yを押すとメインフォームを表示
            if (e.KeyCode == Keys.Y) {
                if (wMainMenuForm != null && wMainMenuForm is MainMenu) {
                    wMainMenuForm.Show();
                } else {
                    MessageBox.Show("MainMenuフォーム名でnull参照がありました。フォームの名前を確認してください。");
                }
                this.Close(); // リザルト画面を閉じる
            }
            // Nを押すとすべてのフォームを閉じる
            else if (e.KeyCode == Keys.N) {
                Application.Exit();
            }
        }
    }
}