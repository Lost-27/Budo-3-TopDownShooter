using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyPickupSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _pickupPrefab;

        [Range(0f, 100f)] 
        [SerializeField] private float _pickupChance;

        public void Spawn()
        {
            float randomChance = Random.Range(1f, 100f);

            if (_pickupChance > randomChance)
            {
                Instantiate(_pickupPrefab[0], transform.position, Quaternion.identity);
            }
        }
    }
}