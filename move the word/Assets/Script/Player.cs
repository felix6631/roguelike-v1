using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(1,1,-1).normalized * 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = Input.GetAxis("Vertical") / 100000;
        float moveX = Input.GetAxis("Horizontal") / 100000;

        if(moveX != 0)transform.Translate(new Vector2(moveX,0).normalized * 0.1f);
        if(moveZ != 0) transform.Translate(new Vector2(0, moveZ).normalized * 0.1f);
        Debug.Log(moveZ);
        Debug.Log(moveX);
    }
}
