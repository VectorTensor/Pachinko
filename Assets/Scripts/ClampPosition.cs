using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    GameObject Clamp1;
    GameObject Clamp2;
   // GameObject PositionPinObject;
    PositionPins positionPinsObject;
    // Start is called before the first frame update
    void Start()
    {
        
        //PositionPinObject = GameObject.FindAnyObjectByType<PositionPins>().gameObject;
        positionPinsObject = GameObject.FindAnyObjectByType<PositionPins>();
       // Debug.Log(positionPinsObject.ClampPos1);
       
    }

    // public void Movedown(){
    //   // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-3500,0)); 
    //   //gameObject.GetComponent<Rigidbody>().velocity =  new Vector3(0,-20,0);
    // }
    // Update is called once per frame
    void Update()
    {
       // gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,-20,0); 
        float z=  Mathf.Clamp(transform.position.z,positionPinsObject.ClampPos2.transform.position.z , positionPinsObject.ClampPos1.transform.position.z);       
        //Debug.Log(transform.position);
        float x=  Mathf.Clamp(transform.position.x,positionPinsObject.ClampPos2.transform.position.x, positionPinsObject.ClampPos1.transform.position.x);       

        transform.position = new Vector3(x, transform.position.y, z);

        
    }

    void FixedUpdate(){ 

        if (Drop.Dropped) {
            gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0,-15,0) * Time.deltaTime; 

        }

    }
}
