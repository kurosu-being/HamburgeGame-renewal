using System;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class HamburgerGAME : Form {
        /// <summary>
        ///  GameLogicクラスのインスタンス
        /// </summary>
        private GameLogic FGameLogic;

        public HamburgerGAME() {
            InitializeComponent();
            InitializeGame();

            KeyDown += Form1_KeyDown;
        }


        /// <summary>
        /// ゲームを初期化し、ゲームロジックを設定するメソッド
        /// </summary>
        private void InitializeGame() {
            FGameLogic = new GameLogic(Area_Play, Plate);
            FGameLogic.AreaPlay_Load(null);
        }
        //左右キーでお皿の移動
        private void Form1_KeyDown(object vSender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left) {
                MoveLeft();
            } else if (e.KeyCode == Keys.Right) {
                MoveRight();
            }
        }
        void MoveLeft() {
            // Plateの現在位置を取得
            Point wPt = Plate.Location;
            // 移動量を10ピクセルに設定して左に移動
            wPt.X -= 10;
            // 移動後の位置がフォームの境界内であるかをチェックし、境界内であれば更新
            if (wPt.X >= 0) {
                Plate.Location = wPt;
            }
        }
        void MoveRight() {
            // Plateの現在位置を取得
            Point wPt = Plate.Location;
            // 移動量を10ピクセルに設定して右に移動
            wPt.X += 10;
            // 移動後の位置がフォームの境界内であるかをチェックし、境界内であれば更新
            if (wPt.X + Plate.Width <= Area_Play.Width) {
                Plate.Location = wPt;
            }
        }

        private void HamburgerGAME_Load_1(object sender, EventArgs e) {
        }
    }
}