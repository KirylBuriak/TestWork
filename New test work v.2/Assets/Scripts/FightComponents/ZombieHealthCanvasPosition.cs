using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthCanvasPosition : MonoBehaviour
{
   
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
