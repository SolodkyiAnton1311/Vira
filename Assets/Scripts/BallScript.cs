using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    
    [SerializeField] public Rigidbody2D ShootRigid;
    [SerializeField] private float maxDistance;
    [SerializeField] private bool isPressed = false;
    private static BallScript _instance;
    public static BallScript Instance => _instance;
    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, ShootRigid.position) > maxDistance)
            {
                gameObject.GetComponent<Rigidbody2D>().position =
                    ShootRigid.position + (mousePos - ShootRigid.position).normalized * maxDistance;
            }

            else
            {
                gameObject.GetComponent<Rigidbody2D>().position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        UIController.Instance.StartGame();
        isPressed = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        StartCoroutine(Push());
    }

    IEnumerator Push()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.7f),ForceMode2D.Impulse);
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        enabled = false;
    }
    
    public void AddForce(float side)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(side,0),ForceMode2D.Impulse);
    }

    public void NewPoint(Rigidbody2D rigidbody2D)
    {
        enabled = true;
        gameObject.GetComponent<SpringJoint2D>().enabled = true;
        GetComponent<SpringJoint2D>().connectedBody = rigidbody2D;
    }

    public void ChangeSkin(Sprite skin)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = skin;
    }
    
}