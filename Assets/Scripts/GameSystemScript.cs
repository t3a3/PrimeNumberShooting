using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KanKikuchi.AudioManager;

public class GameSystemScript : MonoBehaviour
{
    //
    public static int choiceD_Rank;
    int choiceD;

    public GameObject gameObjectPrefab;

    //的が表示されている時間
    public float showObjTime;

    //ゲームオーバー
    bool isGameOver;

    //点数
    public static int ResultPoint=0;


    //爆発のエフェクト
    public GameObject hitEfectPrefab;

    //カウントキャンバス＆テキスト
    public GameObject countCanvasObject;
    public TMP_Text countNumberText;

    //スコアキャンス＆テキスト
    public GameObject scoreCanvasObject;
    public Text scoreText;

    //ゲーム中のスコア
    public GameObject scorePlayingObject;
    public TMP_Text scorePlayingText;

    //static変数
    public static bool targetCorrect;//球が正解の的にhitしたかどうか
    public static bool targetWrong;//球が不正解の的にhitしたかどうか
    public static GameObject hitObject;//hitしたオブジェクト

    //hitしたターゲットがもつ数字
    int hitTargetNumber;

  

    void OnEnable()
    {
        isGameOver = false;
        targetCorrect = false;
        targetWrong = false;
        choiceD_Rank = choiceD;
        StartCoroutine(PlayGame());
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayingText.text = ResultPoint + "pt";
        if (targetCorrect == true)
        {
            hitTargetNumber = hitObject.GetComponent<BaseObjGetNumberScript>().textNumber;
            SEManager.Instance.Play(SEPath.OK_003_10,0.5f);
            GameObject effect = Instantiate(hitEfectPrefab, new Vector3(hitObject.transform.position.x,
                hitObject.transform.position.y, hitObject.transform.position.z), Quaternion.identity);
            if (PrimeNumberScript.TargetNumber(hitTargetNumber) == true)
            {
                ResultPoint += 100;
            }
            else
            {
                ResultPoint += 30;
            }

            Destroy(hitObject);
            Debug.Log(hitTargetNumber);
            targetCorrect = false;
        }

        if (targetWrong == true)
        {
            SEManager.Instance.Play(SEPath.CANCEL_001_01,0.5f);
            ResultPoint -= 30;
            targetWrong = false;
        }
    }


    IEnumerator PlayGame()
    {
        scoreCanvasObject.SetActive(false);
        ResultPoint = 0;
        yield return CountNumber();
        scorePlayingObject.SetActive(true);
        for (int i = 1; i <= 10; i++)
        {
            yield return TargetShow();
        }
        scorePlayingObject.SetActive(false);
        scoreCanvasObject.SetActive(true);
        scoreText.text = ResultPoint + "pt";
   
        isGameOver = true;
        Debug.Log(isGameOver);
    }

    IEnumerator TargetShow()
    {
        GameObject newTarget = Instantiate(gameObjectPrefab, new Vector3(0.0f, 1.0f, 1.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        yield return new WaitForSeconds(showObjTime);
        Destroy(newTarget);
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator CountNumber()
    {
        yield return new WaitForSeconds(1f);
        countCanvasObject.SetActive(true);
        countNumberText.fontSize = 400;
        countNumberText.text = "3";
        SEManager.Instance.Play(SEPath.COUNT);
        yield return new WaitForSeconds(1f);
        SEManager.Instance.Play(SEPath.COUNT);
        countNumberText.text = "2";
        yield return new WaitForSeconds(1f);
        SEManager.Instance.Play(SEPath.COUNT);
        countNumberText.text = "1";
        yield return new WaitForSeconds(1f);
        SEManager.Instance.Play(SEPath.COUNTDOWN016);
        countNumberText.fontSize = 250;
        countNumberText.text = "START!";
        yield return new WaitForSeconds(1f);
        countCanvasObject.SetActive(false);

    }


    //maxNumber、出題される範囲を決める
    public void SendMaxNumber(int max)=>
        PrimeNumberScript.maxNumber = max;
    public void ChoiceD(int x) => choiceD = x;
    public void OneMorePlay() => StartCoroutine(PlayGame());


}
