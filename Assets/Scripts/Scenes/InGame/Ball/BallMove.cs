using Scenes.InGame.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ǉ����B�Ȃ��Ɠ����Ȃ��͂��B
using UniRx;

namespace Scenes.InGame.Ball
{
    [RequireComponent(typeof(BallStatus), typeof(Rigidbody2D))]
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Vector2 _velocity;
        private Vector2 _pastVelocity;
        [SerializeField, Tooltip("����")]
        private float _power;
        private BallStatus _ballStatus;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _ballStatus = GetComponent<BallStatus>();
            _velocity = new Vector2(1,1).normalized;
            _rigidbody2D.AddForce(_velocity * _power, ForceMode2D.Impulse);
            
            //�󂯎����B���������\��������Start�ɂ����Ă�̂��ȁB
            InGameManager.Instance.OnPause
                .Subscribe(_ =>
                {
                    Pause();
                }).AddTo(this);
            InGameManager.Instance.OnRestart
                .Subscribe(_ =>
                {
                    Restart();
                }).AddTo(this);

            //����������View���Ă�ŁA�{����Plesenter���Ă�ɂ���iSubscribe�j��u���̂������񂾂Ǝv���B
            //ballStatus�Ȃ��Ă����������ˑ��挸�点�ēs���悳����������ˁB
            _ballStatus.IsMovable//�Q�[���I�[�o�[�̎��Ƃ��Ɏg���Ă�B�I������̂ɓ����Ă���|������ˁB
                .Where(_ => _ballStatus.IsMovable.Value == false)//where�ŏ����t���Blinq�Ȃ���̂̏������Ɨ���ł�Ƃ��ǂ��Ƃ��H
                .Subscribe(_ =>
                {   
                    _rigidbody2D.velocity = Vector2.zero;
                }).AddTo(this);
        }
        //TODO:����Update�ł�����BallStatus���Q�Ƃ������Ă��܂��B�C�x���g�@�\���g���āAIsMovable�̒l���ύX���ꂽ�Ƃ��������̏��������s����悤�ɕύX���Ă݂܂��傤
        private void Update()
        {
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("DeadFrame"))
            {
                InGameManager.Instance.GameOver();
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                _rigidbody2D.velocity = Vector2.zero;
                var boundVelocity = transform.position - collision.gameObject.transform.position;
                _rigidbody2D.AddForce(boundVelocity.normalized * _power, ForceMode2D.Impulse);
            }
        }
        private void Pause()
        {
            _pastVelocity = _rigidbody2D.velocity;//���݂̈ړ��������L�^����
            _rigidbody2D.velocity = Vector2.zero;//�ړ����~�߂�
        }
        private void Restart()
        {
            _rigidbody2D.AddForce(_pastVelocity.normalized * _power, ForceMode2D.Impulse);//�ߋ��̈ړ������ɗ͂�������
        }
    }
}