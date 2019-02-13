using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public GameObject[] bonuses;
    public int lifePoints = 5;

    private bool isDead = false;

    public SoundManager sm;

    void Start()
    {
        sm = GameObject.Find("GameZone").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (lifePoints == 0 && !isDead)
        {
            Boom();
        }
    }

    void Boom ()
    {
        isDead = true;
        GameObject bonus = bonuses[Random.Range(0, bonuses.Length)];
        GameObject b = Instantiate(bonus, transform.position, Quaternion.identity) as GameObject;
        sm.PlaySound(0);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerBull"))
        {
            lifePoints--;
            sm.PlaySound(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("shipR"))
        {
            lifePoints = 0;
            Destroy(collision.gameObject);
        }
    }
}
