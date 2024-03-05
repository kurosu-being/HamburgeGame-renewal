using System;
using System.Collections.Generic;

namespace HamburgerGame {
    /// <summary>
    /// 具材に関するユーティリティクラス
    /// </summary>
    public static class FoodUtils {
        /// <summary>
        /// 具材の画像と名前を管理するオブジェクトのリスト
        /// </summary>
        private static readonly List<FoodInfo> FFoodInfoList = new List<FoodInfo> {
            new FoodInfo("bun_top", Properties.Resources.bun_top),
            new FoodInfo("cheese", Properties.Resources.cheese),
            new FoodInfo("patty", Properties.Resources.patty),
            new FoodInfo("lettuce", Properties.Resources.lettuce),
            new FoodInfo("tomato", Properties.Resources.tomato)
        };

        /// <summary>
        /// FoodInfoの全アイテムを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public static List<FoodInfo> GetFoodInfoList() {
            return FFoodInfoList;
        }

        /// <summary>
        /// FoodInfoのランダムなアイテムを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public static FoodInfo GetRandomFoodInfo() {
            // ランダムなインデックスを取得
            int wIndex = new Random().Next(FFoodInfoList.Count);
            return FFoodInfoList[wIndex];
        }
    }
}
