using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            PlayerPrefs.SetInt("Star",PlayerPrefs.GetInt("Star",0)+1);
            Destroy(gameObject);
        }
    }

 
}
