using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePush : MonoBehaviour
{
    public float forceMagnitude;
    
   private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (gameObject.tag.Equals("Player"))
        {
            Rigidbody rigid = hit.collider.attachedRigidbody;

            if (rigid != null)
            {
                Vector3 forceDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                rigid.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
    }
}
   
