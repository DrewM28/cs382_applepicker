using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float     bottomY = -20f;
    private ScoreCounter scoreCounter;

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject );

            //Get a reference to the apple picker component of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Call the public AppleMissed() method of script
            apScript.AppleMissed();
        }
    }

    public void OnCatch() {
        if ( CompareTag( "RottenApple" )) {
  
        }
    }
}
