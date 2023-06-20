using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{

    [SerializeField] Button button; 
    [SerializeField] GameObject PanelReference;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ShowPanel);
        
    }


    void ShowPanel(){

        transform.DOMove(PanelReference.transform.position,0.2f);
        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(HidePanel);
    }

    void HidePanel(){

        transform.Translate(150,0, 0 );
        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(ShowPanel);

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
