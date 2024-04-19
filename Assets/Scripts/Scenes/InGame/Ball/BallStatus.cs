using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Scenes.InGame.Ball
{
    public class BallStatus : MonoBehaviour
    {
        [Header("�{�[���̃p�����[�^")]
        [SerializeField, Tooltip("�{�[���̈ړ����x")]
        private float _ballMoveSpeed;//�{�[���̈ړ����x�����߂�p�����[�^�ł�
        public float BallMoveSpeed { get => _ballMoveSpeed; }//���̃X�N���v�g����_ballMoveSpeed�̒l���Q�Ƃ������ꍇ�͂��̊֐����g���܂�


        //������Model���Ă��������ʒu�Ȃ񂾂Ǝv��
        private ReactiveProperty<bool> _isMovable = new ReactiveProperty<bool>(true);//�{�[�����ړ��ł��邩�ǂ����̃p�����[�^�ł�
                                                                                     //�l�𓮂��������Ƃ�(������BallStatus.cs���Ɍ���)�͂�����
        public IReadOnlyReactiveProperty<bool> IsMovable { get => _isMovable; }//���̃X�N���v�g����_isMove�̒l���Q�Ƃ������ꍇ�͂��̊֐����g���܂�
                                                                               //���g�������Ƃ��͂������BReactivePropertyha�͒l���ϓ������甭�s���Ă����B
                                                                               //get�c���Ă邯�ǂȂ��Ă�������B
        
        public void StopMove()
        {
            _isMovable.Value = false;
        }
    }
}