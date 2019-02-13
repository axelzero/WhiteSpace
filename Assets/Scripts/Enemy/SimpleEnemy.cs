using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    public int lifePoints;

    public GameObject bullet;
    public Transform shootPlace;
    public float shootDelay;

    public bool isEnemyDead = false;

    public PleyerController ship;

    public SoundManager sm;

    public GameObject Coin;

    private void Start()
    {
        sm = GameObject.Find("GameZone").GetComponent<SoundManager>();

        InvokeRepeating("Shoot", 2, shootDelay);
        ship = GameObject.Find("Player").GetComponent<PleyerController>();
    }

    private void Update()
    {
        if (lifePoints == 0 && !isEnemyDead )
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        isEnemyDead = true;
        sm.PlaySound(0);
        SpawnCoin();
        ship.AdSc(25);
        Destroy(gameObject);
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(Coin, transform.position, Quaternion.identity) as GameObject;
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, shootPlace.position, Quaternion.identity) as GameObject;
        sm.PlaySound(5);
        Destroy(b, 3f);
    }


    public void Damage(int dmg)
    {
        lifePoints -= dmg;
        if (lifePoints < 0)
        {
            lifePoints = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("playerBull"))
        {
            Damage(ship.bullDamage);
            sm.PlaySound(1);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("enemyBull"))
        {
            Damage(1);
            sm.PlaySound(1);
            Destroy(col.gameObject);
        }
    }
}
