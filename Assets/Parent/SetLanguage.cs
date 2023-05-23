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
        LoginDirector.language = 1;
        SetKorText();

	}
    public void SetEng(bool isOn)
    {
		LoginDirector.language = 0;
        SetEngText();
	}

    void SetEngText()
    {
        SetTextContent(SetText.parentText[0], "ParentHome");
        SetTextContent(SetText.parentText[2], "Back to HomeScene");
        SetTextContent(SetText.parentText[4], UserInfo.GetcntWord().ToString() + " words");
        SetTextContent(SetText.parentText[5], "learned words");
        SetTextContent(SetText.parentText[6], "child level");
        SetTextContent(SetText.parentText[7], "Learning Analysis");
        SetTextContent(SetText.parentText[10], "Reward Settings");
        SetTextContent(SetText.parentText[11], "Period");
        SetTextContent(SetText.parentText[12], "Name");
        SetTextContent(SetText.parentText[13], "Please enter prize");
		SetTextContent(SetText.parentText[15], "Please enter period");
		SetTextContent(SetText.parentText[17], "Save");
        SetTextContent(SetText.parentText[18], "Language Setting");
        SetTextContent(SetText.parentText[19], "Korean");
        SetTextContent(SetText.parentText[20], "English");
    }
	void SetKorText()
	{
		SetTextContent(SetText.parentText[0], "�θ�Ȩ");
		SetTextContent(SetText.parentText[2], "�н�ȭ������ ���ư���");
		SetTextContent(SetText.parentText[4], UserInfo.GetcntWord().ToString() + " ��");
		SetTextContent(SetText.parentText[5], "���ñ��� �н��� �ܾ�");
		SetTextContent(SetText.parentText[6], "���� ���� ����");
		SetTextContent(SetText.parentText[7], "�н� ���");
		SetTextContent(SetText.parentText[10], "���� ����");
		SetTextContent(SetText.parentText[11], "��ǰ���� �ֱ�");
		SetTextContent(SetText.parentText[12], "��ǰ �̸�");
		SetTextContent(SetText.parentText[13], "��ǰ�� �Է����ּ���.");
		SetTextContent(SetText.parentText[15], "��ǰ�����ֱ⸦ �Է����ּ���.");
		SetTextContent(SetText.parentText[17], "�����ϱ�");
		SetTextContent(SetText.parentText[18], "��� ����");
		SetTextContent(SetText.parentText[19], "�ѱ���");
		SetTextContent(SetText.parentText[20], "����");
	}


	void SetTextContent(Text text, string str) { text.text = str; }
}
