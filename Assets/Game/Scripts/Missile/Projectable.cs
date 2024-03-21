using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missile
{
    public class Projectable : MonoBehaviour, IProjectable
    {
        [SerializeField]
        private int number = 30;

        public GameObject projectablePrefab => gameObject;
        public int numberOfPrefabs => number;

        private void Awake()
        {
            int index = gameObject.name.IndexOf("(Clone)");
            if(index > 0)
            {
                gameObject.name = gameObject.name.Substring(0, index);
            }
        }
        public void Enqueue()
        {
            MissileController.missilePoolDic[gameObject.name].Enqueue(gameObject);
        }
    }
}
