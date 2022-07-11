using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    public static Ranking ranking;

    [Header("EasyRankingText")]
    [SerializeField] Text[] easyRankingText;

    [Header("NormalRankingText")]
    [SerializeField] Text[] normalRankingText;

    [Header("HardRankingText")]
    [SerializeField] Text[] hardRankingText;

    [Header("VeryHardRankingText")]
    [SerializeField] Text[] veryhardRankingText;

    string[] rankingNumE = { "E_1", "E_2", "E_3", "E_4", "E_5" };
    string[] rankingNumN = { "N_1", "N_2", "N_3", "N_4", "N_5" };
    string[] rankingNumH = { "H_1", "H_2", "H_3", "H_4", "H_5" };
    string[] rankingNumVH = { "VH_1", "VH_2", "VH_3", "VH_4", "VH_5" };

    [SerializeField]
    int[] rankingValue_Easy = new int[5];
    [SerializeField]
    int[] rankingValue_Normal = new int[5];
    [SerializeField]
    int[] rankingValue_Hard = new int[5];
    [SerializeField]
    int[] rankingValue_VeryHard = new int[5];

    void Start()
    {
        GameSystemScript.ResultPoint = 0;
    }
    public void onRanking()
    {
        GetRanking();
        switch (GameSystemScript.choiceD_Rank)
        {
            case 0:
               SetRanking_Easy(GameSystemScript.ResultPoint);
                break;
            case 1:
                SetRanking_Normal(GameSystemScript.ResultPoint);
                break;
            case 2:
                SetRanking_Hard(GameSystemScript.ResultPoint);
                break;
            case 3:
                SetRanking_VeryHard(GameSystemScript.ResultPoint);
                break;
        }
        for (int i = 0; i < 5; i++)
        {
            easyRankingText[i].text = i + 1 + "=" + rankingValue_Easy[i] + "pt";
            normalRankingText[i].text = i + 1 + "=" + rankingValue_Normal[i] + "pt";
            hardRankingText[i].text = i + 1 + "=" + rankingValue_Hard[i] + "pt";
            veryhardRankingText[i].text = i + 1 + "=" + rankingValue_VeryHard[i] + "pt";
        }

    }


    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        for (int i = 0; i < 5; i++)
        {
            rankingValue_Easy[i] = PlayerPrefs.GetInt(rankingNumE[i], 0);
            rankingValue_Normal[i] = PlayerPrefs.GetInt(rankingNumN[i], 0);
            rankingValue_Hard[i] = PlayerPrefs.GetInt(rankingNumH[i], 0);
            rankingValue_VeryHard[i] = PlayerPrefs.GetInt(rankingNumVH[i], 0);

        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    public void SetRanking_Easy(int _value)
    {
        //書き込み用
        for (int i = 0; i < 5; i++)
        {
            if (_value > rankingValue_Easy[i])
            {
                var change = rankingValue_Easy[i];
                rankingValue_Easy[i] = _value;
                _value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(rankingNumE[i], rankingValue_Easy[i]);
        }

        PlayerPrefs.Save();
    }
    public void SetRanking_Normal(int _value)
    {
        //書き込み用
        for (int i = 0; i < 5; i++)
        {
            if (_value > rankingValue_Normal[i])
            {
                var change = rankingValue_Normal[i];
                rankingValue_Normal[i] = _value;
                _value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(rankingNumN[i], rankingValue_Normal[i]);
        }

        PlayerPrefs.Save();
    }
    public void SetRanking_Hard(int _value)
    {
        //書き込み用
        for (int i = 0; i < 5; i++)
        {
            if (_value > rankingValue_Hard[i])
            {
                var change = rankingValue_Hard[i];
                rankingValue_Hard[i] = _value;
                _value = change;
            }
        }
        //入れ替えた値を保存
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(rankingNumH[i], rankingValue_Hard[i]);
        }

        PlayerPrefs.Save();
    }
    public void SetRanking_VeryHard(int _value)
    {
        //書き込み用
        for (int i = 0; i < 5; i++)
        {
            if (_value > rankingValue_VeryHard[i])
            {
                var change = rankingValue_VeryHard[i];
                rankingValue_VeryHard[i] = _value;
                _value = change;
            }
        }
        //入れ替えた値を保存
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(rankingNumVH[i], rankingValue_VeryHard[i]);
        }

        PlayerPrefs.Save();
    }
}
