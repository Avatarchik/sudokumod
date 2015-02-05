using UnityEngine;
using System.Collections;

public class MoveMove : MonoBehaviour {

	public int posIndex = 0;	
	public ArrayList positions = new ArrayList();
	
	// Use this for initialization
	void Start () {
		positions.Add (new Vector3(-4, 10, 0));
		positions.Add (new Vector3((float)0.7, 10, 0));
		positions.Add (new Vector3((float)5.4, 10, 0));
		positions.Add (new Vector3((float)10.2, (float)5.3, 0));
		positions.Add (new Vector3((float)10.2, (float)0.6, 0));
		positions.Add (new Vector3((float)10.2, (float)-4.1, 0));
		positions.Add (new Vector3((float)5.4, -9, 0));
		positions.Add (new Vector3((float)0.7, -9, 0));
		positions.Add (new Vector3(-4, -9, 0));
		positions.Add (new Vector3((float)-8.8, (float)-4.1, 0));
		positions.Add (new Vector3((float)-8.8, (float)0.6, 0));
		positions.Add (new Vector3((float)-8.8, (float)5.3, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (!IsInvoking ("move")) {Invoke("move", 1);}
	}

	void move () {
		print("move move");
		if (posIndex < positions.Count-1) { posIndex += 1;}
		else{ posIndex = 0;}
		this.transform.position = (Vector3)positions[posIndex];
		}
}
