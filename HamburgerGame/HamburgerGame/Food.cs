using System;
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
        public Image FoodImage { get; private set; }

        /// <summary>
        /// フードのコンストラクタ
        /// </summary>
        /// <param name="vPositionX">X座標</param>
        /// <param name="vPositionY">Y座標</param>
        /// <param name="vWidth">幅</param>
        /// <param name="vHeight">高さ</param>
        public Food(int vX, int vY, int vWidth, int vHeight, string vResourceName) {
            this.Rectangle = new Rectangle(vX, vY, vWidth, vHeight);
            this.FoodImage = Properties.Resources.ResourceManager.GetObject(vResourceName) as Image;
            if (FoodImage == null) {
                throw new ArgumentException("リソースの名前と一致するものがみつかりませんでした。リソースファイルの画像名とコードの具材の画像名が一致しているか確認してください。");
            }
            this.FoodImage.Tag = vResourceName;
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
