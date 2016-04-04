using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class title : MonoBehaviour 
{
	public Text titleText;
	public Text clickText;
	public GameObject titleBox;

	// Use this for initialization
	void Start () 
	{
		titleText.text = "Tic Tac Toe!";
		clickText.text = "Click anywhere to begin.";
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			titleText.text = "";
			clickText.text = "";
			titleBox.SetActive (false);
		}
	}
}
