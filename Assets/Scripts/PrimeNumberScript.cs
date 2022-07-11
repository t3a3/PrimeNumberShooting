
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrimeNumberScript : MonoBehaviour
{

    
    //�����̍ő�����߂�
    public static int maxNumber;

    //�P����maxNumber�܂ł̐����̃��X�g
    List<int> numbers = new List<int>();

    //�I�̐������X�g
    public List<int> targetNumberArray = new List<int>();

    //�f���̃��X�g
    public List<int> primeNumberlist = new List<int>();


    //�I�̐����̃e�L�X�g
    [SerializeField] TMP_Text[] targetNumberText;

    //�����蔻����s���I�u�W�F�N�g�ɐ����𓖂č��ނ��߂Ɏg�p
    [SerializeField] BaseObjGetNumberScript[] baseObjGetNumberScript;

    void Start()
    {

        SixListNumber();
    }


    /// <summary>
    /// �f���𐶐�����
    /// </summary>
    public void SieveOfEratosthenes(int n)
    {
        //2����N�܂ł̐�����񋓂���B
        bool[] isPrime = new bool[n + 1];
        for (int i = 0; i < n; i++)
        {
            isPrime[i] = true;

        }

        //0��1�͐����łȂ��̂�false;
        isPrime[0] = false;
        isPrime[1] = false;

        //�ŏ��l�ł���Ai���c���āAi�̔{�����폜����
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
    /// 4�̑f���łȂ�����������āA�I�̃��X�g�ɓ��č���
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
    /// 4�̑f���łȂ������A2�̑f���������_���ɓI�ɕ\��������
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
    /// �I�̒l���f�����ǂ����𔻒�
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
    /// ���g���V���b�t��
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

