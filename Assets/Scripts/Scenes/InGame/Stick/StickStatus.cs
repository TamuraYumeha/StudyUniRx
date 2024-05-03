using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System;

namespace Scenes.InGame.Stick
{
    public class StickStatus : MonoBehaviour
    {
        [Header("スティックの可変パラメータ")]
        [SerializeField, Tooltip("スティックが移動する速度")]
        private float _moveSpeed;//スティックの移動速度を決めるパラメータです
        [SerializeField] private int MaxHp;//HPの最大値 
        [SerializeField, Tooltip("スティックのHP")]
        private ReactiveProperty<int> _hp = new ReactiveProperty<int>(); //スティックの残機

        public float MoveSpeed { get => _moveSpeed; }//他のスクリプトから_moveSpeedの値を参照したい場合はこの関数を使います
        private bool _isMovable = true;//スティックが移動できるかどうかのパラメータです
        public bool IsMovable { get => _isMovable; }//他のスクリプトから_isMovableの値を参照したい場合はこの関数を使います
        public IReadOnlyReactiveProperty<int> Hp { get => _hp; }//他のスクリプトから_hpの値を参照したい場合はこの関数を使います


        private Subject<Unit> PlusHP = new Subject<Unit>(); //こういうイベントを発行するよ
        public IObservable<Unit> OnPlus => PlusHP;//だからイベント監視したいならこいつを使ってね

        private Subject<Unit> MinusHP = new Subject<Unit>(); //こういうイベントを発行するよ
        public IObservable<Unit> OnMinus => MinusHP;//だからイベント監視したいならこいつを使ってね
        public void Init()
        {
            _hp.Value = MaxHp;
        }

        public void StopMove()
        {
            _isMovable = false;
        }
        public void HpPlus(int plusnum)
        {
            if (_hp.Value + plusnum <= MaxHp)
                _hp.Value += plusnum;
            else _hp.Value = MaxHp;

            PlusHP.OnNext(default);
}
        public void HpMinus(int minusnum)
        {
            if (_hp.Value - minusnum >= 0)
                _hp.Value -= minusnum;
            else _hp.Value = 0;

            MinusHP.OnNext(default);
        }
    }
}