using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultScreen : Form {
        private readonly List<Food> FFoods;
        public ResultScreen(List<Food> vFood) {
            InitializeComponent();
            // キー入力をフォームが優先的に受け取るようにする
            this.KeyPreview = true;
            // フォームのKeyDownイベントにイベントハンドラを関連付ける
            this.KeyDown += ResultScreen_KeyDown;

            this.FFoods = vFood;
            DrawCaughtFoods();
            this.Paint += ResultScreen_Paint;
        }
        private void DrawCaughtFoods() {
            int wStartY;
            if (FFoods.Count > 0 && FFoods[0].FoodInfo.Name == "cheese") {
                //最初がチーズの場合のY座標
                wStartY = FBunUnder.Location.Y - 10;
            } else {
                //チーズ以外の場合のY座標
                wStartY = FBunUnder.Location.Y - 40;
            }
            foreach (Food wFood in FFoods) {
                wFood.Rectangle = new Rectangle(FBunUnder.Location.X, wStartY, FBunUnder.Width, FBunUnder.Height);
                wStartY -= 25;
            }
        }

        private void ResultScreen_KeyDown(object sender, KeyEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenuForm"];
            if (e.KeyCode == Keys.Enter) {
                this.Close();
            }
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
            wHamburgerGAME.Close();
        }
        private void label2_Click(object sender, EventArgs e) {
            var wMainMenu = Application.OpenForms["MainMenu"];

            if (wMainMenu != null && wMainMenu is MainMenu) {
                wMainMenu.Show();
            } else {// エラーメッセージを表示して例外をスロー
                throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
            }
            // 現在のフォームを閉じる
            this.Close();
        }

        private void DrawBunUnder(Graphics g) {
            // bun_under イメージを描画する矩形を作成
            var wDestinationRect = new Rectangle(FBunUnder.Location.X, FBunUnder.Location.Y, FBunUnder.Width, FBunUnder.Height);
            // bun_under イメージを描画
            g.DrawImage(Properties.Resources.bun_under, wDestinationRect);
        }
        private void DrawDish(Graphics g) {
            // dish イメージを描画する矩形を作成
            var wDestinationRect = new Rectangle(FDish.Location.X, FDish.Location.Y, FDish.Width, FDish.Height);
            // dish イメージを描画
            g.DrawImage(Properties.Resources.dish, wDestinationRect);
        }

        private void ResultScreen_Paint(object sender, PaintEventArgs e) {
            DrawDish(e.Graphics);
            DrawBunUnder(e.Graphics);
            foreach (Food wFood in FFoods) {
                wFood.Draw(e.Graphics);
            }
        }
    }
}



