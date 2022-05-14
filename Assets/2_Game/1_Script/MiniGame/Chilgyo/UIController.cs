using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textPlaytime;
    [SerializeField]
    private TextMeshProUGUI textMoveCount;
    [SerializeField]
    private Board board;

    public void OnResultPanel()
    {
        resultPanel.SetActive(true);

        textPlaytime.text = $"PLAY TIME : {board.Playtime / 60:D2}:{board.Playtime % 60:D2}";
        textMoveCount.text = "MOVE COUNT : " + board.MoveCount;
    }

    public void OnClickRestart()
    {
        Destroy(SGameMng.I.MiniGams);
        if (SGameMng.I.nMinGameNum.Equals(2))
            SGameMng.I.MiniGams = Instantiate(SGameMng.I.MiniGamPre[1], SGameMng.I.CanvasTr) as GameObject;
    }
}
