using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform collectPoint;

    public Text moneyText;
    public int moneyValue;
    [SerializeField] int boxValue;

    public int boxLimit;

    playerCont player;

    private void Start()
    {
        player = gameObject.GetComponent<playerCont>();
    }
    private void OnEnable()
    {
        triggerManager.OnBoxCollect += GetBox;
        triggerManager.OnBoxGive += MoneyControl;
    }

    private void OnDisable()
    {
        triggerManager.OnBoxCollect -= GetBox;
        triggerManager.OnBoxGive -= MoneyControl;
    }
    void MoneyControl()
    {
        if (boxList.Count > 0)
        {
            moneyValue += boxValue;
            moneyText.text = moneyValue.ToString();
            RemoveLast();
        }
        

    }
    void GetBox()
    {
        if (boxList.Count <= boxLimit)
        {
            GameObject temp = Instantiate(boxPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 6.2f+((float)boxList.Count / 5), collectPoint.position.z);
            boxList.Add(temp);
            if (triggerManager._boxManager != null)
            {
                triggerManager._boxManager.RemoveLast();
            }
        }
    }
    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
}

