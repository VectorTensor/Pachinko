using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Movedown(){
      // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-3500,0)); 
      //gameObject.GetComponent<Rigidbody>().velocity =  new Vector3(0,-20,0);
    }
    // Update is called once per frame
    void Update()
    {
       // gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,-20,0); 
        float z=  Mathf.Clamp(transform.position.z,-22.9f, -22f);       
        //Debug.Log(transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, z);

        
    }

    void FixedUpdate(){ 

        if (Drop.Dropped) {
            gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,-15,0) * Time.deltaTime; 

        }

    }
}
