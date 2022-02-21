using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{
	private static SGameMng _Instance = null;

	public static SGameMng I
	{
		get
		{
			if (_Instance.Equals(null))
				Debug.Log("instance is null");

			return _Instance;
		}
	}

	void Awake()
	{
		_Instance = this;
	}

	public UnityEngine.UI.Text testLog;

	public void log(string msg)
	{
		testLog.text += msg + "\n";
	}

}
