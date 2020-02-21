using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tankcontroller : MonoBehaviour
{
    public AudioClip aoligei;
    // Start is called before the first frame update
    public float speed=5;
    private Rigidbody rig;
    private float v,h;
    public int number=1;
    public AudioClip idle;
    public AudioClip moving;
    private AudioSource audiosource;
    private float slow;
    void Start()
    {
        rig=GetComponent<Rigidbody>();
        slow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        audiosource = GetComponent<AudioSource>();
        if (slow <= 0)
        {
            speed = 10;
        }
        else { speed = 5; }
        slow -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        v = Input.GetAxis("Vertical"+number);
        h = Input.GetAxis("Horizontal"+number);
        rig.velocity = transform.forward * speed*v;
        transform.Rotate(transform.up * h*3);
        if(Mathf.Abs(h)>0.1|| Mathf.Abs(v) > 0.1)
        {
            audiosource.clip = moving;
            if(audiosource.isPlaying==false)
            audiosource.Play();
        }
        else
         {
            
                audiosource.clip = idle;
            if (audiosource.isPlaying == false)
                
                audiosource.Play();
         }


    }
private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "debuff")
        {
            slow = 5;
            other.GetComponent<AudioSource>().Play();
            GameObject.Destroy(other.gameObject,5);
            other.transform.position = this.transform.position + new Vector3(0, 4, 0);
            other.GetComponent<robot>().act = false;
            other.transform.parent = this.transform;
        }
    }
}
