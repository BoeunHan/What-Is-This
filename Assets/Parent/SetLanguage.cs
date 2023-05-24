using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage : MonoBehaviour
{
    //public static int language = 0;
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

    void SetEngText()
    {
        SetTextContent(SetText.texts[0], "ParentHome");
        SetTextContent(SetText.texts[3], UserInfo.GetcntWord().ToString() + " words");
        SetTextContent(SetText.texts[4], "learned words");
        SetTextContent(SetText.texts[5], "child level");
        SetTextContent(SetText.texts[6], "Learning Analysis");
        SetTextContent(SetText.texts[9], "Reward Settings");
        SetTextContent(SetText.texts[10], "Period");
        SetTextContent(SetText.texts[11], "Name");
        SetTextContent(SetText.texts[12], "Please enter prize");
		SetTextContent(SetText.texts[14], "Please enter period");
		SetTextContent(SetText.texts[16], "Save");
        SetTextContent(SetText.texts[17], "Language Setting");
        SetTextContent(SetText.texts[18], "Korean");
        SetTextContent(SetText.texts[19], "English");
    }
	void SetKorText()
	{
		SetTextContent(SetText.texts[0], "�θ�Ȩ");
		SetTextContent(SetText.texts[3], UserInfo.GetcntWord().ToString() + " ��");
		SetTextContent(SetText.texts[4], "���ñ��� �н��� �ܾ�");
		SetTextContent(SetText.texts[5], "���� ���� ����");
		SetTextContent(SetText.texts[6], "�н� ���");
		SetTextContent(SetText.texts[9], "���� ����");
		SetTextContent(SetText.texts[10], "��ǰ���� �ֱ�");
		SetTextContent(SetText.texts[11], "��ǰ �̸�");
		SetTextContent(SetText.texts[12], "��ǰ�� �Է����ּ���.");
		SetTextContent(SetText.texts[14], "��ǰ�����ֱ⸦ �Է����ּ���.");
		SetTextContent(SetText.texts[16], "�����ϱ�");
		SetTextContent(SetText.texts[17], "��� ����");
		SetTextContent(SetText.texts[18], "�ѱ���");
		SetTextContent(SetText.texts[19], "����");
	}


	public static void SetTextContent(Text text, string str) { text.text = str; }
}
