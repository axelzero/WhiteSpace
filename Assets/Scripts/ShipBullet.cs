using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour {
    public SoundManager sm;

    private void Start()
    {
        sm = GameObject.Find("GameZone").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemyBull"))
        {
            Destroy(coll.gameObject);
            sm.PlaySound(1);
            Destroy(gameObject);
        }
    }
}
