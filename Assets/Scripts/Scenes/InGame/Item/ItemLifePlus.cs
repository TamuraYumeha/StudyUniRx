using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifePlus : ItemMove
{
    [SerializeField] private int PlusHP;
    override public void ItemActive() //�I�[�o�[���C�h�͂��ꂾ���ǃI�[�o�[���[�h���Ăǂ����񂾂���
    {
        _stickStatus.HpPlus(PlusHP);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) //2D�ɂ�2D�p�̊֐��������i1�s�j
    {
        Debug.Log("tyutatyuta-");
        if (collision.gameObject.CompareTag("Player"))
        {
            ItemActive();
            DestroyItem();
        }
    }
}
