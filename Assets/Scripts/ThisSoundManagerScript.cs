using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
using UnityEngine.UI;

public class ThisSoundManagerScript : MonoBehaviour
{


    void Start()
    {
        BGMManager.Instance.Play(BGMPath.PRIME_BGM, 1f, 0, 1, true,false);

    }
}
