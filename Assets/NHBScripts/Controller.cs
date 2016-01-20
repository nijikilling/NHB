using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    // Use this for initialization

    public float moveCoeff, rotateCoeff;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, moveCoeff * Time.deltaTime));
        if (Input.GetKey(KeyCode.S))
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, -moveCoeff * Time.deltaTime));
        if (Input.GetKey(KeyCode.A))
            gameObject.GetComponent<Rigidbody2D>().AddTorque(rotateCoeff * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            gameObject.GetComponent<Rigidbody2D>().AddTorque(-rotateCoeff * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            gameObject.GetComponent<Existance>().hp--;
    }
}
