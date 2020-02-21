using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shellexplosion;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        GameObject se= GameObject.Instantiate(shellexplosion, transform.position, transform.rotation)as GameObject;
        GameObject.Destroy(this.gameObject);
        GameObject.Destroy(se, 1.5f);
        if (other.tag == "tank")
        {
            other.SendMessage("Damage");
        }
    }
}