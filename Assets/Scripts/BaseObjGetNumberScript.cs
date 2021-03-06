using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjGetNumberScript : MonoBehaviour
{

    public int textNumber;

    private void OnCollisionEnter(Collision other)
    {
        //赤い銃弾(素数)が当たった時
        if (other.gameObject.tag == "RBullet"&&PrimeNumberScript.TargetNumber(textNumber)==true)
        {
            Destroy(other.gameObject);
            GameSystemScript.hitObject = this.gameObject;
            GameSystemScript.targetCorrect = true;
        }
        else if(other.gameObject.tag == "RBullet" && PrimeNumberScript.TargetNumber(textNumber) == false)
        {
            Destroy(other.gameObject);
            GameSystemScript.targetWrong = true;
        }
        //青い銃弾(素数以外)が当たった時
        if (other.gameObject.tag == "BBullet" && PrimeNumberScript.TargetNumber(textNumber) == false)
        {
            Destroy(other.gameObject);
            GameSystemScript.hitObject = this.gameObject;
            GameSystemScript.targetCorrect = true;
        }
        else if(other.gameObject.tag == "BBullet" && PrimeNumberScript.TargetNumber(textNumber) == true)
        {
            Destroy(other.gameObject);
            GameSystemScript.targetWrong = true;
        }
    }
}
