using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    // Start is called before the first frame update
    private int rot;
    private float timer;
    public bool act;
    void Start()
    {
        timer = 3;
        act = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (act == true) { 
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
        rot = Random.Range(-180, 180);
            transform.Rotate(new Vector3(0, rot, 0));
        timer = 3;
        }

        }
        else
        {
            transform.Rotate(0, 5, 0);
        }
    }
}
