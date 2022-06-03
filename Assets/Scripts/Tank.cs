using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _lenght;
        [SerializeField] private float _durationTime;

        private float _timeAfterShoot;

        private void Update()
        {
            _timeAfterShoot += Time.deltaTime;


            if (Input.GetMouseButton(0))
            {
                if (_timeAfterShoot > _durationTime)
                {
                    var bullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
                    bullet.transform.Rotate(new Vector3(0, 180, 0));
                    transform.DOMoveZ(transform.position.z - _lenght, _durationTime / 2).SetLoops(2, LoopType.Yoyo);

                    _timeAfterShoot = 0;
                }
            }
        }
    }
}