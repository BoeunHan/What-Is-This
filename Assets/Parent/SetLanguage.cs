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
        SetTextContent(SetText.texts[2], "Back to HomeScene");
        SetTextContent(SetText.texts[4], UserInfo.GetcntWord().ToString() + " words");
        SetTextContent(SetText.texts[5], "learned words");
        SetTextContent(SetText.texts[6], "child level");
        SetTextContent(SetText.texts[7], "Learning Analysis");
        SetTextContent(SetText.texts[10], "Reward Settings");
        SetTextContent(SetText.texts[11], "Period");
        SetTextContent(SetText.texts[12], "Name");
        SetTextContent(SetText.texts[13], "Please enter prize");
		SetTextContent(SetText.texts[15], "Please enter period");
		SetTextContent(SetText.texts[17], "Save");
        SetTextContent(SetText.texts[18], "Language Setting");
        SetTextContent(SetText.texts[19], "Korean");
        SetTextContent(SetText.texts[20], "English");
    }
	void SetKorText()
	{
		SetTextContent(SetText.texts[0], "�θ�Ȩ");
		SetTextContent(SetText.texts[2], "�н�ȭ������ ���ư���");
		SetTextContent(SetText.texts[4], UserInfo.GetcntWord().ToString() + " ��");
		SetTextContent(SetText.texts[5], "���ñ��� �н��� �ܾ�");
		SetTextContent(SetText.texts[6], "���� ���� ����");
		SetTextContent(SetText.texts[7], "�н� ���");
		SetTextContent(SetText.texts[10], "���� ����");
		SetTextContent(SetText.texts[11], "��ǰ���� �ֱ�");
		SetTextContent(SetText.texts[12], "��ǰ �̸�");
		SetTextContent(SetText.texts[13], "��ǰ�� �Է����ּ���.");
		SetTextContent(SetText.texts[15], "��ǰ�����ֱ⸦ �Է����ּ���.");
		SetTextContent(SetText.texts[17], "�����ϱ�");
		SetTextContent(SetText.texts[18], "��� ����");
		SetTextContent(SetText.texts[19], "�ѱ���");
		SetTextContent(SetText.texts[20], "����");
	}


	void SetTextContent(Text text, string str) { text.text = str; }
}
