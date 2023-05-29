using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Net;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;
using UnityEngine.Animations;
using System.Reflection;
using UnityEditor;
using TensorFlowLite;

[Serializable]
public class analysis_info
{
	public int member_idx;
	public string older_date;
	public string newer_date;
}

[Serializable]
public class analysis_result
{
	public int idx;
	public int count;
	public int level;
	public float successRate1;
	public float successRate2;
	public float successRate3;
}

public class ParentDirector : MonoBehaviour
{
	string[] days = new string[9];
	public static List<int> successRate1 = new List<int>();
	public static List<int> successRate2 = new List<int>();
	public static List<int> successRate3 = new List<int>();
	public static List<analysis_result> results = new List<analysis_result>();
	public static Text parentHome;
	public static Button btnParentBack;
	Text childName;
	

	// Start is called before the first frame update
	void Start()
    {
		parentHome = GameObject.Find("TextparentHome").GetComponent<Text>();
		btnParentBack = GameObject.Find("btnParentBack").GetComponent<Button>();
		childName = GameObject.Find("childName").GetComponent<Text>();
		childName.text = "�̽���";
		//Screen.orientation = ScreenOrientation.Portrait;
		SetDays();
		if (results.Count > 0) { results.Clear(); }
		if (successRate1.Count > 0) { successRate1.Clear(); }
		if (successRate2.Count > 0) { successRate2.Clear(); }
		if (successRate3.Count > 0) { successRate3.Clear(); }
		for (int i = 7; i >= 0; i--)
		{
			RequestAnalysisInfo(days[i + 1], days[i]);
		}
		//Debug.Log(ParentDirector.successRate1[0] + " , " + ParentDirector.successRate1[1] + " , " + ParentDirector.successRate1[2] + " , " + ParentDirector.successRate1[3] + " , " + ParentDirector.successRate1[4] + " , " + ParentDirector.successRate1[5] + " , " + ParentDirector.successRate1[6] + " , " + ParentDirector.successRate1[7] + " , ");

		//for (int i = 1; i <= 8; i++)
		//{
		//	RequestAnalysisInfo(days[i], days[i - 1]);
		//}
		while (successRate1[0] == 0)
		{
			successRate1.RemoveAt(0);
			successRate2.RemoveAt(0);
			successRate3.RemoveAt(0);
			successRate1.Add(0);
			successRate2.Add(0);
			successRate3.Add(0);
		}

		//Debug.Log(ParentDirector.successRate1[0] + " , " + ParentDirector.successRate1[1] + " , " + ParentDirector.successRate1[2] + " , " + ParentDirector.successRate1[3] + " , " + ParentDirector.successRate1[4] + " , " + ParentDirector.successRate1[5] + " , " + ParentDirector.successRate1[6] + " , " + ParentDirector.successRate1[7] + " , ");


		btnParentBack.onClick.AddListener(GoToHomeScene);
	}

	void Awake()
	{

	}

	void GoToHomeScene()
    {
		SceneManager.LoadScene("HomeScene");
    }

	void SetDays()
	{
		string time_0 = DateTime.Now.ToString("HH:mm:ss");
		string time = "T00:00:00";
		days[0] = DateTime.Now.ToString("yyyy/MM/dd") + "T" + time_0;
		for (int i=0;i<8;i++)
		{
			days[i + 1] = DateTime.Now.AddDays(-7 * (i+1)).ToString("yyyy/MM/dd") + time;
		}

		//for (int i=0;i<9;i++)
		//{
		//	Debug.Log(days[i]);
		//}
	}

	void RequestAnalysisInfo(string older, string newer)
	{
		analysis_info info = new analysis_info();
		info.member_idx = UserInfo.GetUserIdx();
		info.older_date = older;
		info.newer_date = newer;
		string apiUrl = "http://ec2-43-201-246-145.ap-northeast-2.compute.amazonaws.com/getAnalysis/date/between?member_idx=" + info.member_idx.ToString() + "&older_date="+info.older_date+"&newer_date="+info.newer_date;


		string str = JsonUtility.ToJson(info);
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
		request.Method = "GET";
		//Debug.Log("get start");
		try
		{
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			//Debug.Log("read");
			string json = reader.ReadToEnd();

			analysis_result result = JsonUtility.FromJson<analysis_result>(json);
			results.Add(result);
			successRate1.Add((int)result.successRate1);
			successRate2.Add((int)result.successRate2);
			successRate3.Add((int)result.successRate3);
			//Debug.Log(result.idx);
		}
		catch (WebException e)
		{

		}

	}
}
