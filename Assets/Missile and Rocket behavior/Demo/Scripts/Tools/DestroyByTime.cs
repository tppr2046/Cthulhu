using System;
using UnityEngine;

namespace Missiles
{
    public class DestroyByTime : MonoBehaviour
    {
        [SerializeField] private float time = 1.0f;


        private void Awake()
        {
            Invoke("DestroyGameObject", time);
        }


        private void DestroyGameObject()
        {
            DestroyObject(gameObject);
        }
    }
}
