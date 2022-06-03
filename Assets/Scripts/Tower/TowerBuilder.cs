using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int _towerSize;
        [SerializeField] private Transform _buildPoint;
        [SerializeField] private Block _block;
        [SerializeField] private Color[] _colors;


        public List<Block> Build() 
        {
            List<Block> _blocks = new List<Block>();

            var currentBuildPoint = _buildPoint;

            for (int i = 0; i < _towerSize; i++)
            {
                var block = BuildBlock(currentBuildPoint);
                block.SetColor(_colors[Random.Range(0, _colors.Length)]);
                _blocks.Add(block);
                currentBuildPoint = block.transform;
            }

            return _blocks;
        }

        private Block BuildBlock(Transform currentPoint)
        {
            return Instantiate(_block, GetCurrentPointBuild(currentPoint), Quaternion.identity, _buildPoint);
        }

        private Vector3 GetCurrentPointBuild(Transform pointSegment)
        {
            return new Vector3(_buildPoint.position.x, pointSegment.position.y + pointSegment.localScale.y / 4, _buildPoint.position.z);
        }

    }
}