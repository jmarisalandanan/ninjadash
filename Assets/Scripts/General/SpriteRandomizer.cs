using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRandomizer : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> spritePool;
        [SerializeField]
        private bool randomizeScale;
        [SerializeField]
        private bool randomizeRotation;
        [SerializeField]
        private Vector2 randomScaleRange;

        private SpriteRenderer thisSprite;

        private void Awake()
        {
            thisSprite = this.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            thisSprite.sprite = spritePool[Random.Range(0, spritePool.Count)];
            if (randomizeScale)
            {
                var randomScale = Random.Range(randomScaleRange.x, randomScaleRange.y);
                transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            }

            if (randomizeRotation)
            {
                var randomRot = Random.rotation;
                randomRot.x = 0;
                randomRot.y = 0;
                transform.rotation = randomRot;
            }
        }
    }
}
