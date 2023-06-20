using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class Drop : MonoBehaviour
{
  //  public static event Action DropClicked;

    public GameObject PositionPinObject;
    public static bool Dropped;
    // Start is called before the first frame update
    void Start()


    
    {
        Dropped = false;
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
        Dropped = true;
        gameObject.GetComponent<Button>().interactable = false;
        //DropClicked?.Invoke();
        DOTween.Kill(24);
       // PositionPinObject.AddComponent<PositionPins>().DropTheCoinMethodManual();

        //Time.timeScale =0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
