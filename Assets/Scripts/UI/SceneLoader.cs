﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicSpace.NinjaDash
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
