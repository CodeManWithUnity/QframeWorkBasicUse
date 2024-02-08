using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{

    // 1. ����һ�� Model ����
    public class CounterAppModel : AbstractModel
    {
        private int mCount;

        public int Count
        {
            get => mCount;
            set
            {
                if (mCount != value)
                {
                    mCount = value;
                    PlayerPrefs.SetInt(nameof(Count), mCount);
                }
            }
        }

        protected override void OnInit()
        {
            var storage = this.GetUtility<Storage>();

            Count = storage.LoadInt(nameof(Count));

            // ����ͨ�� CounterApp.Interface �������ݱ���¼�
            CounterApp.Interface.RegisterEvent<CountChangeEvent>(e =>
            {
                this.GetUtility<Storage>().SaveInt(nameof(Count), Count);
            });
        }
    }

    // ���� utility ��
    public class Storage : IUtility
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }


    // 2.����һ���ܹ����ṩ MVC���ֲ㡢ģ�����ȣ�
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            // ע�� System 
            this.RegisterSystem(new AchievementSystem()); // +

            // ע�� Model
            this.RegisterModel(new CounterAppModel());

            // ע��洢���ߵĶ���
            this.RegisterUtility(new Storage());
        }
    }


    // Controller
    public class CounterAppController : MonoBehaviour, IController /* 3.ʵ�� IController �ӿ� */
    {
        // View
        private Button mBtnAdd;
        private Button mBtnSub;
        private Text mCountText;

        // 4. Model
        private CounterAppModel mModel;

        void Start()
        {
            // 5. ��ȡģ��
            mModel = this.GetModel<CounterAppModel>();

            // View �����ȡ
            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<Text>();


            // ��������
            mBtnAdd.onClick.AddListener(() =>
            {
                // �����߼�
                this.SendCommand<IncreaseCountCommand>();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                // �����߼�
                this.SendCommand(new DecreaseCountCommand(/* ������Դ��Σ�����У� */));
            });

            UpdateView();

            // �����߼�
            this.RegisterEvent<CountChangeEvent>(e =>
            {
                UpdateView();

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        void UpdateView()
        {
            mCountText.text = mModel.Count.ToString();
        }

        // 3.
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnDestroy()
        {
            // 8. �� Model ����Ϊ��
            mModel = null;
        }
    }
}