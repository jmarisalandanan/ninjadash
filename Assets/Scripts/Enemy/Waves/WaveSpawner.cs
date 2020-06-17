using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<WaveController> waves;
        [SerializeField]
        private List<Transform> waveSpawn;

        public void SpawnWave()
        {
            var wave = GameObject.Instantiate(waves[Random.Range(0, waves.Count)], waveSpawn[Random.Range(0, waveSpawn.Count)]);
        }

        private void Start()
        {
            SpawnWave();
        }
    }
}
