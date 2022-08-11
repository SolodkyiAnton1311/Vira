
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public float side;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            if (PlayerPrefs.GetInt("Vibrate",1) == 1)
            {
                Handheld.Vibrate();
            }

            if (PlayerPrefs.GetInt("Sound",1) == 1)
            {
                SoundManagerScript.Instance.Knock();
            }
            BallScript.Instance.AddForce(side);
            
        }
    }
}
