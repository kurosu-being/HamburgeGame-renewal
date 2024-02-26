﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace HamburgerGame {
    // 具材（食べ物）を表すクラス
    public class Food {
        private static readonly Color FFoodColor = Color.Brown; // 具材の色
        public Rectangle Rectangle { get; private set; } // 具材の座標

        public Food(int vX, int vY, int vWidth, int vHeight) {
            Rectangle = new Rectangle(vX, vY, vWidth, vHeight);
        }

        // 具材の相対的な位置を変更するメソッド
        public void Move(int deltaX, int deltaY) {
            Rectangle = new Rectangle(Rectangle.X + deltaX, Rectangle.Y + deltaY, Rectangle.Width, Rectangle.Height);
        }

        // 具材の絶対的な位置を変更するメソッド
        public void MoveTo(int newX, int newY) {
            Rectangle = new Rectangle(newX, newY, Rectangle.Width, Rectangle.Height);
        }


        // 具材を描画するメソッド
        public void Draw(Graphics g) {
            g.FillRectangle(new SolidBrush(FFoodColor), Rectangle);
        }
    }
}
