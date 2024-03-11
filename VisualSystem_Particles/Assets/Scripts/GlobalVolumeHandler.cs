using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeHandler : MonoBehaviour
{
    public VolumeProfile globalVolumeProfile;

    private ChromaticAberration chromaticAberration;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustChromaticAberration(float amount)
    {
        if (globalVolumeProfile.TryGet<ChromaticAberration>(out chromaticAberration))
        {
            chromaticAberration.intensity.overrideState = true;
            chromaticAberration.intensity.value = amount;
        }
    }
}
