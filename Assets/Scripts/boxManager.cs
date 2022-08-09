using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform exitPoint;
    bool isWorking;
    float xPlus =0;
    void Start()
    {
        StartCoroutine(KutuOluþturma());
    }

    void Update()
    {
        
    }
    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
    IEnumerator KutuOluþturma()
    {
        while (true)
        {
            if (isWorking)
            {
                GameObject temp = Instantiate(boxPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x , exitPoint.position.y + xPlus / 5, exitPoint.position.z);
                xPlus++;
                boxList.Add(temp);
                if (boxList.Count >= 5)
                {
                    isWorking = false;
                }
            }
            else if (boxList.Count < 5)
            {
                isWorking = true;
            }
           
            yield return new WaitForSeconds(1);
        }
    }
}
