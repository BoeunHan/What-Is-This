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

		SetTextContent(SetText.texts[9], "level1");
		SetTextContent(SetText.texts[10], "level2");
		SetTextContent(SetText.texts[11], "level3");

		SetTextContent(SetText.texts[12], "Reward Settings");
        SetTextContent(SetText.texts[13], "Period");
        SetTextContent(SetText.texts[14], "Name");
        SetTextContent(SetText.texts[15], "Please enter prize");
		SetTextContent(SetText.texts[17], "Please enter period");
		SetTextContent(SetText.texts[19], "Save");
        SetTextContent(SetText.texts[20], "Language Setting");
        SetTextContent(SetText.texts[21], "Korean");
        SetTextContent(SetText.texts[22], "English");
    }
	void SetKorText()
	{
		SetTextContent(SetText.texts[0], "�θ�Ȩ");
		SetTextContent(SetText.texts[3], UserInfo.GetcntWord().ToString() + " ��");
		SetTextContent(SetText.texts[4], "���ñ��� �н��� �ܾ�");
		SetTextContent(SetText.texts[5], "���� ���� ����");
		SetTextContent(SetText.texts[6], "�н� ���");

        SetTextContent(SetText.texts[9], "1�ܰ�");
		SetTextContent(SetText.texts[10], "2�ܰ�");
		SetTextContent(SetText.texts[11], "3�ܰ�");

		SetTextContent(SetText.texts[12], "���� ����");
		SetTextContent(SetText.texts[13], "��ǰ���� �ֱ�");
		SetTextContent(SetText.texts[14], "��ǰ �̸�");
		SetTextContent(SetText.texts[15], "��ǰ�� �Է����ּ���.");
		SetTextContent(SetText.texts[17], "��ǰ�����ֱ⸦ �Է����ּ���.");
		SetTextContent(SetText.texts[19], "�����ϱ�");
		SetTextContent(SetText.texts[20], "��� ����");
		SetTextContent(SetText.texts[21], "�ѱ���");
		SetTextContent(SetText.texts[22], "����");
	}


	public static void SetTextContent(Text text, string str) { text.text = str; }
}
