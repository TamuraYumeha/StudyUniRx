using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.InGame.Stick; //�ǂ��ɏڍ׏�����Ă񂾂���

public class ItemMove : MonoBehaviour
{
    [SerializeField] private float limitmin;//y�������Ɉړ��ł���Œ�l
    private float ItemNum; //�A�C�e���̔ԍ�
    protected private StickStatus _stickStatus;
    public virtual void ItemActive()
    {
        //�������ۃN���X
    }
    protected private void Start() //protected�Ƃ́H
    {
        _stickStatus = FindObjectOfType<StickStatus>();
    }
    protected private void Update()
    {
        if (this.gameObject.transform.position.y <= limitmin)
        {
            DestroyItem();
        }    
    }
    public void DestroyItem()
    {
        //�擾�������Ƃ�������Ȃ̂���
        Destroy(this.gameObject);
    }
}
