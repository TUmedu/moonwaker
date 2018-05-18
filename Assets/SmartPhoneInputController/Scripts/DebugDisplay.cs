using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour {

    private Text targetText;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		string msg = "";
		if (SmartPhoneInput.IsConnected()) {
			msg += "Connected, ";
			//msg += "(" + SmartPhoneInput.PadX + "," + SmartPhoneInput.PadY + ")";
			//msg += "(" + SmartPhoneInput.PadGradX + "," + SmartPhoneInput.PadGradY + "," + SmartPhoneInput.PadGradZ + ")";
		} else {
			msg += "Disconnected: Please Access " + SmartPhoneController.WebUrl;
		}
         //GetComponent<GUIText>().text = msg;//old
         
        this.targetText = this.GetComponent<Text>();
        targetText.text = msg;
    }
}
