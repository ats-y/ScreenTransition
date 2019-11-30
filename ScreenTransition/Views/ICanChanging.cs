using System;
using System.Threading.Tasks;

namespace ScreenTransition.Views
{
    /// <summary>
    /// ページ遷移イベント
    /// </summary>
    public interface ICanChanging
    {
        /// <summary>
        /// 変更可能かどうか確認するタスク。
        /// </summary>
        /// <returns></returns>
        Task<bool> CanChanging();
    }
}
