using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using static QFramework.Example.CounterAppController;

namespace QFramework.Example
{
    //Systemϵͳ��������ɸ��ӵ�ϵͳ����
    public class AchievementSystem : AbstractSystem // +
    {
        protected override void OnInit()
        {
            var model = this.GetModel<CounterAppModel>();

            this.RegisterEvent<CountChangeEvent>(e =>
            {
                if (model.Count == 10)
                {
                    Debug.Log("���� ������� �ɾ�");
                }
                else if (model.Count == 20)
                {
                    Debug.Log("���� ���ר�� �ɾ�");
                }
                else if (model.Count == -10)
                {
                    Debug.Log("���� ������� �ɾ�");
                }
            });
        }
    }
}