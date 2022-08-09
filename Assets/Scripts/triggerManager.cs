using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnBoxCollect;
    public static boxManager _boxManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnBoxGive;
    public static Money money;

    public bool isGiving;
    bool isCollecting;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                OnBoxCollect();
            }
            if (isGiving)
            {
                OnBoxGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            _boxManager = other.gameObject.GetComponent<boxManager>();
        }
        if (other.gameObject.CompareTag("MoneyArea"))
        {
            isGiving = true;
            money = other.gameObject.GetComponent<Money>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            _boxManager = null;
        }
        if (other.gameObject.CompareTag("MoneyArea"))
        {
            isGiving = false;
        }
    }
}
