using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class gameplay : MonoBehaviour 
{
	int boardSize = 9;
	int[] spots;
	bool done;
	bool start;

	public Sprite blankSpot;
	public Sprite xSpot;
	public Sprite oSpot;
	public GameObject[] spotImages;

	public GameObject playerWin;
	public GameObject catsGame;
	public GameObject playAgainButton;
	public GameObject exitButton;
	public GameObject title;
	public Text playerText;
	public Text playAgainText;
	public Text exitText;

	void Start () 
	{
		spots = new int[boardSize];
		for (int i = 0; i < boardSize; i++)
		{
			spots[i] = 0;
		}

		for (int i = 0; i < boardSize; i++) 
		{
			spotImages[i].name = "blank";
		}

		done = false;
		start = false; 

		playAgainButton.SetActive (false);
		exitButton.SetActive (false);
		catsGame.SetActive (false);
		playerWin.SetActive (false);

		playAgainText.text = "";
		exitText.text = "";
		playerText.text = "";
	}

	int check()
	{
		int spotsPlaced = 0;
		
		for (int i = 0; i < boardSize; i++)
		{
			if (spotImages[i].GetComponent<SpriteRenderer>().sprite == xSpot)
			{
				spotsPlaced += 1;
				spots[i] = 2;
				spotImages[i].name = "NOTBLANK";
			}

			else if (spotImages[i].GetComponent<SpriteRenderer>().sprite == oSpot)
			{
				spotsPlaced += 1;
				spots[i] = 1;
				spotImages[i].name = "NOTBLANK";
			}
		}
		
		if (spotsPlaced == 9) 
		{
			done = true;
			end (0);
		}
		
		return spotsPlaced;
	}

	void OnMouseDown()
	{
		int spotNum = Int32.Parse (this.tag);

		if (this.name == "blank" && !done && start) 
		{
			if (check () % 2 == 0) 
			{
				this.GetComponent<SpriteRenderer> ().sprite = oSpot;
				spots[spotNum - 1] = 1;
				this.name = "NOTBLANK";
				checkForWin (spotNum, 1);
			} 
			
			else 
			{
				this.GetComponent<SpriteRenderer> ().sprite = xSpot;
				spots[spotNum - 1] = 2;
				this.name = "NOTBLANK";
				checkForWin (spotNum, 2);
			}
		}
	}

	void checkForWin(int spot, int numPlayer)
	{
		// BOARD
		// 1 2 3
		// 4 5 6
		// 7 8 9

		if (spot == 1) 
		{
			// wins
			// 1 2 3
			// 1 4 7
			// 1 5 9
			if (spots[0] == numPlayer &&
			    spots[1] == numPlayer &&
			    spots[2] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}

			else if (spots[0] == numPlayer &&
			         spots[3] == numPlayer &&
			         spots[6] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}

			else if (spots[0] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		} 

		else if (spot == 2)
		{
			// wins
			// 1 2 3
			// 2 5 8

			if (spots[0] == numPlayer &&
			    spots[1] == numPlayer &&
			    spots[2] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[1] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[7] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else if (spot == 3)
		{
			// wins
			// 1 2 3
			// 3 6 9
			// 7 5 3

			if (spots[0] == numPlayer &&
			    spots[1] == numPlayer &&
			    spots[2] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[2] == numPlayer &&
			         spots[5] == numPlayer &&
			         spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[6] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[2] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}  

		else if (spot == 4)
		{
			// wins
			// 1 4 7
			// 4 5 6

			if (spots[0] == numPlayer &&
			    spots[3] == numPlayer &&
			    spots[6] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[3] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[5] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else if (spot == 5)
		{
			// wins
			// 1 5 9
			// 3 5 7
			// 2 5 8
			// 4 5 6

			if (spots[0] == numPlayer &&
			    spots[4] == numPlayer &&
			    spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[2] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[6] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[1] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[7] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}

			else if (spots[3] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[5] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else if (spot == 6)
		{
			// wins
			// 3 6 9
			// 4 5 6

			if (spots[2] == numPlayer &&
			    spots[5] == numPlayer &&
			    spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[3] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[5] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else if (spot == 7)
		{
			// wins
			// 1 4 7
			// 7 8 9
			// 7 5 3

			if (spots[0] == numPlayer &&
			    spots[3] == numPlayer &&
			    spots[6] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[6] == numPlayer &&
			         spots[7] == numPlayer &&
			         spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[6] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[2] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else if (spot == 8)
		{
			// wins
			// 7 8 9
			// 2 5 8

			if (spots[6] == numPlayer &&
			    spots[7] == numPlayer &&
			    spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[1] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[7] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}

		else
		{
			// wins
			// 7 8 9
			// 3 6 9
			// 1 5 9

			if (spots[6] == numPlayer &&
			    spots[7] == numPlayer &&
			    spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[2] == numPlayer &&
			         spots[5] == numPlayer &&
			         spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
			
			else if (spots[0] == numPlayer &&
			         spots[4] == numPlayer &&
			         spots[8] == numPlayer)
			{
				done = true;
				end (numPlayer);
				return;
			}
		}
	}

	void end(int numPlayer)
	{
		if (numPlayer == 0) 
		{
			StartCoroutine(wait2 ());
		} 

		else 
		{
			StartCoroutine(wait1 (numPlayer));
		}
	}

	IEnumerator wait1(int numPlayer)
	{
		yield return new WaitForSeconds(0.75f);
		win (numPlayer);
	}

	IEnumerator wait2()
	{
		yield return new WaitForSeconds (0.75f);
		tie ();
	}

	void win(int playerNum)
	{
		for (int i = 0; i < boardSize; i++) 
		{
			spotImages[i].SetActive (false);
		}

		playerWin.SetActive (true);

		if (playerNum == 1) 
		{
			playerText.text = "Player ONE wins!";
		} 

		else 
		{
			playerText.text = "Player TWO wins!";
		}

		playAgainButton.SetActive (true);
		exitButton.SetActive (true);
		playAgainText.text = "Play again?";
		exitText.text = "Quit";
		playAgainText.rectTransform.position = playAgainButton.transform.position;
		exitText.rectTransform.position = exitButton.transform.position;
		playerText.rectTransform.position = playerWin.transform.position;
		playerText.rectTransform.Translate (Vector3.up * 0.6f); 
	}

	void tie()
	{
		for (int i = 0; i < boardSize; i++)
		{
			spotImages[i].SetActive(false);
		}

		catsGame.SetActive (true);
		playAgainButton.SetActive (true);
		exitButton.SetActive (true);
		playAgainText.text = "Play again?";
		exitText.text = "Quit";
		playAgainText.rectTransform.position = playAgainButton.transform.position;
		exitText.rectTransform.position = exitButton.transform.position;
	}

	void Update()
	{
		if (!title.activeSelf)
		{
			start = true;
		}

		check ();
	}
}
