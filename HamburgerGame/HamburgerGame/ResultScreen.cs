using System;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        public ResultScreen() {
            InitializeComponent();
            // キー入力をフォームが優先的に受け取るようにする
            this.KeyPreview = true;
            // フォームのKeyDownイベントにイベントハンドラを関連付ける
            this.KeyDown += ResultScreen_KeyDown;
        }

        private void ResultScreen_KeyDown(object sender, KeyEventArgs e) {
            HandleEnterKeyPress();
        }

        private void HandleEnterKeyPress() {
            var wMainMenuForm = GetOpenForm<MainMenu>("MainMenu");
            this.Close();
        }

        private TForm GetOpenForm<TForm>(string vFormName) where TForm : Form {
            var wForm = Application.OpenForms[vFormName];
            if (wForm == null || !(wForm is TForm)) {
                throw new Exception($"{typeof(TForm).Name} フォームが見つかりませんでした。フォーム名を確認してください。");
            }
            return (TForm)wForm;
        } 

        private void ResultScreen_FormClosing(object sender, FormClosingEventArgs e) {
            var wMainMenuForm = GetOpenForm<MainMenu>("MainMenu");
            var wHamburgerGAME = GetOpenForm<HamburgerGAME>("HamburgerGAME");

            // メインメニューフォームを表示
            wMainMenuForm.Show();
            // ゲーム画面が存在する場合、フォームを閉じる
            wHamburgerGAME?.Close();
        }
    }
}


