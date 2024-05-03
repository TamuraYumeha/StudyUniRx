using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifePlus : ItemMove
{
    [SerializeField] private int PlusHP;
    override public void ItemActive() //オーバーライドはこれだけどオーバーロードってどうすんだっけ
    {
        _stickStatus.HpPlus(PlusHP);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) //2Dには2D用の関数があるよ（1敗）
    {
        Debug.Log("tyutatyuta-");
        if (collision.gameObject.CompareTag("Player"))
        {
            ItemActive();
            DestroyItem();
        }
    }
}
