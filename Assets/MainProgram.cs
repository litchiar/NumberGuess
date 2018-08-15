using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainProgram : MonoBehaviour {
	public bool success = false;                       //是否猜对
	public const int GuessTimes = 8;                   //最多可猜测次数
	public int i = 0;                                  //当前猜测次数
	public int userNumber = 0;                         //当前用户输入数字
	public int[] gameLog;                              //当前反馈值
	public int randomNumber ;             //当前随机数
	public string temp = "";
	public string[] numbers = new string[GuessTimes];  //用户猜测数字
	public string[] logs = new string[GuessTimes];     //反馈值
	// Use this for initialization
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public bool isValid = false;
	void Start () {
		randomNumber = CreateNumber ();
	}

	// Update is called once per frame
	void Update () {
		userNumber = 1000 * int.Parse (text1.text) + 100 * int.Parse (text2.text) + 10 * int.Parse (text3.text) + 1 * int.Parse (text4.text);
		//Debug.Log (userNumber + "");
		if (IsUseful (userNumber)) 
		{
			isValid = true;

		} 
		else 
		{
			isValid = false;
		}
			
	}
	void FixUpdate()
	{
		
	}
	public int CreateNumber()
	{
		Random random = new Random();//新建Random类
		int randomNumber = 0;

		while (true)
		{
			randomNumber = Random.Range(1000,9876);//Random.Next(MaxValue)-返回一个小于所指定最大值的非负随机数
			if (IsUseful(randomNumber)) break;//检查是否有重复数字
		}
		return randomNumber;//生成随机数
	}
	public bool IsUseful(int number)
	{
		bool flag = false;
		if (number >= 9999 || number < 1000) {
			return flag;
		}
		int[] numbers = GetNumbers(number);
		if (numbers[0] != numbers[1] && numbers[0] != numbers[2] && numbers[0] != numbers[3] &&
			numbers[1] != numbers[2] && numbers[1] != numbers[3] && numbers[2] != numbers[3])
			flag = true;

		return flag;
	}
	public int[] GetNumbers(int number)
	{
		int[] numbers = new int[4];
		numbers[0] = number / 1000;//千位
		numbers[1] = (number % 1000) / 100;//百位
		numbers[2] = (number % 1000 % 100) / 10;//十位
		numbers[3] = number % 10;//个位
		int temNumber=1000*numbers[0]+100*numbers[1]+10*numbers[2]+numbers[3];
		return numbers;
	}

}
