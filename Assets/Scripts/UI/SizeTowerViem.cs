using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.Tower;
using DG.Tweening;

namespace Assets.Scripts.UI
{
    public class SizeTowerViem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _sizeView;
        [SerializeField] private TowerComponent _tower;

        private void OnEnable()
        {
            _tower.TowerSizeChange += OnTowerSizeChange;
        }

        private void OnTowerSizeChange(int count)
        {
            _sizeView.text = count.ToString();
            if (count == 0)
            {
                Destroy(gameObject);
            }
        }


        private void OnDestroy()
        {
            _tower.TowerSizeChange -= OnTowerSizeChange;
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }
}