using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scenes.InGame.Block
{
    public class ItemBlock : Block
    {
        [SerializeField] private GameObject[] item;
        private int itemNum = (int)ItemEnum.Lifeplus; //何のアイテムをドロップするか
        override public void Break()
        {
            if (itemNum != (int)ItemEnum.None)
                Instantiate(item[itemNum], this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        void Start()
        {
            //
        }
    }
}