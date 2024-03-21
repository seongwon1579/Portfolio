using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missile
{
    public class ForwardType : MissileType
    {
        [SerializeField]
        Rigidbody rb;

        protected override void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
            LaunchMissile();
        }

        private void LaunchMissile()
        {
            Vector3 moveDir = transform.forward;
            rb.AddForce(moveDir * 10f, ForceMode.Impulse);
        }

        protected override void OnDisable()
        {
            rb.velocity = Vector3.zero;
        }
    }
}

