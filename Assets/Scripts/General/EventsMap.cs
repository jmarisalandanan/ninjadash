using UnityEngine;
using UnityEngine.Events;
using System;

namespace MagicSpace.NinjaDash
{
    [Serializable]
    public class VectorUnityEvent : UnityEvent<Vector3> { }

    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject> { }

    [Serializable]
    public class UnitAnimationUnityEvent : UnityEvent<UnitAnimation> { }

    [Serializable]
    public class EnemyUnityEvent : UnityEvent<Enemy> { }
}
