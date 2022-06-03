using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Tower
{
    [RequireComponent(typeof(TowerBuilder))]
    public class TowerComponent : MonoBehaviour
    {
        private List<Block> _blocks;

        public event UnityAction<int> TowerSizeChange;

        private void Start()
        {
            var towerBuilder = GetComponent<TowerBuilder>();
            _blocks = towerBuilder.Build();

            foreach (var block in _blocks)
            {
                block.HitBLock += OnHitBlock;
            }
            TowerSizeChange?.Invoke(_blocks.Count);
        }

        private void OnHitBlock(Block hitenBlock)
        {
            hitenBlock.HitBLock -= OnHitBlock;
            _blocks.Remove(hitenBlock);
            foreach (var block in _blocks)
            {
                var newPosY = block.transform.position.y - block.transform.localScale.y / 4;
                block.transform.position = new Vector3(block.transform.position.x, newPosY, block.transform.position.z);
            }

            TowerSizeChange?.Invoke(_blocks.Count);
        }
    }
}

