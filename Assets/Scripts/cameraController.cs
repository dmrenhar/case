using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float chaseSpeed;

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerCont>().transform;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, chaseSpeed);
    }
}
