using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    /// <summary>
    /// ゲームロジックのクラス
    /// </summary>
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
        private const int C_FallingFoodSpeed = 5;
        /// <summary>
        /// 具材の追加されるインターバル
        /// </summary>
        private const int C_AddNewFoodInterval = 1200;
        /// <summary>
        /// 経過時間
        /// </summary>
        private int FElapsedTime = 0;
        /// <summary>
        /// 具材の幅の当たり判定調整
        /// </summary>
        private int FSomeValueX = 15;
        /// <summary>
        /// 具材の高さの当たり判定調整
        /// </summary>
        private int FSomeValueY = 10;
        /// <summary>
        /// 終了か否かのフラグ
        /// </summary>
        public bool FEndFlag;

        /// <summary>
        /// 移動中の具材のリスト
        /// </summary>
        private readonly List<Food> FMoveFoodList;
        /// <summary>
        /// 獲得した具材のリスト
        /// </summary>
        private readonly List<Food> FCatchFoodList;
        /// <summary>
        /// 乱数生成器
        /// </summary>
        private readonly Random FRandom;
        /// <summary>
        /// ゲーム画面を表すPictureBox
        /// </summary>
        private readonly PictureBox FAreaPlay;
        /// <summary>
        /// TODO: 獲得した具材の名前を表示するListBoxなのであとで削除する
        /// </summary>
        private readonly ListBox FCatchFoodListBox;
        /// <summary>
        /// 皿を表すオブジェクト
        /// </summary>
        private readonly Plate FPlate;
        /// <summary>
        /// ゲームのタイマー
        /// </summary>
        private readonly Timer FTimer;

        /// <summary>
        /// ゲームロジックのコンストラクタ
        /// </summary>
        /// <param name="vAreaPlay">描画するPictureBox</param>
        public GameLogic(PictureBox vAreaPlay, PictureBox vPlate, ListBox vKakutoku) {
            this.FMoveFoodList = new List<Food>();
            this.FCatchFoodList = new List<Food>();
            this.FRandom = new Random();
            this.FAreaPlay = vAreaPlay;
            this.FCatchFoodListBox = vKakutoku;
            this.FPlate = new Plate(vPlate);

            this.FTimer = new Timer();
            this.FTimer.Interval = 20;
            this.FTimer.Tick += Timer_Tick;
            this.FTimer.Start();
        }

        /// <summary>
        /// インターバルごとに具材を追加し、具材とArea_PlayのY座標が一致した時具材を消去するメソッド
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e) {
            FElapsedTime += FTimer.Interval;

            //インターバルごとに具材をリストに追加
            if (FElapsedTime >= C_AddNewFoodInterval) {
                AddNewFood();
                FElapsedTime = 0;
            }

            //具材を落下させ、Y座標が描画されるPictureBoxのY座標に達した時削除される
            foreach (Food wFood in FMoveFoodList.ToArray()) {
                wFood.Move(0, C_FallingFoodSpeed);

                if (wFood.Rectangle.Y > FAreaPlay.Height) {
                    FMoveFoodList.Remove(wFood);
                }
            }

            // 当たり判定を実行
            HandleChecker();

            //コントロールの表面全体を無効化し、再描画をマークする
            FAreaPlay.Invalidate();
        }

        /// <summary>
        /// 新しい具材を移動する具材のリストに追加するメソッド
        /// </summary>
        private void AddNewFood() {
            Food wNewFood = CreateRandomFood();
            FMoveFoodList.Add(wNewFood);
        }

        /// <summary>
        /// ランダムな具材の画像を上部ランダムな位置に生成するメソッド
        /// </summary>
        /// <returns>生成された具材の画像</returns>
        private Food CreateRandomFood() {
            var wRamdomFoodInfo = FoodUtils.GetRandomFoodInfo();

            //画面上部の新しい位置に配置
            int wNewX = FRandom.Next(0, FAreaPlay.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;

            return new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight, wRamdomFoodInfo);
        }

        /// <summary>
        /// FMoveListの具材を描画するメソッド
        /// </summary>
        public void DrawAreaPlay(object sender, PaintEventArgs e) {
            foreach (Food wFood in FMoveFoodList.ToArray()) {
                wFood.Draw(e.Graphics);
            }
        }

        /// <summary>
        ///　ゲーム画面を初期化し、最初の具材を追加するメソッド
        /// </summary>
        public void InitializeGameScreen() {
            FAreaPlay.Paint += DrawAreaPlay;
            //最初の具材を追加する
            AddNewFood();
        }

        /// <summary>
        /// Plateの位置情報を取得するためのメソッド
        /// </summary>
        /// <returns>Plateの位置情報</returns>
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
        /// <returns>当たり判定が真か偽か</returns>
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
        /// TODO: リストボックスに獲得した具材の名前を追加するメソッドなので削除する
        /// </summary>
        /// <param name="food">衝突した具材</param>
        private void ShowCollisionMessage(Food vFood) {
            // 具材のリソース名を取得し、リストボックスに追加する
            string wResourceName = vFood.FFoodInfo.Name;
            // リソース名は通常小文字で指定される為小文字に
            FCatchFoodListBox.Items.Add(wResourceName.ToLower());
        }

        /// <summary>
        /// キー入力を受け取り、皿を移動させるメソッド
        /// </summary>
        public void ProcessKeyPress(Keys key, int vAreaWidth) {
            FPlate.MovePlate(key, vAreaWidth);
        }
    }
}