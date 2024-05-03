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
        [SerializeField] private GameObject[] item;
        private int itemNum = (int)ItemEnum.None; //���̃A�C�e�����h���b�v���邩(�m�[�}���̎����None�ɂ�����)

        public void Init()
        {
            _hp = 1;
        }
        public void Break()
        {
            if(itemNum!= (int)ItemEnum.None)
            Instantiate(item[itemNum],this.transform.position, Quaternion.identity);
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