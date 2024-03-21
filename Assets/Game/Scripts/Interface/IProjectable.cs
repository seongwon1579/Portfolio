using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missile
{
    public interface IProjectable
    {
        public GameObject projectablePrefab { get; }
        public int numberOfPrefabs { get; }
        public void Enqueue();
    }
}
