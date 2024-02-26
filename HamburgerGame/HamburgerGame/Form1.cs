using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class HamburgerGAME : Form {
        /// <summary>
        /// 具材の幅
        /// </summary>
        private const int C_FoodWidth = 50;
        /// <summary>
        /// 具材の高さ
        /// </summary>
        private const int C_FoodHeight = 50;
        /// <summary>
        /// 具材の降下速度
        /// </summary>
        private const int C_FallingSpeed = 5;
        /// <summary>
        /// 新しい具材を生成する間隔 (ミリ秒)
        /// </summary>
        private const int C_NewFoodInterval = 1200; 
        /// <summary>
        /// 具材のリスト
        /// </summary>
        private List<Food> FFoodList; 
        /// <summary>
        /// タイマーの変数
        /// </summary>
        private Timer FTimer;　
        /// <summary>
        /// ランダムな変数
        /// </summary>
        private Random FRandom;
        /// <summary>
        /// 経過時間
        /// </summary>
        private int FElapsedTime = 0;

        public HamburgerGAME() {
            InitializeComponent();
            InitializeGame();

        }
        private void InitializeGame() {
            FFoodList = new List<Food>(); 
            FRandom = new Random();

            // ゲーム用タイマーを設定
            FTimer = new Timer();
            FTimer.Interval = 20;
            FTimer.Tick += timer1_Tick;
            FTimer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            // 経過時間を加算
            FElapsedTime += FTimer.Interval;

            // 一定時間ごとに新しい具材を追加
            if (FElapsedTime >= C_NewFoodInterval) {
                AddNewFood();
                FElapsedTime = 0; // タイマーリセット
            }

            // 具材を降下させる
            foreach (Food wFood in FFoodList) {
                wFood.Move(0, C_FallingSpeed);

                // 具材が画面外に出たらリストから削除
                if (wFood.Rectangle.Y > Area_Play.Height) {
                    FFoodList.Remove(wFood);
                    break;
                }
            }

            // PictureBoxを再描画
            Area_Play.Invalidate();

        }

        /// <summary>
        /// 新しい具材を生成してリストに追加するメソッド
        /// </summary>
        private void AddNewFood() {
            int wNewX = FRandom.Next(0, Area_Play.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;
            var wNewFood = new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight);
            FFoodList.Add(wNewFood);
        }

        /// <summary>
        /// 全ての具材を描画するメソッド
        /// </summary>
        private void Area_Play_Paint(object sender, PaintEventArgs e) {

            foreach (Food wFood in FFoodList) {
                wFood.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// 最初の具材を描画し、画面をロードした時に再描画するメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerGAME_Load_1(object sender, EventArgs e) {
            Area_Play.Paint += Area_Play_Paint;
            AddNewFood();
        }
    }
}