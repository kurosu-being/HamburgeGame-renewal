using System;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class ResultForm : Form {
        private readonly GameLogic FGameLogic;
        public ResultForm(GameLogic vGameLogic) {
            InitializeComponent();
            this.FGameLogic = vGameLogic;
            DrawCaughtFoods();
            this.Paint += ResultForm_Paint;
        }
        private void DrawCaughtFoods() {
            int wStartY;
            if (FGameLogic.CaughtFoodList.Count > 0 && FGameLogic.CaughtFoodList[0].FoodInfo.Name == "cheese") {
                //最初がチーズの場合のY座標
                wStartY = FBunUnder.Location.Y -10;
            } else {
                //チーズ以外の場合のY座標
                wStartY = FBunUnder.Location.Y - 40;
            }
            foreach (Food wFood in FGameLogic.CaughtFoodList) {
                wFood.Rectangle = new Rectangle(FBunUnder.Location.X, wStartY, FBunUnder.Width, FBunUnder.Height);
                wStartY -= 25;
            }
        }
        private void ResultForm_KeyDown(object vSender, KeyEventArgs e) {
            var wMainMenuForm = Application.OpenForms["MainMenuForm"];

            // Enterを押すとメインフォームを表示
            if (e.KeyCode == Keys.Enter) {

                if (wMainMenuForm != null && wMainMenuForm is MainMenuForm) {
                    wMainMenuForm.Show();
                } else {// エラーメッセージを表示して例外をスロー
                    throw new Exception("メインメニューフォームが見つかりませんでした。開発者に連絡してください。");
                }
                // 現在のフォームを閉じる
                this.Close();
            }
        }
        private void ResultForm_Paint(object sender, PaintEventArgs e) {
            DrawDish(e.Graphics);
            DrawBunUnder(e.Graphics);
            foreach (Food wFood in FGameLogic.CaughtFoodList) {
                wFood.Draw(e.Graphics);
            }
        }
        private void DrawBunUnder(Graphics g) {
            // bun_under イメージを描画する矩形を作成
            Rectangle wDestinationRect = new Rectangle(FBunUnder.Location.X, FBunUnder.Location.Y, FBunUnder.Width, FBunUnder.Height);
            // bun_under イメージを描画
            g.DrawImage(Properties.Resources.bun_under, wDestinationRect);
        }
        private void DrawDish(Graphics g) {
            // dish イメージを描画する矩形を作成
            Rectangle wDestinationRect = new Rectangle(FDish.Location.X, FDish.Location.Y, FDish.Width, FDish.Height);
            // dish イメージを描画
            g.DrawImage(Properties.Resources.dish, wDestinationRect);
        }
    }
}
