using System.Drawing;

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
        public Image FFoodImage { get; private set; }
        /// <summary>
        /// 具材の名前
        /// </summary>
        public string FFoodName { get; private set; }

        /// <summary>
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">具材の幅</param>
        /// <param name="vHeight">具材の高さ</param>
        /// <param name="vFoodImage">具材のImage画像</param>
        /// <param name="vFoodType">具材の種類</param>
        public Food(int vPositionX, int vPositionY, int vWidth, int vHeight, FoodInfo vFoodInfo) {
            this.Rectangle = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);

            this.FFoodImage = vFoodInfo.Image;
            this.FFoodName = vFoodInfo.Name;
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
            g.DrawImage(FFoodImage, Rectangle);
        }
    }
}
