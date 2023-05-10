using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePopUpDirector : MonoBehaviour
{
    GameObject popup;
    Button btExitPopUp;
    Button btNext;

    InputField passwordInput;

    void Start()
    {
        btExitPopUp = GameObject.Find("ButtonExitPopUp").GetComponent<Button>();
        btNext = GameObject.Find("ButtonNext").GetComponent<Button>();
        popup = GameObject.Find("PopUpWindow");
        passwordInput = GameObject.Find("PasswordInputField").GetComponent<InputField>();

        popup.SetActive(false);
    }

    public void ShowPopUp()
    {
        popup.SetActive(true);
        btExitPopUp.onClick.AddListener(HidePopUp);
        btNext.onClick.AddListener(GoToParentScene);
    }
    public void HidePopUp()
    {
        popup.SetActive(false);
    }
    public void GoToParentScene()
    {
        UserInfo.SetParentPassword("1234");
        if (passwordInput.text.Equals(UserInfo.GetParentPassword()))
        {
            Debug.Log("parent scene���� �̵�");
            //SceneManager.LoadScene("ParentScene");
        }
        else
        {
            Debug.Log("��й�ȣ�� Ʋ�Ƚ��ϴ�");
            //Toast.MakeToast("��й�ȣ�� Ʋ�Ƚ��ϴ�.");
        }
    }

}
