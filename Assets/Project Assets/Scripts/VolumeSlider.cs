using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioSource fundoMusical;

    public void VolumeMusical(float value)
    {
        fundoMusical.volume = value;
    }
}
