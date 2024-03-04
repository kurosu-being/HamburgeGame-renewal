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
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        public Food(int vX, int vY, int vWidth, int vHeight, Image vFoodImage) {
            this.Rectangle = new Rectangle(vX, vY, vWidth, vHeight);
            this.FoodImage = vFoodImage;
            if (FoodImage == null || FoodImage.Tag == null) {
                throw new ArgumentException("画像または画像のタグが指定されていません。");
            }

            string wResourceName = Path.GetFileNameWithoutExtension(vFoodImage.Tag.ToString());
            this.FoodImage.Tag = wResourceName;
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

        private string GetResourceNameFromImage(Image image) {
            string wImageName = image.Tag.ToString(); // 画像の名前を取得
            string wResourceName = Path.GetFileNameWithoutExtension(wImageName); // 拡張子を取り除いた名前をリソース名とする
            return wResourceName;
        }
    }
}
