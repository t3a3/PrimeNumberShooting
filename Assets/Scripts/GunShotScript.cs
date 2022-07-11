
using UnityEngine;
using KanKikuchi.AudioManager;

public class GunShotScript : MonoBehaviour
{
    public GameObject gunShotPrefabPosition;
    public GameObject gunShotPrefab;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30f;

    public AudioClip shotSE;

    //握られてるかどうか
    bool grabbed;
    bool onceSE;

    //このゲームオブジェクトについているOVRGrabbableを登録
    public OVRGrabbable oVRGrabbable;

    //左右の手のOVRGrabberを登録
    public OVRGrabber LeftGrabber;
    public OVRGrabber RightGrabber;

    private void Start()
    {
        onceSE = true;
      

    }
    void Update()
    {
       
        grabbed = oVRGrabbable.isGrabbed;



        if (grabbed == true)
        {
            if (onceSE == true) HoldGun();
            if (oVRGrabbable.grabbedBy == LeftGrabber)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
                {
                    LauncherShot();
                    GameObject effect = Instantiate(gunShotPrefab, new Vector3(gunShotPrefabPosition.transform.position.x,
                        gunShotPrefabPosition.transform.position.y, gunShotPrefabPosition.transform.position.z), Quaternion.identity);
                }

            }
            if (oVRGrabbable.grabbedBy == RightGrabber)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    LauncherShot();
                    GameObject effect = Instantiate(gunShotPrefab, new Vector3(gunShotPrefabPosition.transform.position.x,
                        gunShotPrefabPosition.transform.position.y, gunShotPrefabPosition.transform.position.z), Quaternion.identity);
                }

            }
        }
        else
        {
            onceSE = true;
        }
    }
    private void LauncherShot()
    {
        SEManager.Instance.Play(SEPath.GUN_SHOT,0.3f);
        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = newBall.transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 0.8f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            this.gameObject.transform.position = new Vector3(-0.1f, 1.04f, -7.4f);
        }
    }

    void HoldGun()
    {
        SEManager.Instance.Play(SEPath.GUN_HOLD,0.3f);
        onceSE = false;
    }
}
