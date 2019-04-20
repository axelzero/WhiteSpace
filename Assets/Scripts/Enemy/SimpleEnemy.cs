using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    //public static SimpleEnemy simpleEnemy;

    public int lifePoints;

    public GameObject bullet;
    public Transform[] shootPlace;

    public float shootDelay;
    private float shootDelayStart;  // Сюда будет записано значение, которое будет постоянным для определенного обьекта

    public bool isEnemyDead = false;

    public PleyerController ship;

    public SoundManager sm;

    public GameObject Coin;

    private Root root;

    private void Awake()
    {
       // simpleEnemy = this;
    }

    private void Start()
    {
        lifePoints = PlayerPrefs.GetInt("lifePoints");

        sm = GameObject.Find("GameZone").GetComponent<SoundManager>();
        shootDelay = PlayerPrefs.GetFloat("shootDelay");
        //if (Root.rootGame.GameState == Root.Game.Play)   
        //{
        //    InvokeRepeating("Shoot", 2, shootDelay);
        //}

        StartCoroutine(ShootCaroutine(shootDelayStart));

        ship = GameObject.Find("Player").GetComponent<PleyerController>();
    }

    IEnumerator ShootCaroutine(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            Shoot();
            Debug.Log("current time is " + time);
            yield return new WaitForSeconds(shootDelay);
        }
    }

    private void Update()
    {
        if (lifePoints == 0 && !isEnemyDead)
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
        if (Root.rootGame.GameState == Root.Game.Play)
        {
            for (int i = 0; i < shootPlace.Length; i++)
            {
                GameObject b = Instantiate(bullet, shootPlace[i].position, Quaternion.identity) as GameObject;
                sm.PlaySound(5);
                Destroy(b, 4f);
            }
        }
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

        //if (col.gameObject.CompareTag("enemyBull"))
        //{
        //    Damage(1);
        //    sm.PlaySound(1);
        //    Destroy(col.gameObject);
        //}
    }
}
