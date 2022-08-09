using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enerjisc : MonoBehaviour
{
    [SerializeField]
    private playerCont playerSc;
    [SerializeField]
    private int count;

    public bool enerjiAlaninda;




    private void Awake()
    {
        playerSc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCont>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enerjiAlaninda = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerSc.enerjiBar < playerSc.maxEnerjiBar)
        {
           playerSc.GetComponent<playerCont>().enerjiBar += count * Time.deltaTime;
           playerSc.GetComponent<playerCont>().EnerjiBarFill();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enerjiAlaninda = false;
        }
    }
}
