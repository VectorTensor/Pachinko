using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{

    [SerializeField] Material WinMaterial;
    [SerializeField] Material LoseMaterial;

    [SerializeField] GameObject ScorePanelReference;  

    [SerializeField] GameObject OkButton; 
    
    [SerializeField] Material DefaultMaterial;

    [SerializeField] GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable(){
        CoinObject.onScoreHit += ShowWinPanel;
        CoinObject.onNegScoreHit += ShowLosePanel;
    }
    
    void OnDisable(){
        CoinObject.onScoreHit -= ShowWinPanel;
        CoinObject.onNegScoreHit -= ShowLosePanel;
    }

    void ShowWinPanel(GameObject gm){
        // Translate code and change the material
        OkButton.GetComponent<Button>().onClick.AddListener(TranslateUpward);

        gameObject.GetComponent<Image>().material = WinMaterial;
        TranslateScorePanel();
        



    }

    void TranslateScorePanel(){
        transform.DOMove(ScorePanelReference.transform.position,0.5f);
    }


    void TranslateUpward(){
        Background.GetComponent<Image>().material = DefaultMaterial;
        transform.Translate(0,200, 0 );
    }

    void ShowLosePanel(){
        // Translate code and change the material
        OkButton.GetComponent<Button>().onClick.AddListener(TranslateUpward);

        gameObject.GetComponent<Image>().material = LoseMaterial;
        TranslateScorePanel();

    }
}
