using System;
using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using Assets.Scripts.Manager;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class UnitCore : CharacterBase, IDamageApplicable
    {
        [SerializeField]
        private Animator ___Animator;

        public ___UnitParameters ___parameter;

        public UnitKindIs unitKind;

        public UnitRegistrationInfo unitStatus;

        private Vector3 DefaultScale=Vector3.zero;
        private Vector3 LossScale=Vector3.zero;
        private Vector3 LocalScale=Vector3.zero;

        //初期化実行イベント通知
        public IObservable<UniRx.Unit> onInitialize { get { return OnInitializeAsyncSubject; } }
        private AsyncSubject<UniRx.Unit> OnInitializeAsyncSubject = new AsyncSubject<UniRx.Unit>();

        //ダメージ受けた時の通知
        public IObservable<___Damage> onDamaged { get { return OnDamaged; } }
        private Subject<___Damage> OnDamaged = new Subject<___Damage>();

        void Start() 
        {
            DefaultScale = transform.lossyScale;
        }

        void Update()
        {
            LossScale= transform.lossyScale;
            LocalScale= transform.localScale;

            transform.localScale = new Vector3
            (
                LocalScale.x / LossScale.x * DefaultScale.x,
                LocalScale.y / LossScale.y * DefaultScale.y,
                LocalScale.z / LossScale.z * DefaultScale.z
            );
        }

        //MainGameManagerが呼び出す初期化処理
        public void initializeUnit(UnitRegistrationInfo unitInfo)
        {
            unitStatus = unitInfo;
            myTag = unitStatus.myTag;
            var tr = GetComponent<Transform>();
            tr.position = unitStatus.pos;
            tr.eulerAngles = unitStatus.angle;
            OnInitializeAsyncSubject.OnNext(UniRx.Unit.Default);
            OnInitializeAsyncSubject.OnCompleted();

        }

        //ダメージを受ける。
        //UnitHitPointManagerに通知
        public void applyDamage(___Damage Damage)
        {
            OnDamaged.OnNext(Damage);
            ___Animator.SetBool("Attack", false);
            ___Animator.SetBool("Damage", true);
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }

        public void OnDestroy()
        {
            OnDamaged.Dispose();
        }

        private void DamageAnimationEnd()
        {
            ___Animator.SetBool("Damage", false);
        }
    }
}


