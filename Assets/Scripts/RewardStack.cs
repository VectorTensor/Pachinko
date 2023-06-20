using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RewardStack : MonoBehaviour
{

    public static RewardStack instance;

    private int CoinCount=0;
    private int GemCount=0;
    private int OutfitCount=0;

    public Dictionary<PrizeTypes,int> PrizeCount;

    public Dictionary<PrizeTypes,GameObject> PrizeReference;
        void Awake()
        {
            if(instance == null)
                instance = this;
        }

        public static RewardStack GetInstance()
        {
            return instance;
        }


    // Start is called before the first frame update
    void Start()
    {
//        PrizeCount = new Dictionary<PrizeItem, int>();
    }

   

    void OnDisable(){

    }

    public void UpdateList(PrizeType pt){
       // Debug.Log(RewardList.Count);
        if (pt.type.prizetype == PrizeTypes.COIN){
            CoinCount += pt.value; 
        }

        else if (pt.type.prizetype == PrizeTypes.GEMS){
            GemCount += pt.value; 
        }

        else if (pt.type.prizetype == PrizeTypes.OUTFITSKIN){
            OutfitCount += pt.value; 
        }

        // Debug.Log(CoinCount);
        // Debug.Log(GemCount);
        // Debug.Log(OutfitCount);

        PrizeCount[PrizeTypes.COIN] = CoinCount;
        PrizeCount[PrizeTypes.GEMS] = GemCount;
        PrizeCount[PrizeTypes.OUTFITSKIN] = OutfitCount;
        PrizeReference[PrizeTypes.COIN].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = CoinCount.ToString();
        PrizeReference[PrizeTypes.GEMS].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = GemCount.ToString();
        PrizeReference[PrizeTypes.OUTFITSKIN].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = OutfitCount.ToString();
        
        
        Debug.Log(PrizeCount[PrizeTypes.COIN]);
        Debug.Log(PrizeCount[PrizeTypes.GEMS]);
        Debug.Log(PrizeCount[PrizeTypes.OUTFITSKIN]);
    }

    // public void UpdateListV2(PrizeType pt){
    //     foreach (var key in PrizeCount.Keys ){
    //         if (key == pt.type.prizetype){
    //             PrizeCount[key] += pt.value;
    //         }
    //     }

       

    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
