using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestDataPath : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(Application.dataPath);
        }
    }
}