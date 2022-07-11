using UnityEngine;
using KanKikuchi.AudioManager;

public class VolumeSlider : MonoBehaviour
{

    /// <summary>
    /// �X���C�_�[�ɍ��킹��BGM�̃{�����[����ύX����(�Đ����̂��̂�)
    /// </summary>
    public void ChangeBGMVolume(float volume)
    {
        BGMManager.Instance.ChangeBaseVolume(volume);
    }

    /// <summary>
    /// �X���C�_�[�ɍ��킹��SE�̃{�����[����ύX����(�Đ����̂��̂�)
    /// </summary>
    public void ChangeSEVolume(float volume)
    {
        SEManager.Instance.ChangeBaseVolume(volume);
    }

}