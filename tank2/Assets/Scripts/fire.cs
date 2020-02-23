using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode firecode =KeyCode.Space;
    public Transform firepos;
    public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(firecode))
        {
            GameObject go=GameObject.Instantiate(bullet, firepos.position, firepos.rotation)as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward*15;
        }
    }
}
