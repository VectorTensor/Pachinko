using System.Dynamic;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    private  GameObject CoinInstant;
    int increment_x = 6;
    int increment_y = 6;
    
    public static Dictionary<GameObject, PrizeType> gameObjectDictionary;
    List<PrizeType> Prizes;


    public class PrizeType{

        public string  type; 
        public int value;

        public PrizeType(string t, int v){
            type = t;
            value = v;
        }

    };

    // Start is called before the first frame update
    void Start()
    {
        gameObjectDictionary = new Dictionary<GameObject,PrizeType>();
        Prizes = new List<PrizeType>(){new PrizeType("normal", 1),new PrizeType("normal", 2),new PrizeType("normal", 5),new PrizeType("normal", 2),new PrizeType("normal", 1)};
        PositionPinsMethod();
        InstantiateCompartments();
        InstantiateScores();
       // DropTheCoinMethod();
        InstantTheCoinMethod();
        DestroyTheCoin();
        
       // Debug.Log(gameObjectDictionary.Count);
    }

    void PositionPinsMethodRandom(){

          for (int i = 0; i < 50; i++)
        {

            Vector3 pos = GenerateRandomVector3(ref1.transform.position.x, ref2.transform.position.x, ref2.transform.position.y, ref1.transform.position.y, ref1.transform.position.z );
            Instantiate(pin, pos, pin.transform.rotation);

        }
    }

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
                Instantiate(pin, pos, pin.transform.rotation);
                
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
            Instantiate(Compartment, pos , Quaternion.identity);
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
            gameObjectDictionary.Add(gm,Prizes[i]);

        }

        

    }

    public Vector3 GenerateRandomVector3(float minX, float maxX, float minY, float maxY, float Z)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Z;

        return new Vector3(randomX, randomY, randomZ);
    }
    public Vector3 BallPositionVector3(float minX, float maxX, float constantY, float constantZ)
    {
        float randomX = Random.Range(minX, maxX);

        return new Vector3(randomX, constantY, constantZ);
    }
    void DropTheCoinMethod(){
        
        Vector3 ballPos = BallPositionVector3(BallRef1.transform.position.x, BallRef2.transform.position.x,BallRef1.transform.position.y,BallRef1.transform.position.z );
        GameObject gm = Instantiate( ball, ballPos, Quaternion.identity );
        CoinInstant = gm;
       // DropTheCoinMethodManual();
    }
    

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
