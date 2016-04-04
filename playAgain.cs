using UnityEngine;
using System.Collections;

public class playAgain : MonoBehaviour {

	void OnMouseDown()
	{
		Debug.Log ("click");
		Application.LoadLevel (0);
	}
}
