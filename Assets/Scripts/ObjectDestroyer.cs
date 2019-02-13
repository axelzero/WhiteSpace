using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {


	
	void Update ()
    {
        Destroyer();
    }

    void Destroyer()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

}
