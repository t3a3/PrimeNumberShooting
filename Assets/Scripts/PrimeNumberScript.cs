
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrimeNumberScript : MonoBehaviour
{

    
    //数字の最大を決める
    public static int maxNumber;

    //１からmaxNumberまでの数字のリスト
    List<int> numbers = new List<int>();

    //的の数字リスト
    public List<int> targetNumberArray = new List<int>();

    //素数のリスト
    public List<int> primeNumberlist = new List<int>();


    //的の数字のテキスト
    [SerializeField] TMP_Text[] targetNumberText;

    //当たり判定を行うオブジェクトに数字を当て込むために使用
    [SerializeField] BaseObjGetNumberScript[] baseObjGetNumberScript;

    void Start()
    {

        SixListNumber();
    }


    /// <summary>
    /// 素数を生成する
    /// </summary>
    public void SieveOfEratosthenes(int n)
    {
        //2からNまでの整数を列挙する。
        bool[] isPrime = new bool[n + 1];
        for (int i = 0; i < n; i++)
        {
            isPrime[i] = true;

        }

        //0と1は整数でないのでfalse;
        isPrime[0] = false;
        isPrime[1] = false;

        //最小値である、iを残して、iの倍数を削除する
        for (int i = 2; i < (int)Mathf.Sqrt(n); i++)
        {
            int j;
            if (isPrime[i])
            {
                j = i + i;
                while (j <= n)
                {
                    isPrime[j] = false;
                    j = j + i;
                }
            }
        }

        for (int i = 0; i < isPrime.Length; i++)
        {
            if (isPrime[i])
            {
                primeNumberlist.Add(i);
            }
        }

    }

    /// <summary>
    /// 4つの素数でない数字を作って、的のリストに当て込む
    /// </summary>
    /// <param name="x">maxNumber</param>
    public void RandomNumber(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i <= 3; i++)
        {
            int num = Random.Range(1, numbers.Count);
            int ransu = numbers[num];
            //num = Random.Range(1, x);
            while (TargetNumber(ransu))
            {
                num = Random.Range(1, numbers.Count);
                ransu = numbers[num];
            }
            numbers.RemoveAt(num);
            targetNumberArray[i] = (ransu);
        }
    }

    /// <summary>
    /// 4つの素数でない数字、2つの素数をランダムに的に表示させる
    /// </summary>
    void SixListNumber()
    {
        RandomNumber(maxNumber);
        SieveOfEratosthenes(maxNumber);
        targetNumberArray[4] = primeNumberlist[Random.Range(0, primeNumberlist.Count)];
        targetNumberArray[5] = primeNumberlist[Random.Range(0, primeNumberlist.Count)];

        targetNumberArray.Shuffle();

        for (int i = 0; i <= 5; i++)
        {
            targetNumberText[i].text = "" + targetNumberArray[i];
            baseObjGetNumberScript[i].textNumber = targetNumberArray[i];
        }

    }

    /// <summary>
    /// 的の値が素数かどうかを判定
    /// </summary>
    public static bool TargetNumber(int x)
    {
        if (x < 2) return false;
        if (x == 2) return true;
        if (x % 2 == 0) return false;

        int sqrtX = (int)Mathf.Sqrt(x);
        for (int i = 3; i < sqrtX; i += 2)
        {
            if (x % i == 0) return false;
        }
        return true;
    }

}


public static class IListExtension
{

    /// <summary>
    /// 中身をシャッフル
    /// </summary>
    public static void Shuffle<T>(this IList<T> self)
    {
        if (self == null || self.Count <= 1)
            return;

        for (var i = self.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i);
            var tmp = self[i];
            self[i] = self[j];
            self[j] = tmp;
        }
    }
}

