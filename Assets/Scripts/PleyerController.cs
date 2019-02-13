using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PleyerController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject rocket;

    public int rocketCount;
    public Text txtRocketCount;

    public float shootDelay;

    public int lifePoints;
    public Image[] imgLifePoints;
    public Color[] colorLife;

    public float speed;

    public float minY;
    public float maxY;

    public float minX;
    public float maxX;

    public Transform[] shootPoints;

    public bool isFire;
    public bool isReadyToShoot;

    public int bullDamage;

    public SoundManager sm;

    public int coinsCount;
    public Text coinCountTxt;

    public int scoreCount;
    public Text txtScoreCount;
    public Sprite[] ships;

    private void Start()
    {
        int shipNum = PlayerPrefs.GetInt("ship");
        GetComponent<SpriteRenderer>().sprite = ships[shipNum];
        isReadyToShoot = true;
        isFire = false;
        coinsCount = PlayerPrefs.GetInt("coins",0);

    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void Update()
    {
        coinCountTxt.text = coinsCount.ToString();
        txtRocketCount.text = rocketCount.ToString();
        txtScoreCount.text = scoreCount.ToString();

        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);

        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        transform.localPosition = curPos;

        if (isFire && isReadyToShoot)
        {
            Shoot();
        }
    }

    public void ChangeLife()
    {
        for (int i = 0; i < imgLifePoints.Length; i++)
        {
            if (i < lifePoints)
            {
                imgLifePoints[i].color = colorLife[0];
            }
            else
            {
                imgLifePoints[i].color = colorLife[1];
            }
        }
    }

    public void Shoot()
    {

        foreach (Transform sp in shootPoints)
        {
            GameObject b = Instantiate(bullet, sp.position, Quaternion.identity) as GameObject;
            Destroy(b, 3f);
            if (sp == shootPoints[shootPoints.Length - 1])
            {
                StartCoroutine(ShootDelay());
            }
        }
        sm.PlaySound(3);
    }

    public void RocketShoot()
    {
        if (rocketCount > 0)
        {
            GameObject r = Instantiate(rocket, transform.position, Quaternion.identity) as GameObject;
            rocketCount--;
            sm.PlaySound(2);
        }
    }

    IEnumerator ShootDelay()
    {
        isReadyToShoot = false;
        yield return new WaitForSeconds(shootDelay);
        isReadyToShoot = true;
    }


    public void Fire(bool fire)
    {
        isFire = fire;
    }

    public void Damage(int dmg)
    {
        lifePoints -= dmg;
        if (lifePoints < 0)
        {
            lifePoints = 0;
        }
        ChangeLife();
    }

    public void AdSc(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemyBull"))
        {
            Damage(1);
            sm.PlaySound(1);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            sm.PlaySound(6);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            Damage(2);
            sm.PlaySound(0);
            Destroy(col.gameObject);
        }
    }

    void Safe()
    {
        PlayerPrefs.SetInt("coins", coinsCount);
        PlayerPrefs.SetInt("NewScore", scoreCount);
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", scoreCount);
        }
        else
        {
            int hs = PlayerPrefs.GetInt("HS");
            if (hs < scoreCount)
            {
                PlayerPrefs.SetInt("HS", scoreCount);
            }
        }

    }

    private void OnApplicationQuit()
    {
        Safe();
    }

    public void AddScore(int scoreAdd)
    {

    }
}
