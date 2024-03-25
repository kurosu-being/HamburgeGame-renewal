using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
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
        /// 獲得する具材の最大数
        /// </summary>
        private const int C_MAXCaughtFoodNumber = 5;
        /// <summary>
        /// Area_Displayに具材を積み重ねる間隔
        /// </summary>
        private const int C_SpaceOfCaughtFoodY = 60;
        /// <summary>
        /// Area_Displayに具材を最初に表示するY座標が、どれだけbun_underから離れているかのY座標幅
        /// </summary>
        private const int C_SomeBunUnderY = 80;

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
        /// 獲得すると終了になる具材の名前
        /// </summary>
        private string FEndFoodName = "bun_top";

        /// <summary>
        /// 終了か否かのフラグ
        /// </summary>
        private bool FIsEnd = false;

        /// <summary>
        /// ゲーム画面のフォーム
        /// </summary>
        private Form ParentForm { get; }
        /// <summary>
        /// 獲得した具材のリスト
        /// </summary>
        public List<Food> CaughtFoodList { get; }
        /// <summary>
        /// パン下部のPictureBox
        /// </summary>
        private PictureBox FBunUnder;
        /// <summary>
        /// 移動中の具材のリスト
        /// </summary>
        private readonly List<Food> FMoveFoodList;
        /// <summary>
        /// ゲーム画面を表すPictureBox
        /// </summary>
        private readonly PictureBox FAreaPlay;
        /// <summary>
        /// 獲得画面を表すPictureBox
        /// </summary>
        private readonly PictureBox FAreaDisplay;
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
        public GameLogic(PictureBox vAreaPlay, PictureBox vAreaDisplay, PictureBox vPlate, Form vParentForm, PictureBox vBunUnder) {
            this.FMoveFoodList = new List<Food>();
            this.CaughtFoodList = new List<Food>();
            this.FAreaPlay = vAreaPlay;
            this.FAreaDisplay = vAreaDisplay;
            this.FPlate = new Plate(vPlate);
            this.ParentForm = vParentForm;
            this.FBunUnder = vBunUnder;

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
                this.AddNewFood();
                FElapsedTime = 0;
            }

            // コレクション変更の可能性がある為、元のリストのコピーを作成
            var wMoveFoodsCopy = new List<Food>(FMoveFoodList);
            //具材を落下させ、Y座標が描画されるPictureBoxのY座標に達した時削除される
            foreach (Food wFood in wMoveFoodsCopy) {
                wFood.Move(0, C_FallingFoodSpeed);

                if (wFood.Rectangle.Y > FAreaPlay.Height) {
                    FMoveFoodList.Remove(wFood);
                }
            }

            // 当たり判定を実行
            this.ProcessCollisions();

            //コントロールの表面全体を無効化し、再描画をマークする
            FAreaPlay.Invalidate();

            // 終了判定を実行
            if (FIsEnd) {
                FTimer.Stop();
                //終了判定trueの時、ResultFormに遷移する
                var wResultForm = new ResultScreen(this.CaughtFoodList);
                //終了画面を表示
                wResultForm.Show();

                // ゲーム終了時の効果音を追加する
                new SoundPlayer(Properties.Resources.fanfare).Play();

                this.ParentForm.Hide();
            }
        }

        /// <summary>
        ///　ゲーム画面を初期化し、最初の具材を追加するメソッド
        /// </summary>
        public void InitializeGameScreen() {
            //FAreaPlay.Paint イベントに DrawFMoveListFood メソッド、FAreaDisplay.Paint イベントDrawFCaughtListFoodメソッドをイベントハンドラとして登録
            FAreaPlay.Paint += this.DrawFMoveListFood;
            FAreaDisplay.Paint += this.DrawFCaughtListFood;
            //最初の具材を追加する
            this.AddNewFood();
        }

        /// <summary>
        /// 新しい具材を移動する具材のリストに追加するメソッド
        /// </summary>
        private void AddNewFood() {
            Food wNewFood = this.CreateRandomFood();
            FMoveFoodList.Add(wNewFood);
        }

        /// <summary>
        /// ランダムな具材の画像を上部ランダムな位置に生成するメソッド
        /// </summary>
        /// <returns>生成された具材の画像</returns>
        private Food CreateRandomFood() {
            FoodInfo wRamdomFoodInfo = FoodUtils.GetRandomFoodInfo();

            //画面上部の新しい位置に配置
            var wRamdom = new Random();
            int wNewX = wRamdom.Next(0, FAreaPlay.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;

            return new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight, wRamdomFoodInfo);
        }

        /// <summary>
        /// FMoveFoodListの具材を描画するメソッド
        /// </summary>
        public void DrawFMoveListFood(object sender, PaintEventArgs e) {
            // コレクション変更の可能性がある為、元のリストのコピーを作成
            var wMoveFoodsCopy = new List<Food>(FMoveFoodList);
            foreach (Food wFood in wMoveFoodsCopy) {
                wFood.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// 獲得した具材をパン下部の上に生成するメソッド
        /// </summary>
        public void StackCaughtFood() {
            //獲得した具材の最初のY座標
            int wStartY = FBunUnder.Bounds.Y - C_SomeBunUnderY;
            foreach (Food wFood in this.CaughtFoodList) {
                // 描画位置の設定
                wFood.Rectangle = new Rectangle(FBunUnder.Bounds.X - FAreaPlay.Width, wStartY, FBunUnder.Width, FBunUnder.Height);
                wStartY -= C_SpaceOfCaughtFoodY;
            }
            // Area_Display を再描画する
            FAreaDisplay.Invalidate();
        }


        /// <summary>
        /// FCaughtListFoodの具材を描画するメソッド
        /// </summary>
        public void DrawFCaughtListFood(object sender, PaintEventArgs e) {
            // コレクション変更の可能性がある為、元のリストのコピーを作成
            var wCaughtFoodsCopy = new List<Food>(this.CaughtFoodList);
            foreach (Food wFood in wCaughtFoodsCopy) {
                wFood.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// 当たり判定の処理を実行するメソッド
        /// </summary>
        private void ProcessCollisions() {
            Rectangle wPlateRect = this.GetPlateRectangle();

            // コレクション変更の可能性がある為、元のリストのコピーを作成
            var wMoveFoodsCopy = new List<Food>(FMoveFoodList);
            foreach (Food wFood in wMoveFoodsCopy) {
                if (this.IsCollisions(wFood.Rectangle, wPlateRect)) {
                    this.HandleCollision(wFood);
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
            this.CaughtFoodList.Add(vFood);

            StackCaughtFood();
            // 具材獲得時の効果音を追加する
            new SoundPlayer(Properties.Resources.caught).Play();

            //終了判定を実行
            this.JudgeEndGetBunTop(vFood);
            this.JudgeEndGetFiveFood();

            FMoveFoodList.Remove(vFood);
        }

        /// <summary>
        /// 終了判定：具材を5個獲得したら終了判定フラグをtrueにするメソッド
        /// </summary>
        /// <returns>終了したか否かのフラグ</returns>
        private bool JudgeEndGetFiveFood() {
            if (this.CaughtFoodList.Count == C_MAXCaughtFoodNumber) {
                FIsEnd = true;
            }
            return FIsEnd;
        }

        /// <summary>
        /// 終了判定：パン上部を獲得したら終了判定フラグをtrueにするメソッド
        /// </summary>
        /// <param name="vFood"></param>
        /// <returns>終了したか否かのフラグ</returns>
        private bool JudgeEndGetBunTop(Food vFood) {
            if (vFood.FoodInfo.Name == FEndFoodName) {
                FIsEnd = true;
            }
            return FIsEnd;
        }

        /// <summary>
        /// Plateの位置情報を取得するためのメソッド
        /// </summary>
        /// <returns>Plateの位置情報</returns>
        private Rectangle GetPlateRectangle() {
            return FPlate.PlatePictureBox.Bounds;
        }

        /// <summary>
        /// キー入力を受け取り、皿を移動させるメソッド
        /// </summary>
        public void ProcessKeyPress(Keys key, int vAreaWidth) {
            FPlate.MovePlate(key, vAreaWidth);
        }

        /// <summary>
        /// タイマーを停止し、タイマーを破棄するメソッド
        /// </summary>
        public void StopTimer() {
            FTimer.Stop();
            FTimer.Dispose();
        }
    }
}