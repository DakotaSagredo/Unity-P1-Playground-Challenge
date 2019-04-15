using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerP1 : MonoBehaviour {

	public static int minuteCount;
	public static int secondCount;
	public static float milliCount;
	public static string milliDisplay;

	public GameObject minuteBox;
	public GameObject secondBox;
	public GameObject milliBox;

	
	// Update is called once per frame
	void Update () {
		milliCount += Time.deltaTime * 10; // Time.deltaTime measured in 10th of millisecond
		milliDisplay = milliCount.ToString("F0"); // Converted number to string to display to game screen
		milliBox.GetComponent<Text> ().text = "" + milliDisplay; // Displays Milliseconds to game screen

		if (milliCount >= 9) { // Reset the millisecond timer once it reaches 9
			milliCount = 0;
			secondCount += 1;
		}
		if (secondCount <= 9) { // Display seconds to game screen, as well as decimal point
			secondBox.GetComponent<Text> ().text = "0" + secondCount + ".";
		} else { // If it's greater than 9, it won't display a zero
			secondBox.GetComponent<Text> ().text = "" + secondCount + ".";
		}
		if (secondCount > 59) { // Reset the second timer once it reaches 59
			secondCount = 0;
			minuteCount += 1;
		}
		if (minuteCount <= 9) { // Display minutes to game screen, as well as decimal point
			minuteBox.GetComponent<Text> ().text = "0" + minuteCount + ":";
		} else { // If it's greater than 9, it won't display a zero
			minuteBox.GetComponent<Text> ().text = "" + minuteCount + ".";
		}
	}
}
