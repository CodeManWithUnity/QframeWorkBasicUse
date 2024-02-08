using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using static QFramework.Example.CounterAppController;

namespace QFramework.Example
{
    //定义数据变更事件
    public struct CountChangeEvent
    {
        public int value;
        public int index;
        public int count;
        public int a;
    }
    
}