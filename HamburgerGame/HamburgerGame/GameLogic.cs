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
        private List<Food> FMoveFoodList;
        /// <summary>
        /// 描画されるPictureBox
        /// </summary>
        private PictureBox FAreaPlay;

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
        /// Plateクラスのインスタンス
        /// </summary>
        private Plate FPlate;
        /// <summary>
        /// 獲得した具材が追加されるリスト
        /// </summary>
        private List<Food> FCatchFoodList;
        /// <summary>
        /// リストが機能しているか確かめるリストボックス（確認用）
        /// </summary>
        private ListBox FListBox;
        /// <summary>
        /// 具材の幅の当たり判定調整
        /// </summary>
        private int FSomeValueX = 30;
        /// <summary>
        /// 具材の高さの当たり判定調整
        /// </summary>
        private int FSomeValueY = 10;

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
        public GameLogic(PictureBox vAreaPlay, PictureBox vPlate, ListBox vKakutoku) {
            FMoveFoodList = new List<Food>();
            FCatchFoodList = new List<Food>();
            FRandom = new Random();
            FAreaPlay = vAreaPlay;
            FListBox = vKakutoku;
            FPlate = new Plate(vPlate);

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
            foreach (Food wFood in FMoveFoodList.ToArray()) {
                wFood.Move(0, C_FallingSpeed);

                if (wFood.Rectangle.Y > FAreaPlay.Height) {
                    FMoveFoodList.Remove(wFood);
                }
            }

            // 当たり判定を実行
            HandleChecker();

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
            FMoveFoodList.Add(wNewFood);
        }

        /// <summary>
        /// 具材を描画するメソッド
        /// </summary>
        public void AreaPlay_Paint(object sender, PaintEventArgs e) {
            foreach (Food wFood in FMoveFoodList.ToArray()) {
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
        /// Plateの位置情報を取得するためのメソッド
        /// </summary>
        private Rectangle GetPlateRectangle() {
            return FPlate.PlatePictureBox.Bounds;
        }

        /// <summary>
        /// 当たり判定の処理を実行するメソッド
        /// </summary>
        private void HandleChecker() {
            Rectangle wPlateRect = GetPlateRectangle();

            foreach (Food wFood in FMoveFoodList.ToArray()) {
                if (IsCollisions(wFood.Rectangle, wPlateRect)) {
                    HandleCollision(wFood);
                }
            }
        }

        /// <summary>
        /// 当たり判定のロジックを行うメソッド
        /// </summary>
        /// <param name="vFoodRect">具材の長方形</param>
        /// <param name="vPlateRect">皿の長方形</param>
        /// <returns></returns>
        private bool IsCollisions(Rectangle vFoodRect, Rectangle vPlateRect) {
            // 具材の矩形を調整
            Rectangle wAdjustmentFoodRect = vFoodRect;
            wAdjustmentFoodRect.Inflate(-FSomeValueX, -FSomeValueY);

            return wAdjustmentFoodRect.IntersectsWith(vPlateRect);
        }

        /// <summary>
        /// 衝突時の処理を行うメソッド
        /// </summary>
        /// <param name="vFood">具材</param>
        private void HandleCollision(Food vFood) {
            FCatchFoodList.Add(vFood);
            ShowCollisionMessage(vFood);
            FMoveFoodList.Remove(vFood);
        }

        /// <summary>
        /// リストボックスに獲得した具材のパスを追加するメソッド（確認用）
        /// </summary>
        /// <param name="food">衝突した具材</param>
        private void ShowCollisionMessage(Food vFood) {
            FListBox.Items.Clear();
            foreach (Food wFood in FCatchFoodList) {
                FListBox.Items.Add(wFood.ImagePath);
            }
        }

        /// <summary>
        /// キー入力を受け取り、皿を移動させるメソッド
        /// </summary>
        public void ProcessKeyPress(Keys key, int vAreaWidth) {
            FPlate.MovePlate(key, vAreaWidth);
        }
    }
}