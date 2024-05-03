using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System;

namespace Scenes.InGame.Stick
{
    public class StickStatus : MonoBehaviour
    {
        [Header("�X�e�B�b�N�̉σp�����[�^")]
        [SerializeField, Tooltip("�X�e�B�b�N���ړ����鑬�x")]
        private float _moveSpeed;//�X�e�B�b�N�̈ړ����x�����߂�p�����[�^�ł�
        [SerializeField] private int MaxHp;//HP�̍ő�l 
        [SerializeField, Tooltip("�X�e�B�b�N��HP")]
        private ReactiveProperty<int> _hp = new ReactiveProperty<int>(); //�X�e�B�b�N�̎c�@

        public float MoveSpeed { get => _moveSpeed; }//���̃X�N���v�g����_moveSpeed�̒l���Q�Ƃ������ꍇ�͂��̊֐����g���܂�
        private bool _isMovable = true;//�X�e�B�b�N���ړ��ł��邩�ǂ����̃p�����[�^�ł�
        public bool IsMovable { get => _isMovable; }//���̃X�N���v�g����_isMovable�̒l���Q�Ƃ������ꍇ�͂��̊֐����g���܂�
        public IReadOnlyReactiveProperty<int> Hp { get => _hp; }//���̃X�N���v�g����_hp�̒l���Q�Ƃ������ꍇ�͂��̊֐����g���܂�


        private Subject<Unit> PlusHP = new Subject<Unit>(); //���������C�x���g�𔭍s�����
        public IObservable<Unit> OnPlus => PlusHP;//������C�x���g�Ď��������Ȃ炱�����g���Ă�

        private Subject<Unit> MinusHP = new Subject<Unit>(); //���������C�x���g�𔭍s�����
        public IObservable<Unit> OnMinus => MinusHP;//������C�x���g�Ď��������Ȃ炱�����g���Ă�
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