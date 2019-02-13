using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLife : MonoBehaviour {

    public PleyerController Ship;
    public SoundManager sm;

    void Start ()
    {
        Ship = GameObject.Find("Player").GetComponent<PleyerController>();
        sm = GameObject.Find("GameZone").GetComponent<SoundManager>();
    }
	
	void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (Ship.lifePoints < 9)
            {
                Ship.lifePoints += 1;
            }
            else
            {
                Ship.lifePoints = 10;
            }
            sm.PlaySound(6);
            Ship.ChangeLife();
            Destroy(gameObject);
        }
	}
}
