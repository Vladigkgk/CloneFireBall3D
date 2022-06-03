using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.ObstacleFolder
{
    public class RotateObstacle : MonoBehaviour
    {

        [SerializeField] private float _duration;

        private void Start()
        {
            transform.DORotate(new Vector3(0, 360, 0), _duration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        }
    }
}