using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitFunction : MonoBehaviour {
	public int subNumber;
	public int correctNumber;
	public MainProgram mp;
	public bool isValid;
	public Button but;
	public Text textA;
	public Text textB;
[SerializeField]
	public Text OutMessage;
	// Use this for initialization
	void Start () {
		correctNumber = mp.randomNumber;
		but.onClick.AddListener (Check);
	}
	int[] GetGameLog(int randomNumber, int userNumber)
	{
		int[] gameLog = new int[2];
		int[] randomNumbers = mp.GetNumbers(randomNumber);
		int[] userNumbers = mp.GetNumbers(userNumber);

		for (int i = 0; i < randomNumbers.Length; i++)
			for (int j = 0; j < userNumbers.Length; j++)
			{
				if (randomNumbers[i] == userNumbers[j])
				{
					gameLog[1]++;

					if (i == j)
					{
						gameLog[0]++;
						gameLog[1]--;
					}
				}
			}

		return gameLog;
	}
	// Update is called once per frame
	void Update () {
		
	}
	void Check()
	{
		subNumber = mp.userNumber;
		isValid = mp.isValid;
		Debug.Log ("ok");
		if (isValid) {
			//Debug.Log ("haha");

			mp.gameLog = GetGameLog (mp.randomNumber, subNumber);
			OutMessage.text += mp.gameLog[0] + "A" + mp.gameLog[1] + "B"+"\n";
			Debug.Log (mp.gameLog [0] + "A" + mp.gameLog [1] + "B");
			textA.text =mp.gameLog [0].ToString();
			textB.text =mp.gameLog [1].ToString();
			if (mp.randomNumber == subNumber) {
				mp.success = true;
				OutMessage.text += "恭喜";
				Debug.Log ("恭喜");
			}
		}
	}


}
