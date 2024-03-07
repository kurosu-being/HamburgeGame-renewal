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
        /// // 具材の座標と幅
        /// </summary>
        public Rectangle Rectangle { get; private set; }
        /// <summary>
        /// 具材の情報
        /// </summary>
        public FoodInfo FoodInfo { get; }

        /// <summary>
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">具材の幅</param>
        /// <param name="vHeight">具材の高さ</param>
        /// <param name="vFoodInfo">FoodInfoのインスタンス</param>
        public Food(int vPositionX, int vPositionY, int vWidth, int vHeight, FoodInfo vFoodInfo) {
            this.Rectangle = new Rectangle(vPositionX, vPositionY, vWidth, vHeight);

            this.FoodInfo = vFoodInfo; 
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
            g.DrawImage(FoodInfo.Image, Rectangle);
        }
    }
}
