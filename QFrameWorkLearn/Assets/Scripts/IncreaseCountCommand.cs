using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static QFramework.Example.CounterAppController;

namespace QFramework.Example
{
    public class IncreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            //数据变更
            this.GetModel<CounterAppModel>().Count++;
            this.SendEvent<CountChangeEvent>();
        }

    }
    public class DecreaseCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<CounterAppModel>().Count--;
            this.SendEvent<CountChangeEvent>();

        }
    }
}