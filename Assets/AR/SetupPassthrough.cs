using UnityEngine;

public class SetupPassthrough : MonoBehaviour
{
    void Start()
    {
        OVRPassthroughLayer passthrough = gameObject.AddComponent<OVRPassthroughLayer>();

        // à»â∫ÇÕ v55 à»ç~ÇÃç\ï∂
#if UNITY_ANDROID && !UNITY_EDITOR
        passthrough.overlayType = OVRPassthroughLayer.OverlayType.Underlay;
        passthrough.placement = OVRPassthroughLayer.Placement.Underlay;
        passthrough.occlusionEnabled = true;
#endif
    }
}
