using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectReferences : MonoBehaviour
{
    [SerializeField]public Image Coin;
    [SerializeField] public  Image OutfitSkin;
    
    [SerializeField]public  Image Gems;

    [SerializeField] public GameObject Pins;

    [SerializeField] public GameObject Compartments;
    
    [SerializeField] public GameObject ScoreObjects;

    [SerializeField] public GameObject ItemsRef1;
    [SerializeField] public GameObject ItemsRef2;

    [SerializeField] public GameObject ItemPrizePrefab;

    [SerializeField] public GameObject ItemCollection;


    

    public static ObjectReferences instance;

     void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public static ObjectReferences GetInstance()
    {
        return instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
