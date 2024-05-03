using UnityEngine;
using UniRx;
using System;

namespace Scenes.InGame.Block
{
    public class Block : MonoBehaviour, IDamagable
    {
        [Header("ブロックのパラメータ")]
        [Tooltip("ブロックの耐久度")]
        public int _hp;             //どうにか保護レベル上げられない？

        public virtual void  Break()
        {
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