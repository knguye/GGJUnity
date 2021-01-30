using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public int powerUpEffect;
    public Sprite[] sprites;

    private void Start() 
    {
        // Set the appearance to fit the powerUp Effect
        SetAppearance();
    }

    void SetAppearance()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(powerUpEffect == -1) ? 3 : powerUpEffect];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            powerUpEffect = (int) player.SwapAbility((int) powerUpEffect);
            Debug.Log(powerUpEffect);
            SetAppearance();
        }
    }
}
