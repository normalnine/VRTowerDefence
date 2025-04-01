using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public Transform hand;
    public Transform player;
    LineRenderer lr;
    public Transform marker;
    public float kAdjust = 1;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        marker.localScale = Vector3.one * kAdjust;
    }

    void Update()
    {
        // 마우스 오른쪽 버튼을 누르면 Ready상태가 되고
        // 마우스 오른쪽 버튼을 떼면 이동하고 싶다.

        // 마우스 오른쪽 버튼을 누르면
        
        // 핸드의 위치에서 핸드의 앞방향으로 Ray를 발사하고
        Ray ray = new Ray(hand.position, hand.forward);
        lr.SetPosition(0, ray.origin);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(ray, out hitInfo);
        // 부딪힌 곳이 있다면 플레이어를 그 곳으로 이동하고 싶다
        if(isHit)
        {
            // 어딘가 부딪혔다
            lr.SetPosition(1, hitInfo.point);
            marker.position = hitInfo.point;
            marker.up = hitInfo.normal;
            marker.localScale = Vector3.one * kAdjust * hitInfo.distance;
        }
        else
        {
            // 허공이다 hand의 100m 앞
            // ray.origin + ray.direction * 100
            lr.SetPosition(1, ray.origin + ray.direction * 100);
            marker.position = ray.origin + ray.direction * 100;
            marker.up = -ray.direction;
            marker.localScale = Vector3.one * kAdjust * 100;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            lr.enabled = true;
        }
        else if(Input.GetButtonUp("Fire2"))
        {
            // 떼면 선을 안보고 싶다
            lr.enabled = false;

            // 만약 닿은곳이 있다면?
            if (isHit)
            {
                // 만약 닿은곳이 "Tower" 태그가 있다면 그 타워의 위치로 이동하고
                if(hitInfo.collider.CompareTag("Tower"))
                {
                    player.position = hitInfo.collider.transform.position;
                }
                else
                {
                    // 그렇지 않다면 닿은곳에 이동하고 싶다.
                    player.position = hitInfo.point;
                }
            }
        }        
    }
}
