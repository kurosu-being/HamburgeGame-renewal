using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    //ゲームロジックのクラス
    public class GameLogic {
        /// <summary>
        /// 具材の幅
        /// </summary>
        private const int C_FoodWidth = 140;
        /// <summary>
        /// 具材の高さ
        /// </summary>
        private const int C_FoodHeight = 70;
        /// <summary>
        /// 具材の落ちるスピード
        /// </summary>
        private const int C_FallingSpeed = 5;
        /// <summary>
        /// 具材の追加されるインターバル
        /// </summary>
        private const int C_NewFoodInterval = 1200;
        /// <summary>
        /// 表示される具材が追加されるリスト
        /// </summary>
        private List<Food> FFoodList;
        /// <summary>
        /// タイマー
        /// </summary>
        private Timer FTimer;
        /// <summary>
        /// ランダムな値の変数
        /// </summary>
        private Random FRandom;
        /// <summary>
        /// 経過時間
        /// </summary>
        private int FElapsedTime = 0;
        /// <summary>
        /// 描画されるPictureBox
        /// </summary>
        private PictureBox FAreaPlay;
        /// <summary>
        /// 皿のPictureBox
        /// </summary>
        private PictureBox FPlate;
        /// <summary>
        /// 表示される具材が追加されるリスト
        /// </summary>
        private List<Food> FDisplayList;

        /// <summary>
        /// 画像パス
        /// </summary>
        private string FBun_TopPath = @"..\..\Image\bun_top.png";
        private string FCheesePath = @"..\..\Image\cheese.png";
        private string FPattyPath = @"..\..\Image\patty.png";
        private string FLettucePath = @"..\..\Image\lettuce.png";
        private string FTomatoPath = @"..\..\Image\tomato.png";

        /// <summary>
        /// ゲームロジックのコンストラクタ
        /// </summary>
        /// <param name="vAreaPlay">描画するPictureBox</param>
        public GameLogic(PictureBox vAreaPlay, PictureBox vPlate) {
            FFoodList = new List<Food>();
            FRandom = new Random();
            FAreaPlay = vAreaPlay;
            FPlate = vPlate; // 皿の情報を保持

            FTimer = new Timer();
            FTimer.Interval = 20;
            FTimer.Tick += Timer_Tick;
            FTimer.Start();
        }

        /// <summary>
        /// インターバルごとに具材を追加し、具材とArea_PlayのY座標が一致した時具材を消去するメソッド
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e) {
            FElapsedTime += FTimer.Interval;

            //インターバルごとに具材をリストに追加
            if (FElapsedTime >= C_NewFoodInterval) {
                AddNewFood();
                FElapsedTime = 0;
            }

            //具材を落下させ、Y座標が描画されるPictureBoxのY座標に達した時削除される
            foreach (Food wFood in FFoodList.ToArray()) {
                wFood.Move(0, C_FallingSpeed);

                if (wFood.Rectangle.Y > FAreaPlay.Height) {
                    FFoodList.Remove(wFood);
                }
            }

            CheckCollisions(); // 当たり判定を実行
            foreach(var wList in FDisplayList){
                MessageBox.Show($"");
            }
            MessageBox.Show($"");

            //再描画をマークする
            FAreaPlay.Invalidate();
        }

        /// <summary>
        /// 新しい具材を画面外のランダムな位置に設定し、リストに追加するメソッド
        /// </summary>
        private void AddNewFood() {
            int wNewX = FRandom.Next(0, FAreaPlay.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;
            string[] wImagePaths = { FBun_TopPath, FCheesePath, FPattyPath, FLettucePath, FTomatoPath };
            string wRandomImagePath = wImagePaths[FRandom.Next(wImagePaths.Length)];
            var wNewFood = new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight, wRandomImagePath);
            FFoodList.Add(wNewFood);
        }

        /// <summary>
        /// 具材を描画するメソッド
        /// </summary>
        public void AreaPlay_Paint(object sender, PaintEventArgs e) {
            foreach (Food wFood in FFoodList.ToArray()) {
                wFood.Draw(e.Graphics);
            }
        }

        /// <summary>
        ///　ゲーム画面を初期化し、最初の具材を追加するメソッド
        /// </summary>
        /// <param name="e"></param>
        public void AreaPlay_Load(EventArgs e) {
            FAreaPlay.Paint += AreaPlay_Paint;
            AddNewFood();
        }

        /// <summary>
        /// Plate の位置情報を取得するためのメソッド
        /// </summary>
        private Rectangle GetPlateRectangle() {
            return FPlate.Bounds;
        }

        /// <summary>
        /// 具材と皿の当たり判定を行うメソッドを追加
        /// </summary>
        private void CheckCollisions() {
            Rectangle wPlateRect = GetPlateRectangle();

            foreach (Food wFood in FFoodList.ToArray()) {
                if (wFood.Rectangle.IntersectsWith(wPlateRect)) {
                    FDisplayList.Add(wFood);
                    FFoodList.Remove(wFood);
                }
            }
        }
    }
}