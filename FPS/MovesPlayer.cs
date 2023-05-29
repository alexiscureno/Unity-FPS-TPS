using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesPlayer : MonoBehaviour
{

	public float movementSpeed;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate(){
    	if(Input.GetKey ("w") && !Input.GetKey("s")){
    		transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
    	} else if (Input.GetKey ("w") && Input.GetKey (KeyCode.LeftShift)) {
    		transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
    	} else if (Input.GetKey("s")){
    		transform.position -= transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;
    	}

    	if(Input.GetKey ("a") && !Input.GetKey("d")) {
    		transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
    	} else if (Input.GetKey("d") && !Input.GetKey ("a")) {
    		transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
    	}
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown (KeyCode.Space)){
    		if(transform.position.y <= 1.05f) {
    			GetComponent<Rigidbody> ().AddForce (Vector3.up * 200);
    		}
    	}


        
    }
}
