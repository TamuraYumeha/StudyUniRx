using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scenes.InGame.Ball
{
    public class BallStatus : MonoBehaviour
    {
        [Header("ボールのパラメータ")]
        [SerializeField, Tooltip("ボールの移動速度")]
        private float _ballMoveSpeed;//ボールの移動速度を決めるパラメータです
        public float BallMoveSpeed { get => _ballMoveSpeed; }//他のスクリプトから_ballMoveSpeedの値を参照したい場合はこの関数を使います


        //いわゆるModelっていう立ち位置なんだと思う
        private ReactiveProperty<bool> _isMovable = new ReactiveProperty<bool>(true);//ボールが移動できるかどうかのパラメータです
                                                                                     //値を動かしたいとき(ただしBallStatus.cs内に限る)はこっち
        public IReadOnlyReactiveProperty<bool> IsMovable { get => _isMovable; }//他のスクリプトから_isMoveの値を参照したい場合はこの関数を使います
                                                                               //中身見たいときはこっち。ReactivePropertyhaは値が変動したら発行してくれる。
                                                                               //get残してるけどなくても動くよ。
        
        public void StopMove()
        {
            _isMovable.Value = false;
        }
    }
}