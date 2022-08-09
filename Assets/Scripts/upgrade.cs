using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour
{
    [SerializeField] int upgradeCount;

    [SerializeField] int upgradeEnerjiCount;
    [SerializeField] int upgradeBoxCount;
    [SerializeField] int upgradeSpeedCount;

    [SerializeField] ParticleSystem ps;

    playerCont player;


    collectManager cm;

    private void Start()
    {
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        cm = gameObject.GetComponent<collectManager>();
        player = gameObject.GetComponent<playerCont>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrade"))
        {
            if (upgradeCount <= cm.moneyValue)
            {
                cm.moneyValue -= upgradeCount;
                cm.moneyText.text = cm.moneyValue.ToString();

                player.maxEnerjiBar += upgradeEnerjiCount;
                player.enerjiBar = player.maxEnerjiBar;

                cm.boxLimit += upgradeBoxCount;
                player.speed += upgradeSpeedCount;

                ps.Play();

                upgradeCount += 20;
            }
        }
    }
}
