using UnityEngine;
using UniRx;
using System;

namespace Scenes.InGame.Block
{
    public class Block : MonoBehaviour, IDamagable
    {
        [Header("ブロックのパラメータ")]
        [SerializeField,Tooltip("ブロックの耐久度")]
        private int _hp = 1;
        [SerializeField] private GameObject[] item;
        private int itemNum = (int)ItemEnum.None; //何のアイテムをドロップするか
        public void Break()
        {
            if(itemNum!= (int)ItemEnum.None)
            Instantiate(item[itemNum],this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public void Damange(int damage)
        {
            if (damage < 0) return;//ダメージが負の場合は処理を返す
            _hp = _hp - damage;
            if(_hp <= 0)
            {
                Manager.InGameManager.Instance.BlockDestroy();
                Break();
            }
        }
    }
}