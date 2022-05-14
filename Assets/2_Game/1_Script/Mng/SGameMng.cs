using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public GameObject SettingGams;
	public GameObject[] MiniGamPre;
	public GameObject MiniGams;

	public Text testLog;
	public Text ColorText;

	public Transform CanvasTr;

	public Player PlayerSc;

	public RaycastHit2D hit;

	public Item SelectItem;

	public int nMinGameNum;
	public int nColorCount;

	public bool bIsSelecting;
	public bool bTimePause;
	public bool bMinGame;

	public void log(string msg) => testLog.text += msg + "\n";

	public void Raycast()
	{
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Ray2D ray = new Ray2D(pos, Vector2.zero);

		hit = Physics2D.Raycast(ray.origin, ray.direction);

		if (hit.collider != null)
		{
			if (hit.collider.CompareTag("Item"))
			{
				SelectItem = hit.collider.GetComponent<Item>();
				SelectItem.bSelecting = true;
				bIsSelecting = true;
			}
		}
	}

	public void DropItem()
	{
		if (bIsSelecting)
		{
            if (!SelectItem.bReachPlayer)
            {
				SelectItem.bSelecting = false;
				SelectItem.transform.localPosition = SelectItem.SavePos;
            }
            else
            {
				Debug.Log("아이템화");
				Destroy(SelectItem.gameObject);
            }
			bIsSelecting = false;
			SelectItem = null;
		}
	}

	public void PauseGame()
	{
		if (!bTimePause)
		{
			bTimePause = true;
			SettingGams.SetActive(true);
			Time.timeScale = 0.0f;
		}
        else
        {
			bTimePause = false;
			SettingGams.SetActive(false);
			Time.timeScale = 1.0f;
        }
	}
}