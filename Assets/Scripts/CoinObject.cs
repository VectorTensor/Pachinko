using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoinObject : MonoBehaviour
{
    // Start is called before the first frame update

    public static event Action<GameObject> onScoreHit;
    public static event Action onNegScoreHit;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void  OnCollisionEnter( Collision col ){
        GameObject gm = col.gameObject;
        if (gm.tag.Equals("Score")){

            onScoreHit?.Invoke(gm);



        }

        else if (gm.tag.Equals("NegScore")){

            onNegScoreHit?.Invoke();

        }else if(gm.tag.Equals("Pins")){
            Vector3 force = transform.position  - gm.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force *500);
        }



    }
}
