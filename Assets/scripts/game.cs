using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class game : MonoBehaviour {

	public Text encrypedMessage;
	public InputField decryptionKey;
	public Button decryptButton;
	public Button navigateButton;
	public Text dectrypedMessage;
	public Canvas navigationSystem;

	public InputField xCord;
	public InputField yCord;

	// Use this for initialization
	void Start () {
		encrypedMessage = encrypedMessage.GetComponent<Text> ();
		decryptionKey = decryptionKey.GetComponent<InputField> ();
		decryptButton = decryptButton.GetComponent<Button> ();
		dectrypedMessage = dectrypedMessage.GetComponent<Text> ();
		navigationSystem = navigationSystem.GetComponent<Canvas> ();
		xCord = xCord.GetComponent<InputField> ();
		yCord = yCord.GetComponent<InputField> ();


		string encrypted = Caesar ("The secret Co-ordinates are 34.2341, 12.341", 3, "encryption");
		encrypedMessage.text = encrypted;
		navigationSystem.enabled = false;
		dectrypedMessage.enabled = false;
	
	}

	public void DecryptPress(){
		dectrypedMessage.enabled = true;
		dectrypedMessage.text = Caesar(encrypedMessage.text, Convert.ToInt32(decryptionKey.text), "decryption");
		if(Convert.ToInt32(decryptionKey.text) == -3 || Convert.ToInt32(decryptionKey.text) % 26 == 23 ){
			navigationSystem.enabled = true;
		}
	}

	public void NavigatePress(){
		if (xCord.text == "34.2341" && yCord.text == "12.341") {
			// Congrats xD 
		}
	}

	static string Caesar(string value, int shift, string action)
	{	
		int maxShiftLimit = 26;
		if (action == "decryption") {
			maxShiftLimit = 0;
		}
		while (shift >= maxShiftLimit) {
			shift -= 26;	
		}
		char[] buffer = value.ToCharArray();
		for (int i = 0; i < buffer.Length; i++)
		{
			// Letter.
			char letter = buffer[i];
			// Add shift to all.
			if (letter.ToString() != " "){
				letter = (char)(letter + shift);
			}
			// Store.
			buffer[i] = letter;
		}
		return new string(buffer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
