using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehavior {
    public static float bottomY = -20f;




    void Update() {
        if ( transform.position.y < bottomY ) {
            Destroy( this.GameObject );


            //Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Call the public AppleMissed() method of apScript
            apScript.AppleMissed();
        }
    }
}