using System;
using System.Drawing;
using System.IO;

namespace HamburgerGame {
    /// <summary>
    /// 具材クラス
    /// </summary>
    public class Food {
        /// <summary>
        /// 具材の長方形の色
        /// </summary>
        private static readonly Color FFoodColor = Color.Brown;
        /// <summary>
        /// // 具材の座標
        /// </summary>
        public Rectangle Rectangle { get; private set; }
        /// <summary>
        /// 具材の画像
        /// </summary>
        public Image FoodImage { get; private set; }
        /// <summary>
        /// 具材の名前
        /// </summary>
        public string FFoodName { get; private set;}

        /// <summary>
        /// 具材の画像
        /// </summary>
        public static readonly Image[] FImages = {
            Properties.Resources.bun_top, //パン上部
            Properties.Resources.cheese,  //チーズ  
            Properties.Resources.patty,   //肉      
            Properties.Resources.lettuce, //レタス  
            Properties.Resources.tomato   //トマト
        };
        /// <summary>
        /// 具材の画像名
        /// </summary>
        public static readonly string[] FResourceNames = {
            "bun_top", //パン上部           
            "cheese",  //チーズ          
            "patty",   //肉      
            "lettuce", //レタス     
            "tomato"   //トマト
        };

        /// <summary>
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">具材の幅</param>
        /// <param name="vHeight">具材の高さ</param>
        /// <param name="vFoodImage">具材のImage画像</param>
        /// <param name="vFoodType">具材の種類</param>
        public Food(int vPositionX, int vPositionY, int vWidth, int vHeight, Image vFoodImage, int vFoodType) {
            this.Rectangle = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);
            this.FoodImage = vFoodImage;

            this.FoodImage = FImages[vFoodType];
            this.FFoodName = FResourceNames[vFoodType];
        }

        /// <summary>
        ///  具材の相対的な位置を変更するメソッド
        /// </summary>
        public void Move(int vDeltaX, int vDeltaY) {
            Rectangle = new Rectangle(Rectangle.X + vDeltaX, Rectangle.Y + vDeltaY, Rectangle.Width, Rectangle.Height);
        }

        /// <summary>
        /// 具材を描画するメソッド
        /// </summary>
        public void Draw(Graphics g) {
            g.DrawImage(FoodImage, Rectangle);
        }
    }
}
