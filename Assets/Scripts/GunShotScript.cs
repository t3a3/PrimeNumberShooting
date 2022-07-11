
using UnityEngine;
using KanKikuchi.AudioManager;

public class GunShotScript : MonoBehaviour
{
    public GameObject gunShotPrefabPosition;
    public GameObject gunShotPrefab;

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 30f;

    public AudioClip shotSE;

    //�����Ă邩�ǂ���
    bool grabbed;
    bool onceSE;

    //���̃Q�[���I�u�W�F�N�g�ɂ��Ă���OVRGrabbable��o�^
    public OVRGrabbable oVRGrabbable;

    //���E�̎��OVRGrabber��o�^
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
        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // �o���������{�[����forward(z������)
        Vector3 direction = newBall.transform.forward;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
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
