using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using static QFramework.Example.CounterAppController;

namespace QFramework.Example
{
    //System系统层用来达成复杂的系统功能
    public class AchievementSystem : AbstractSystem // +
    {
        protected override void OnInit()
        {
            var model = this.GetModel<CounterAppModel>();

            this.RegisterEvent<CountChangeEvent>(e =>
            {
                if (model.Count == 10)
                {
                    Debug.Log("触发 点击达人 成就");
                }
                else if (model.Count == 20)
                {
                    Debug.Log("触发 点击专家 成就");
                }
                else if (model.Count == -10)
                {
                    Debug.Log("触发 点击菜鸟 成就");
                }
            });
        }
    }
}