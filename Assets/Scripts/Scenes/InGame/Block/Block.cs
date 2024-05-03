using UnityEngine;
using UniRx;
using System;

namespace Scenes.InGame.Block
{
    public class Block : MonoBehaviour, IDamagable
    {
        [Header("�u���b�N�̃p�����[�^")]
        [Tooltip("�u���b�N�̑ϋv�x")]
        public int _hp;             //�ǂ��ɂ��ی샌�x���グ���Ȃ��H

        public virtual void  Break()
        {
            Destroy(gameObject);
        }

        public void Damange(int damage)
        {
            if (damage < 0) return;//�_���[�W�����̏ꍇ�͏�����Ԃ�
            _hp = _hp - damage;
            if(_hp <= 0)
            {
                Manager.InGameManager.Instance.BlockDestroy();
                Break();
            }
        }
    }
}