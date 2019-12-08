using System;
using System.Threading.Tasks;

namespace ScreenTransition.Views
{
    /// <summary>
    /// ページ遷移インタフェイス
    /// </summary>
    public interface ITrasitionPage
    {
        /// <summary>
        /// ページ遷移直前に実行するタスク。
        /// </summary>
        /// <returns>false:ページ遷移を取り消す</returns>
        Task<bool> BeforeTransitionTask();
    }
}
