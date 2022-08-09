using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCont : MonoBehaviour
{
    private Rigidbody rb;
    private FixedJoystick fixedJoystick;
    public Animator anim;

    public int speed;

    
    public float enerjiBar;
    public float maxEnerjiBar;

    GameObject enerjiAlaný;
    enerjisc enerjiSc;

    public Image enerjiBarImage;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        anim = GetComponent<Animator>();
        
        enerjiAlaný = GameObject.FindGameObjectWithTag("EnerjiAlaný");
        enerjiSc = GameObject.FindGameObjectWithTag("EnerjiAlaný").GetComponent<enerjisc>();
        enerjiBar = maxEnerjiBar;
    }

    private void Update()
    {
        rb.velocity = new Vector3(fixedJoystick.Horizontal * speed, rb.velocity.y, fixedJoystick.Vertical * speed);

        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            this.gameObject.transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("isMoving", true);
            if (!enerjiSc.enerjiAlaninda)
            {
                enerjiBar -= Time.deltaTime;
                EnerjiBarFill();
            }
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


        if (enerjiBar <= 0)
        {
            gameObject.transform.position = enerjiAlaný.transform.position;
        }
    }

    public void EnerjiBarFill()
    {
        enerjiBarImage.fillAmount = enerjiBar / maxEnerjiBar;
    }

}
