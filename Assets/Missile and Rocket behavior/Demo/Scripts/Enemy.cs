using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Missiles
{
    [RequireComponent(typeof(Collider))]
    public abstract class Enemy : MonoBehaviour
    {
        [Range(0.0f, 30.0f)]
        public float speed = 10;

        public bool dead = false;
        public virtual void Move() { }

        public virtual void Dead() { }
    }
}

