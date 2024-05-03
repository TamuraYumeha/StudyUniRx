using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.InGame.Stick; //どこに詳細書かれてんだこれ

public class ItemMove : MonoBehaviour
{
    [SerializeField] private float limitmin;//y軸方向に移動できる最低値
    private float ItemNum; //アイテムの番号
    protected private StickStatus _stickStatus;
    public virtual void ItemActive()
    {
        //多分抽象クラス
    }
    protected private void Start() //protectedとは？
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
        //取得音いれるとかもありなのかも
        Destroy(this.gameObject);
    }
}
