using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehavior {
    
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the Apple Tree moves
    public float speed = 1f;

    //distance where Apple Tree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the Apple Tree will change directions
    public float changeDirChance = 0.1f;

    //Seconds beween Apples instantiations
    public float appleDropDelay = 1f;

    void Start() {

        //Start Dropping Apples
        Invoke( "DropApple", 2f);
        
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>( applePrefab );
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay );
    }

    void Update() {

        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if ( pos.x < -leftAndRightEdge ) {
            speed = Mathf.Abs( speed );     //move right
        } else if ( pos.x > leftAndRightEdge ) {
            speed = -Math.Abs( speed );     //move left
        //} else if ( Random.value < changeDirChance ) {
        //    speed *= -1;                    //change directions
        }

        if( transform.position.y < bottomY ) {
            Destroy( this.gameObject );
        }


    }

    void FixedUpdate() {
        //Random Direction changes are now time-based due to FixedUpdate()
        if ( Random.value < changeDirChance ) {
            speed *= -1;    //change directions
        }                    
    }
}