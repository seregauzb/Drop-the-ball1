using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savat : MonoBehaviour
{
    public float pul=1f;
    public GameObject rasm;
    float p1=1;
    public AudioSource yutti,yutqazdi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){
        if(other.collider.tag=="Player"){
            if(other.gameObject.GetComponent<shar>().otildi==false){
                if(pul>1){
                    Destroy(Instantiate(yutti,transform.position,transform.rotation),5);
                }else{
                    Destroy(Instantiate(yutqazdi,transform.position,transform.rotation),5);
                }
            p1=(float)(other.gameObject.GetComponent<shar>().tikilganpul);
            other.gameObject.GetComponent<shar>().pul+=(int)(p1*pul*other.gameObject.GetComponent<shar>().koef);
            other.gameObject.GetComponent<shar>().tur=true;
            other.gameObject.GetComponent<shar>().foizi=pul*other.gameObject.GetComponent<shar>().koef;
            rasm.SetActive(false);
            rasm.SetActive(true);
            other.transform.position=other.gameObject.GetComponent<shar>().bosh;
            other.gameObject.GetComponent<shar>().tiktek();
            other.gameObject.GetComponent<shar>().otildi=true;
            other.gameObject.GetComponent<shar>().tashlandi=false;
            }
        }
    }
}
