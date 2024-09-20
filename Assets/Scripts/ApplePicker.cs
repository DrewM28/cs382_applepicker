using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("UI Elements")]
    public Text roundTxt;
    private int currentRound = 1; //Starts on round 1



    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for ( int i = 0; i < numBaskets; i++ ) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }

        UpdateRoundTxt();
    }

    public void AppleMissed() {
        //Destory all of the falling apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tempGO in appleArray ) {
            if ( tempGO.CompareTag("Apple")) {
                Destroy ( tempGO.CompareTag("Apple") );
            }
        }

        if ( appleArray.Length > 0 ) {
            //Destroy one of the baskets
            //Get the index of the last Basket in basketList
            int basketIndex = basketList.Count - 1;
            //Get a reference to that basket GameObject
            GameObject basketGO = basketList[basketIndex];
            //Remove the basket from the list and destroy this gameobject
            basketList.RemoveAt( basketIndex );
            Destroy( basketGO );
        }

        UpdateRound();

        //If there are no baskets left, restart the game
        if ( basketList.Count == 0 ) {
            SceneManager.LoadScene( "_Scene_0" );
        }

    }

    void UpdateRound() {

        currentRound = numBaskets - basketList.Count + 1;
        UpdateRoundTxt();

    }

    void UpdateRoundTxt() {
        roundTxt.text = "Round " + currentRound;
    }

    void Update() {

    }

 
}
