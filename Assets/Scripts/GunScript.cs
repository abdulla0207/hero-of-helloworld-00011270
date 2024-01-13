using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bulletObject;
    public float bulletSpeed = 100f;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            animator.SetBool("isRightMousePressed", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("isRightMousePressed", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            bulletObject.GetComponent<MeshRenderer>().enabled = true;
            var bullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        }
    }

}
