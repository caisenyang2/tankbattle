using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameracontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform p1, p2;
    private Vector3 offset;
    private float distance;
    private float timer;
    private float timer2;
    public GameObject robot;
    private float x, z;
    public GameObject begintext;
    public Text sec;
    public Text endtext;
    void Start()
    {
        timer = 1;
        offset = transform.position - (p1.position + p2.position) / 2;
        GameObject.Destroy(begintext, 3);
        timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(p1!=null && p2!=null)
        {
        transform.position = (p1.position + p2.position) / 2 + offset;
        distance = Vector3.Distance(p1.position, p2.position);
        this.GetComponent<Camera>().orthographicSize = distance * 0.78f;
        }
        if (p1 == null &&p2!=null)
        {
            transform.position =p2.position + offset;
            endtext.gameObject.SetActive(true);
            timer2 += Time.deltaTime;
            sec.gameObject.SetActive(true);
            sec.text = timer2.ToString();
            if (timer2 >3)
            {
                endtext.gameObject.SetActive(false);
            }
        }
        if (p2 == null && p1!=null)
        {
            endtext.gameObject.SetActive(true);
            transform.position = p1.position + offset;
            timer2 += Time.deltaTime;
            sec.gameObject.SetActive(true);
            sec.text = timer2.ToString();
            if (timer2 > 3)
            {
                endtext.gameObject.SetActive(false);
            }
        }
        if(p1==null && p2 == null)
        {
            endtext.gameObject.SetActive(true);
            endtext.text = "你永远逃离不了非洲";
        }
        if (timer <= 0)
        {
            x = Random.Range(-45, -15);
            z = Random.Range(-15, 15);
            GameObject.Instantiate(robot,new Vector3(x,1,z),Quaternion.Euler(0,0,0));
            timer = 1;
        }
        timer -= Time.deltaTime;
    }
}
