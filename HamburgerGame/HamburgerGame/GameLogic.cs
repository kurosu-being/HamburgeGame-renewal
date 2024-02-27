using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HamburgerGame {
    public class GameLogic {
        private const int C_FoodWidth = 50;
        private const int C_FoodHeight = 50;
        private const int C_FallingSpeed = 5;
        private const int C_NewFoodInterval = 1200;

        private List<Food> FFoodList;
        private Timer FTimer;
        private Random FRandom;
        private int FElapsedTime = 0;
        private PictureBox FAreaPlay; 

        public GameLogic(PictureBox vAreaPlay) {
            FFoodList = new List<Food>();
            FRandom = new Random();
            FAreaPlay = vAreaPlay; 

            FTimer = new Timer();
            FTimer.Interval = 20;
            FTimer.Tick += Timer_Tick;
            FTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            FElapsedTime += FTimer.Interval;

            if (FElapsedTime >= C_NewFoodInterval) {
                AddNewFood();
                FElapsedTime = 0;
            }

            foreach (Food wFood in FFoodList.ToArray()) {
                wFood.Move(0, C_FallingSpeed);

                if (wFood.Rectangle.Y > FAreaPlay.Height) { 
                    FFoodList.Remove(wFood);
                }
            }

            FAreaPlay.Invalidate(); 
        }

        private void AddNewFood() {
            int wNewX = FRandom.Next(0, FAreaPlay.Width - C_FoodWidth);
            int wNewY = -C_FoodHeight;
            var wNewFood = new Food(wNewX, wNewY, C_FoodWidth, C_FoodHeight);
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
        ///　最初の具材を追加し、AreaPlayを更新するメソッド
        /// </summary>
        /// <param name="e"></param>
        public void AreaPlay_Load(EventArgs e) {
            FAreaPlay.Paint += AreaPlay_Paint;
            AddNewFood();
        }
    }
}