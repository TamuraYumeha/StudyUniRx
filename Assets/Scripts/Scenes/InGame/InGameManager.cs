using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.InGame.Ball;
using Scenes.InGame.Stick;
using TMPro;

//�ȉ��Ȃ񂩓����Ȃ�����u�����B��������ɕK�v�Ȃ��ꂻ�ꂪ�l�܂��Ă�B
using UniRx;
using System;

namespace Scenes.InGame.Manager
{
    public class InGameManager : MonoBehaviour
    {
        BallSpawner _ballSpawner;
        BallStatus _ballStatus;
        StickStatus _stickStatus;
        public static InGameManager Instance;
        private int _score = 0;//�X�R�A
        private int _blockSize = 0;//block�̐�
        [SerializeField,Tooltip("�X�R�A��\������UI")]
        TextMeshProUGUI _socreText;

        private Subject<Unit> Pause = new Subject<Unit>(); //���������C�x���g�𔭍s�����
        public IObservable<Unit> OnPause => Pause;//������C�x���g�Ď��������Ȃ炱�����g���Ă�
                                                  //�΂�܂��p�̎莆�Ɣ��s��ɐݒu����|�X�g�̐݌v�}������Ă���Ă�݂����ȁH��������
                                                  //Unit���ĂȂ񂾂�Ƃ͎v��Ȃ����Ȃ��̂ł��ƂŒ��ׂĂ݂Ă�

        private Subject<Unit> Restart = new Subject<Unit>();
        public IObservable<Unit> OnRestart => Restart;

        //Todo
        //private ReactiveProperty<bool> BallNoMove => new ReactiveProperty<bool>(_ballStatus.IsMovable);
        //public  IReadOnlyReactiveProperty<bool> OnBallNoMove => BallNoMove;
        
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            _ballSpawner = GetComponent<BallSpawner>();
            StartCoroutine(BallSpawn());
        }

       
        IEnumerator BallSpawn()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            _ballSpawner.Spawn();
        }

        public void GameOver()
        {
            _ballStatus = FindObjectOfType<BallStatus>();
            _stickStatus = FindObjectOfType<StickStatus>();
            _ballStatus.StopMove();
            _stickStatus.StopMove();
        }
        public void BlockSize(int i)
        {
            _blockSize = i;
        }

        public void GamePause()//�Q�Ƃ�unity�̕��Őݒ肵�Ă�B�{�^��������B
        {
            Pause.OnNext(default);//�����Ŕ��s���Ă�
        }

        public void GameRestart()
        {
            Restart.OnNext(default);
        }

        public void BlockDestroy()
        {
            _score += 100;
            _blockSize--;
            _socreText.text = $"SCORE:{_score}";
            if(_blockSize <= 0)
            {
                GameOver();
            }
        }
    }
}