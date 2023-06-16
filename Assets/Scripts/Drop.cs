using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Drop : MonoBehaviour
{
    public static event Action DropClicked;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(DropTheCoin);
           
    }

    void OnEnable(){

        CoinObject.onScoreHit += ActivateButton;
        CoinObject.onNegScoreHit += ActivateButton;

    }

    void OnDisable(){

        CoinObject.onScoreHit -= ActivateButton;
        CoinObject.onNegScoreHit -= ActivateButton;

    }

    void ActivateButton(GameObject gm){

        gameObject.GetComponent<Button>().interactable = true;

    }

     void ActivateButton(){

        gameObject.GetComponent<Button>().interactable = true;

    }
    void DropTheCoin(){
        Debug.Log("Button clicked");
        gameObject.GetComponent<Button>().interactable = false;
        DropClicked?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
