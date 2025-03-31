using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 마우스 입력에 따라 x, y축을 회전하고 싶다
public class CameraRotate : MonoBehaviour
{
    float rx, ry;
    public float rotSpeed = 200;

    void Start()
    {
        
    }

    void Update()   
    {
        // 1. 사용자의 마우스 입력을 누적하고 싶다
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rx += my * rotSpeed * Time.deltaTime;
        ry += mx * rotSpeed * Time.deltaTime;
        rx = Mathf.Clamp(rx, -75, 75);
        // 2. 그 누적 값으로 x, y축을 회전하고 싶다
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
