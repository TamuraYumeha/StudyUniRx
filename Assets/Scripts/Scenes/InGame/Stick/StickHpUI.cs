using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scenes.InGame.Stick;
using UniRx;

public class StickHpUI : MonoBehaviour
{
    [SerializeField] private Image HpImage;
    [SerializeField] private Image[] HpImagesUI = new Image [5];
    private StickStatus _stickStatus;
    // Start is called before the first frame update
    void Start()
    {
        _stickStatus = FindObjectOfType<StickStatus>();
        _stickStatus.OnPlus//ゲームオーバーの時とかに使われてる。終わったのに動いてたら怖いもんね。
                 .Subscribe(_ =>
                 {
                     Debug.Log(_stickStatus.Hp.Value);
                     for(int i = 0; i < _stickStatus.Hp.Value; i++)
                     {
                         HpImagesUI[i].enabled = true;
                     }
                 }).AddTo(this); //HPが変わった発行を受けたらHP
        _stickStatus.OnMinus//ゲームオーバーの時とかに使われてる。終わったのに動いてたら怖いもんね。
                 .Subscribe(_ =>
                 {
                     Debug.Log(_stickStatus.Hp.Value);
                     HpImagesUI[_stickStatus.Hp.Value].enabled = false;
                 }).AddTo(this); //HPが変わった発行を受けたらHP
        /* System.Array.Resize(ref HpImagesUI, _stickStatus.Hp); //HPの変更に合わせて勝手に配列とかいろいろし直してくれるやつ作りたかったけどUIの位置決めができないことに気づいた跡地
         for(int i = 0; i < _stickStatus.Hp; i++)
         {
             HpImagesUI[i] = HpImage;
         }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
