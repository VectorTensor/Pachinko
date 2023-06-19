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
    [SerializeField] Material GojoMaterial;
    [SerializeField] Material SukunaMaterial;


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
        int x = PositionPins.gameObjectDictionary[gm];
        gameObject.GetComponent<TextMeshProUGUI>().text = x.ToString();
        Board.GetComponent<Image>().material = GojoMaterial;
      //  Debug.Log(x);
    }


    void NegScore(){
        int x = -10;
        gameObject.GetComponent<TextMeshProUGUI>().text = x.ToString();
        Board.GetComponent<Image>().material = SukunaMaterial;

      //  Debug.Log(x);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
