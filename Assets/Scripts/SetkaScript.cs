using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetkaScript : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D setka;
    
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
          
            BallScript.Instance.ShootRigid = GetComponent<Rigidbody2D>();
            BallScript.Instance.NewPoint(GetComponent<Rigidbody2D>());
            setka.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.score++;
            GameManager.Instance.spawnSetka();
            
        }
    }
}
