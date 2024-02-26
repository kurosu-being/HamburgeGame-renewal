using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HamburgerGame {
    public partial class HamburgerGAME : Form {
        private const int C_FoodWidth = 50; // 具材の幅
        private const int C_FoodHeight = 50; // 具材の高さ
        private const int C_FallingSpeed = 5; // 具材の降下速度
        private const int C_NewFoodInterval = 1200; // 新しい具材を生成する間隔 (ミリ秒)
        private List<Food> FFoodList; // 具材のリスト
        private Timer FTimer;
        private Random FRandom;
        private int FElapsedTime = 0;

        public HamburgerGAME() {
            InitializeComponent();
            InitializeGame();

        }
        private void InitializeGame() {
            FFoodList = new List<Food>(); // 具材のリストを初期化
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
                    break; // foreach ループから抜ける
                }
            }

            // PictureBoxを再描画
            Area_Play.Invalidate();

        }

        private void AddNewFood() {
            // 新しい具材を生成してリストに追加
            int wNewX = FRandom.Next(0, Area_Play.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;
            Food wNewFood = new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight);
            FFoodList.Add(wNewFood);
        }

        private void Area_Play_Paint(object sender, PaintEventArgs e) {
            // 全ての具材を描画
            foreach (Food wFood in FFoodList) {
                wFood.Draw(e.Graphics);
            }
        }

        private void HamburgerGAME_Load_1(object sender, EventArgs e) {
            Area_Play.Paint += Area_Play_Paint;
            AddNewFood();
        }
    }
}
