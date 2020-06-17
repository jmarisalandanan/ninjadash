using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class SegmentHandler : MonoBehaviour
    {
        private const float SEGMENT_Y_INTERVAL = 12f;

        [SerializeField]
        private List<GameObject> objectsToSpawn;

        private float currentSegmentY;

        public void Spawn()
        {
            var spawnPos = Vector3.zero;
            spawnPos.y += currentSegmentY;
            var segment = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)], spawnPos, Quaternion.identity, this.transform);
            currentSegmentY += SEGMENT_Y_INTERVAL;
        }

        private void Awake()
        {
            Spawn();
        }
    }
}
