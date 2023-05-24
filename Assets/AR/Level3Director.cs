using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Director : MonoBehaviour
{
    AudioSource audioSource;

    Level3PopUpDirector popupDirector;

    public GameObject[] hearts;
    public GameObject[] brokenHearts;

    int life = 3;

    void Start()
    {
        audioSource = GameObject.Find("Director").GetComponent<AudioSource>();
        popupDirector = GameObject.Find("PopUpDirector").GetComponent<Level3PopUpDirector>();

        for (int i = 0; i < 3; i++) brokenHearts[i].SetActive(false);
        SpeakCommand();
		if (LoginDirector.language == 0) SetKorText();
		else SetEngText();
	}
	void SetEngText()
	{
		SetLanguage.SetTextContent(SetText.texts[0], "Find hidden letters");
		SetLanguage.SetTextContent(SetText.texts[1], "Go Back");
		SetLanguage.SetTextContent(SetText.texts[3], "Success!");
		SetLanguage.SetTextContent(SetText.texts[4], "Go Back");
	}
	void SetKorText()
	{
		SetLanguage.SetTextContent(SetText.texts[0], "���� �ִ� ���ڸ� ã�ƺ�����");
		SetLanguage.SetTextContent(SetText.texts[1], "�׸��ҷ���");
		SetLanguage.SetTextContent(SetText.texts[3], "����!");
		SetLanguage.SetTextContent(SetText.texts[4], "ó������");
	}

	void SpeakCommand()
    {
		if (LoginDirector.language == 0)
			audioSource.PlayOneShot(TTS.GetAudio(0, "���� �ִ� ���ڸ� ã�ƺ�����."));
        else
			audioSource.PlayOneShot(TTS.GetAudio(1, "Find hidden letters"));

	}

	void ReduceLife()
    {
        life--;
        hearts[life].SetActive(false);
        brokenHearts[life].SetActive(true);
        if(life == 0)
        {
            popupDirector.ShowPopUp(false);
        }
    }

}
