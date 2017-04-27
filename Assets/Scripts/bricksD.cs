using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksD : MonoBehaviour {


    private void OnCollisionEnter(Collision other)
    {
        gameM.instance.DestroyBrick();
        Destroy(gameObject);
    }

}
