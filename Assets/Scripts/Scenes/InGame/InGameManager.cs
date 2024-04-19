using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.InGame.Ball;
using Scenes.InGame.Stick;
using TMPro;

//以下なんか動かないから置いた。多分これに必要なあれそれが詰まってる。
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
        private int _score = 0;//スコア
        private int _blockSize = 0;//blockの数
        [SerializeField,Tooltip("スコアを表示するUI")]
        TextMeshProUGUI _socreText;

        private Subject<Unit> Pause = new Subject<Unit>(); //こういうイベントを発行するよ
        public IObservable<Unit> OnPause => Pause;//だからイベント監視したいならこいつを使ってね
                                                  //ばらまく用の手紙と発行先に設置するポストの設計図を作ってやってるみたいな？多分そう
                                                  //Unitってなんだよとは思わなくもないのであとで調べてみてね

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

        public void GamePause()//参照はunityの方で設定してる。ボタンだから。
        {
            Pause.OnNext(default);//ここで発行してる
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