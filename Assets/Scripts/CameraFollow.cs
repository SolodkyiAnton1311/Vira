using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private BoxCollider2D rightWall;
    [SerializeField] private BoxCollider2D leftWall;
    [SerializeField] private BoxCollider2D botCollider2D;

    public void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
            leftWall.offset = new Vector2(leftWall.offset.x,newPosition.y+2) ;
            rightWall.offset = new Vector2(rightWall.offset.x,newPosition.y+2) ;
            botCollider2D.offset = new Vector2(botCollider2D.offset.x,newPosition.y-10) ;
        }
    }

   

   
}
