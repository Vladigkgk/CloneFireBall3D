using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _destroedBlock;

        private MeshRenderer _mesh;

        public event UnityAction<Block> HitBLock;

        private void Awake()
        {
            _mesh = GetComponent<MeshRenderer>();
        }

        public void SetColor(Color color)
        {
            _mesh.material.color = color;
        }
        

        public void DestoyBlock()
        {
            HitBLock?.Invoke(this);
            ParticleSystemRenderer render = Instantiate(_destroedBlock, transform.position, _destroedBlock.transform.rotation).GetComponent<ParticleSystemRenderer>();
            render.material.color = _mesh.material.color;
            Destroy(gameObject);
        }
    }
}