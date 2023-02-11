using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Missiles
{
    public class SimpleLauncher : MonoBehaviour
    {
        public GameObject proyectile;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(proyectile, transform.position, transform.rotation);
            }
        }
    }
}
