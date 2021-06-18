using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 1.0f;

    private void Update()
    {
        transform.position = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * speed, speed));
    }

}
