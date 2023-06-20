using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class PositionPins : MonoBehaviour
{

    [SerializeField] GameObject ref1;
    [SerializeField] GameObject ref2;

    [SerializeField] GameObject pin;
    [SerializeField] GameObject ball;
    [SerializeField] int row=8;
    [SerializeField] int column=8;

    [SerializeField] GameObject BallRef1;
    [SerializeField] GameObject BallRef2;

    [SerializeField] GameObject Compartment;
    [SerializeField] GameObject CompartmentRef;

    [SerializeField] public  GameObject ClampPos1;
    [SerializeField] public GameObject ClampPos2;

    [SerializeField] GameObject ScoreObject;


    [SerializeField] GameObject Canvas;
    private  GameObject CoinInstant;
    int increment_x = 6;
    int increment_y = 6;
    
    public static Dictionary<GameObject, PrizeType> gameObjectDictionary;
    List<PrizeType> Prizes;



    // Start is called before the first frame update
    void Start()
    {
        gameObjectDictionary = new Dictionary<GameObject,PrizeType>();
        Prizes = new List<PrizeType>();
        AddPrizes();
        PositionPinsMethod();
        InstantiateCompartments();
    
        InstantiateScores();
       // DropTheCoinMethod();
        InstantTheCoinMethod();
        DestroyTheCoin();
        
       // Debug.Log(gameObjectDictionary.Count);
    }

    GameObject InstantiatePrizeItem(Image image,Vector3 pos){
        GameObject gm;
        gm = Instantiate(ObjectReferences.GetInstance().ItemPrizePrefab,pos, Quaternion.identity);
        gm.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = image.sprite;
        gm.transform.GetChild(0).gameObject.GetComponent<Image>().color = image.color;
        gm.transform.SetParent(ObjectReferences.GetInstance().ItemCollection.transform);
        gm.transform.localScale = new Vector3(0.6f,0.4f,0.4f);
        return gm;

    }

// Need to refactor it later so it can work on a loop
    void AddPrizes(){

        PrizeItem CoinType = new PrizeItem(ObjectReferences.GetInstance().Coin,PrizeTypes.COIN);
        PrizeItem GemsType = new PrizeItem(ObjectReferences.GetInstance().Gems,PrizeTypes.GEMS);
        PrizeItem OutfitType = new PrizeItem(ObjectReferences.GetInstance().OutfitSkin,PrizeTypes.OUTFITSKIN);

        RewardStack.GetInstance().PrizeCount = new Dictionary<PrizeTypes, int>();
        RewardStack.GetInstance().PrizeCount.Add(CoinType.prizetype,0);
        RewardStack.GetInstance().PrizeCount.Add(GemsType.prizetype,0);
        RewardStack.GetInstance().PrizeCount.Add(OutfitType.prizetype,0);

        RewardStack.GetInstance().PrizeReference = new Dictionary<PrizeTypes,GameObject>();
        Vector3 PrizePosition = ObjectReferences.GetInstance().ItemsRef1.transform.position;
        GameObject gm = InstantiatePrizeItem(CoinType.image,PrizePosition);
        RewardStack.GetInstance().PrizeReference.Add(CoinType.prizetype, gm);
        PrizePosition.y -= 6;
        gm= InstantiatePrizeItem(GemsType.image,PrizePosition);
        RewardStack.GetInstance().PrizeReference.Add(GemsType.prizetype, gm);
        PrizePosition.y -= 6;
        gm= InstantiatePrizeItem(OutfitType.image,PrizePosition);
        RewardStack.GetInstance().PrizeReference.Add(OutfitType.prizetype, gm);

        Prizes.Add(new PrizeType(CoinType, 50));
        Prizes.Add(new PrizeType(CoinType, 500));
        Prizes.Add(new PrizeType(GemsType, 10));
        Prizes.Add(new PrizeType(GemsType, 20));
        Prizes.Add(new PrizeType(OutfitType, 1));
        // Add the prize in sequence
        


                
    }

    

    // void PositionPinsMethodRandom(){

    //       for (int i = 0; i < 50; i++)
    //     {

    //         Vector3 pos = GenerateRandomVector3(ref1.transform.position.x, ref2.transform.position.x, ref2.transform.position.y, ref1.transform.position.y, ref1.transform.position.z );
    //         Instantiate(pin, pos, pin.transform.rotation);

    //     }
    // }

    void PositionPinsMethod(){

        float start_x = ref1.transform.position.y; 
        float start_y = ref1.transform.position.x;
        float temp = start_y;
        
        
        for (int i = 0; i < column; i++)
        {

            if (i % 2 != 0) // Check if start_x is odd
            {
                start_y = start_y - (increment_y/2);

               
            }
            
            for (int j = 0; j < row; j++)
            {
                Vector3 pos = new Vector3(start_y,start_x, ref1.transform.position.z);
                GameObject gm =  Instantiate(pin, pos, pin.transform.rotation);
                gm.transform.parent =  ObjectReferences.GetInstance().Pins.transform;

                start_y -= increment_y;
            }

            start_x -= increment_x;
            start_y = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InstantiateCompartments(){
        Vector3 pos = CompartmentRef.transform.position;
        for (int i=0 ; i<6;i++){
            GameObject gm =  Instantiate(Compartment, pos , Quaternion.identity);
            gm.transform.parent =  ObjectReferences.GetInstance().Compartments.transform;
            pos.x -= increment_y;
        }

        

    }
    public void InstantiateScores(){
        Vector3 pos = CompartmentRef.transform.position;
        pos.x -= increment_y/2;
        pos.y -= 2;
        for (int i=0 ; i<5;i++){

            GameObject gm =  Instantiate(ScoreObject, pos , Quaternion.identity);
            pos.x -= increment_y;
            gm.transform.parent =  ObjectReferences.GetInstance().ScoreObjects.transform;
            gameObjectDictionary.Add(gm,Prizes[i]);
            GameObject gm_c = Instantiate(Prizes[i].type.image.gameObject);
            gm_c.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Prizes[i].value.ToString();
            gm_c.transform.SetParent(Canvas.transform); 
            Vector3 newPosition = gm.transform.position;
            newPosition.z += 10;
            newPosition.y -= 3;
            gm_c.transform.position = newPosition;
            
            gm_c.transform.localScale = new Vector3(0.6f,0.4f,0.4f);


        }

        

    }

    // public Vector3 GenerateRandomVector3(float minX, float maxX, float minY, float maxY, float Z)
    // {
    //     float randomX = Random.Range(minX, maxX);
    //     float randomY = Random.Range(minY, maxY);
    //     float randomZ = Z;

    //     return new Vector3(randomX, randomY, randomZ);
    // }
    // public Vector3 BallPositionVector3(float minX, float maxX, float constantY, float constantZ)
    // {
    //     float randomX = Random.Range(minX, maxX);

    //     return new Vector3(randomX, constantY, constantZ);
    // }
    // void DropTheCoinMethod(){
        
    //     Vector3 ballPos = BallPositionVector3(BallRef1.transform.position.x, BallRef2.transform.position.x,BallRef1.transform.position.y,BallRef1.transform.position.z );
    //     GameObject gm = Instantiate( ball, ballPos, Quaternion.identity );
    //     CoinInstant = gm;
    //    // DropTheCoinMethodManual();
    // }
    

    void InstantTheCoinMethod(){
        GameObject gm = Instantiate( ball );
        CoinInstant = gm;
    }

     void DropTheCoinMethodManual(){
       
        DOTween.Kill(24);
        CoinInstant.GetComponent<ClampPosition>().Movedown();

    }   

    void OnEnable(){
        Drop.DropClicked += DropTheCoinMethodManual;
        CoinObject.onScoreHit += DestroyTheCoin;
        CoinObject.onNegScoreHit += DestroyTheCoin;
    }

    void DestroyTheCoin(GameObject gm){
        Drop.Dropped = false;
        CoinInstant.transform.position = (BallRef1.transform.position);
        CoinInstant.transform.DOMove(BallRef2.transform.position,2).SetLoops(-1,LoopType.Yoyo).SetId(24);
    }

    void DestroyTheCoin(){
        Drop.Dropped = false;
        CoinInstant.transform.position = (BallRef1.transform.position);
        CoinInstant.transform.DOMove(BallRef2.transform.position,2).SetLoops(-1,LoopType.Yoyo).SetId(24);

    }

    void OnDisable(){
        Drop.DropClicked -= DropTheCoinMethodManual;

    }

}


    public class PrizeType{

        public PrizeItem type; 
        public int value;

        public PrizeType(PrizeItem t, int v){
            type = new PrizeItem(t.image, t.prizetype);

            value = v;
        }

    };

    public enum PrizeTypes{
        COIN,
        GEMS,
        OUTFITSKIN
    }
    public class PrizeItem{
        public Image image;

        public PrizeTypes prizetype;

        public PrizeItem(Image i, PrizeTypes p){
            
            image = i ; 
            prizetype = p ; 


        }
        
    };