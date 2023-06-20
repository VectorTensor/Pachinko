using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreCard : MonoBehaviour
{

    private AudioSource Source;
    public AudioClip Clip;

    [SerializeField] GameObject Board ;
    [SerializeField] Material GiyuMaterial;
    [SerializeField] Material SanameiMaterial;
    [SerializeField] Material ShinobuMaterial;

    [SerializeField] GameObject IconImage;


    // Start is called before the first frame update
    void Start()
    {
      Source = GetComponent<AudioSource>();
        
    }
    void OnEnable(){
        CoinObject.onScoreHit += ChangeScore;
        CoinObject.onScoreHit += PlayTheSound;
        CoinObject.onNegScoreHit += NegScore;
    

    }

    void OnDisable(){
        CoinObject.onScoreHit -= ChangeScore;
        CoinObject.onNegScoreHit -= NegScore;
        CoinObject.onScoreHit -= PlayTheSound;


    }

    void PlayTheSound(GameObject gm){
      //Source.PlayOneShot(Clip);
    }

    void ChangeScore(GameObject gm){
        int x = PositionPins.gameObjectDictionary[gm].value;
        gameObject.GetComponent<TextMeshProUGUI>().text ="You got \n" + x.ToString();
        IconImage.SetActive(true);
        IconImage.GetComponent<Image>().color= PositionPins.gameObjectDictionary[gm].type.image.color; // change sprite or color
        IconImage.GetComponent<Image>().sprite= PositionPins.gameObjectDictionary[gm].type.image.sprite; // change sprite or color

        RewardStack.GetInstance().UpdateList(PositionPins.gameObjectDictionary[gm]);
        
        if (PositionPins.gameObjectDictionary[gm].type.prizetype == PrizeTypes.GEMS){
          Board.GetComponent<Image>().material = GiyuMaterial;

        }
        else{
          Board.GetComponent<Image>().material = ShinobuMaterial;

        }
      //  Debug.Log(x);
    }


    void NegScore(){
        //int x = -10;
        IconImage.SetActive(false);

        gameObject.GetComponent<TextMeshProUGUI>().text ="Sorry you got nothing ";
        Board.GetComponent<Image>().material = SanameiMaterial;

      //  Debug.Log(x);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
