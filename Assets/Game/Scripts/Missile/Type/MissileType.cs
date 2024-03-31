using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace Missile
{
    public abstract class MissileType : MonoBehaviour
    {   
        [SerializeField]
        private int atk = 10;
       
        private IProjectable projectable;

        protected void Awake()
        {
            projectable = GetComponent<IProjectable>();
        }
      
        protected abstract void OnEnable();
        protected abstract void OnDisable();

        protected void OnTriggerEnter(Collider other)
        {        
            if (other.TryGetComponent(out IHeatable heatable))
                heatable.Heat(atk);

                         
        }
    }
}
