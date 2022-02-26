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

    public Player PlayerSc;

	public RaycastHit2D hit;

	public Item SelectItem;
	public bool bIsSelecting;

	public void log(string msg)
	{
		testLog.text += msg + "\n";
	}

	public void Raycast()
	{
		//if (bIsSelecting)
			//return;
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Ray2D ray = new Ray2D(pos, Vector2.zero);

		hit = Physics2D.Raycast(ray.origin, ray.direction);

		if (hit.collider != null)
		{
			if (hit.collider.CompareTag("Object"))
			{
				SelectItem = hit.collider.GetComponent<Item>();
				SelectItem.bSelecting = true;
				bIsSelecting = true;
			}
		}
	}
	// 72~75 빌드후 괜찮나 확인
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

}
