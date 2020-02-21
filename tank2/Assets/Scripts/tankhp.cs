using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankhp : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp=100;
    public GameObject tankexplosion;
    public Slider hps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Damage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(10, 20);
        hps.value = hp;
        if (hp <= 0)
        {
            GameObject.Instantiate(tankexplosion,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "debuff")
        {
            hp -= 10;
            hps.value = hp;
            if (hp <= 0)
            {
                GameObject.Instantiate(tankexplosion, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}

