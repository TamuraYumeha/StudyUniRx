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
        _stickStatus.OnPlus//�Q�[���I�[�o�[�̎��Ƃ��Ɏg���Ă�B�I������̂ɓ����Ă���|������ˁB
                 .Subscribe(_ =>
                 {
                     Debug.Log(_stickStatus.Hp.Value);
                     for(int i = 0; i < _stickStatus.Hp.Value; i++)
                     {
                         HpImagesUI[i].enabled = true;
                     }
                 }).AddTo(this); //HP���ς�������s���󂯂���HP
        _stickStatus.OnMinus//�Q�[���I�[�o�[�̎��Ƃ��Ɏg���Ă�B�I������̂ɓ����Ă���|������ˁB
                 .Subscribe(_ =>
                 {
                     Debug.Log(_stickStatus.Hp.Value);
                     HpImagesUI[_stickStatus.Hp.Value].enabled = false;
                 }).AddTo(this); //HP���ς�������s���󂯂���HP
        /* System.Array.Resize(ref HpImagesUI, _stickStatus.Hp); //HP�̕ύX�ɍ��킹�ď���ɔz��Ƃ����낢�낵�����Ă������肽����������UI�̈ʒu���߂��ł��Ȃ����ƂɋC�Â����Ւn
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
