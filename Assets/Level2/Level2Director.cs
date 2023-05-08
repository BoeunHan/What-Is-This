using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Director : MonoBehaviour
{
    AudioSource audioSource;
    PopUpDirector popupDirector;

    Text textWord;
    Button btSound;
    Button btSpeech;
    Image timer;

    private float time_start;
    private float time_current;
    private float time_max = 5f;
    private bool isRecording = false;

    AudioClip recordClip = null;

    string filePath;
    string word;

    void Start()
    {
        audioSource = GameObject.Find("Director").GetComponent<AudioSource>();
        popupDirector = GameObject.Find("PopUpDirector").GetComponent<PopUpDirector>();
        textWord = GameObject.Find("TextWord").GetComponent<Text>();
        btSound = GameObject.Find("ButtonSound").GetComponent<Button>();
        btSpeech = GameObject.Find("ButtonSpeech").GetComponent<Button>();
        timer = GameObject.Find("Timer").GetComponent<Image>();

        GetWord();
        SetOnClickListener();
        SpeakCommand();
    }
    void Update()
    {
        if (isRecording)
        {
            time_current = Time.time - time_start;
            if (time_current <= time_max)
            {
                timer.fillAmount = time_current / time_max;
            }
            else
            {
                isRecording = false;
                btSpeech.interactable = true;
                StopRecording();
                string result = STT.SendAudio(filePath);
                if(result == null)
                {
                    audioSource.PlayOneShot(TTS.GetAudio("�ٽ� ���غ�����."));
                }
                else
                {
                    popupDirector.ShowPopUp(result, word);
                }
            }
        }

    }

    void GetWord()
    {
        word = "����";
        textWord.text = word;
    }

    void SetOnClickListener()
    {
        btSound.onClick.AddListener(SpeakSound);
        btSpeech.onClick.AddListener(StartSpeech);
    }

    void SpeakCommand()
    {
        audioSource.PlayOneShot(TTS.GetAudio("���� ���غ�����."));
    }

    void SpeakSound()
    {
        audioSource.PlayOneShot(TTS.GetAudio(word));
    }
    void StartSpeech()
    {
        //���ϱ� ��ư ��Ȱ��ȭ
        btSpeech.interactable = false;

        //���� ����
        recordClip = Microphone.Start(Microphone.devices[0], false, 5, 16000);

        //Ÿ�̸� ���۽ð� ����
        ResetTimer();
    }
    void ResetTimer()
    {
        time_start = Time.time;
        time_current = 0;
        isRecording = true;
    }
    void StopRecording()
    {
        if (Microphone.IsRecording(Microphone.devices[0]))
        {
            Microphone.End(Microphone.devices[0]);

            if (recordClip == null)
            {
                return;
            }

            filePath = Application.persistentDataPath + "\\wordPronunciation";

            SavWav.Save(filePath, recordClip);
        }
    }
}
