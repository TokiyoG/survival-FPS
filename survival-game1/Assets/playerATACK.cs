using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerATACK : MonoBehaviour
{
    private weaondsmanger weaonds_manger;
    public float fireRate = 15f;
    private float NectTimeToFire;
    public float damage=20f;
    void Awake()
    {
        weaonds_manger = GetComponent<weaondsmanger>();
    }

    // Update is called once per frame
    void Update()
    {
        weaponShoot();
    }
    void weaponShoot()
    {          //if we selected the AR
        if (weaonds_manger.GetCurrentSelectedWeapon().FireType == weapondsFireType.MULTIPLE)
        {           //if pressed and holded the left mouse click
            if (Input.GetMouseButton(0) && Time.time > NectTimeToFire)
            {

                NectTimeToFire = Time.time + 1f / fireRate;

                weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();
            }
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {           //handle axe
                if (weaonds_manger.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();
                }
                //handle shoot
                if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.BULLET)
                {
                    weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();

                 // bulletFired();

                }
                else
                {

                }

            }
        }
    }
}
