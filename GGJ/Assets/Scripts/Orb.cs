using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public int powerUpEffect;
    public Sprite[] sprites;

    private void Start() {
        // Set the appearance to fit the powerUp Effect
        setAppearance();
    }

    void setAppearance(){
        GetComponent<SpriteRenderer>().sprite = sprites[powerUpEffect];
    }

    void onTriggerEnter(Collider col){
        // If collider is player tag
        if (col.gameObject.name == "Player"){
            col.gameObject.GetComponent<Player>().changeAbilities(powerUpEffect); // Give the player this ability
            Destroy(this); // Delete the orb
        }
    }
}
