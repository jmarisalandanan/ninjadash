using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectToSpawn;

        public void SpawnAtLocation(Vector3 position)
        {
            var go = GameObject.Instantiate(objectToSpawn, position, Quaternion.identity);
        }

        public void Spawn()
        {
            var go = GameObject.Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
