using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLangLogin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (LoginDirector.language == 0)
			SetKorText();
		else
			SetEngText();
	}
	public void SetKor(bool isOn)
	{
		LoginDirector.language = 0;
		SetKorText();

	}
	public void SetEng(bool isOn)
	{
		LoginDirector.language = 1;
		SetEngText();
	}
	public static void SetContent(Text text, string str) { text.text = str; }
	void SetEngText()
	{
		SetContent(SetText.texts[4], "Login");
		SetContent(SetText.texts[5], "Login");
		SetContent(SetText.texts[6], "ID");
		SetContent(SetText.texts[7], "Password");
	}
	void SetKorText()
	{
		SetContent(SetText.texts[4], "�α���");
		SetContent(SetText.texts[5], "�α���");
		SetContent(SetText.texts[6], "���̵�");
		SetContent(SetText.texts[7], "��й�ȣ");
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
