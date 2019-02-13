using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{


    public float speed;
    public Vector2 moveDir;

    public GameObject fx;

    private bool isExit;
    void Update()
    {
        transform.Translate(moveDir * Time.deltaTime * speed);
    }

    private void OnApplicationQuit()
    {
        isExit = true;
    }

    private void OnDestroy()
    {
        if (!isExit && Time.timeScale == 1)
        {
            GameObject p = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;
            p.GetComponent<ParticleSystem>().Play();
            Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
