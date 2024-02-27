using System.Drawing;

namespace HamburgerGame {
    // 具材クラス
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
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vX">X座標</param>
        /// <param name="vY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        public Food(int vX, int vY, int vWidth, int vHeight) {
            Rectangle = new Rectangle(vX, vY, vWidth, vHeight);
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
            g.FillRectangle(new SolidBrush(FFoodColor), Rectangle);
        }
    }
}
