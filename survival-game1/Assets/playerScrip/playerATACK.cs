using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerATACK : MonoBehaviour
{
    private weaondsmanger weaonds_manger;
    public float fireRate = 15f;
    private float NectTimeToFire;
    public float damage=20f;

    private Animator zoomCamreaAnim;
    private bool zoomed;
    private Camera maincam;
    private GameObject crosshair;
    private bool is_Aiming;

    void Awake()
    {
        weaonds_manger = GetComponent<weaondsmanger>();


        zoomCamreaAnim = transform.Find(Tags.LOOK_ROOT)
            .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();


        crosshair = GameObject.FindGameObjectWithTag(Tags.CROSSHAIR);


        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        weaponShoot();
        ZoomInAndOut();
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
                    if (is_Aiming)//arrow or spear
                    {
                        weaonds_manger.GetCurrentSelectedWeapon().shootAnimation();

                        if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.ARROW)
                        {

                        }
                        else if (weaonds_manger.GetCurrentSelectedWeapon().BulletTYPE == WeapondBulletTYPE.SPEAR) ;
                    }//throw spear 
                }

            }
        }

    }
    void ZoomInAndOut()
    {                               //amin with cam on the weapon
        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.AIM)
        {
            if (Input.GetMouseButtonDown(1))//pressed and holded 
            {
                zoomCamreaAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);

            }
            if (Input.GetMouseButtonUp(1))// wehen released.
            {
                zoomCamreaAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);

            }
        }//if we need to zoom the weapon
        if (weaonds_manger.GetCurrentSelectedWeapon().weapon_Aim == weaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weaonds_manger.GetCurrentSelectedWeapon().Aim(true);
                is_Aiming = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                weaonds_manger.GetCurrentSelectedWeapon().Aim(false);
                is_Aiming = false;
            }
        }//self aim 
    }

}
