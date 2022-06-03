using System.Collections;
using UnityEngine;
using Assets.Scripts.ObstacleFolder;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _force = 100;
        [SerializeField] private float _radius = 100;

        private Vector3 _diration;

        private void Start()
        {
            _diration = Vector3.forward;
        }

        private void FixedUpdate()
        {
            transform.Translate(_diration * _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Block block))
            {
                block.DestoyBlock();
                Destroy(gameObject);
            }
            if (other.TryGetComponent(out Obstakcle type))
            {
                Bounces();  
            }

        }

        private void Bounces()
        {
            _diration = Vector3.back + Vector3.up;
            /*var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(_force, transform.position + new Vector3(0, 1, 1), _radius);*/
        }
    }
}