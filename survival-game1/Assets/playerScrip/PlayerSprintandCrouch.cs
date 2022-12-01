using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintandCrouch : MonoBehaviour
{
    private PlayerMoverment PlayerMoverment;



    public float sprint_speed=10f;
    public float move_speed=5f;
    public float crouch_speed=2f;

    private Transform look_Root;
    private float stand_Height=1.6f;
    private float crouch_Height=1f;

    bool is_Crouching;

    void Awake()
    {
        PlayerMoverment=GetComponent<PlayerMoverment>();

        look_Root=transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
                                                //is NOT Crouching > !
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching )   
        {
            PlayerMoverment.speed=sprint_speed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)   &&!is_Crouching )
        {
         PlayerMoverment.speed=move_speed;   

        }
    }

    void Crouch()
    {

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {

            if(is_Crouching)
            {
                 look_Root.localPosition= new Vector3(0f,stand_Height,0f);
                 PlayerMoverment.speed=move_speed;


                 is_Crouching=false;
            }
            else
            {
                look_Root.localPosition= new Vector3(0f,crouch_Height ,0f);
                 PlayerMoverment.speed=move_speed;

                 
                 is_Crouching=true;
            }
        }
    }
}
