using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            UIController.Instance.showGameOver();
            Destroy(col.gameObject);
            Camera.main.gameObject.GetComponent<CameraFollow>().enabled = false;
        }
    }
}
