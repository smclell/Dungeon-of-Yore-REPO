using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 4f;
    public Transform target;

    public float xOffset = 1f;
    public float yOffset = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPOS = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPOS, followSpeed * Time.deltaTime);
    }
}
