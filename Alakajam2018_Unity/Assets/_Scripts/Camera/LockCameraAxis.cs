using UnityEngine;
using Cinemachine;
 
/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
/// </summary>
[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class LockCameraAxis : CinemachineExtension
{
    [Tooltip("Lock the camera's Z position to this value")]
    public bool lockXPos;
    public bool lockYPos;
    public bool lockZPos;
    public float m_XLockedPosition;
    public float m_YLockedPosition;
    public float m_ZLockedPosition;


    public float currentYPos;
    public float lastYPos;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            if (lockXPos)
                pos.x = m_XLockedPosition;

            if (lockYPos){
                currentYPos = state.RawPosition.y;
                if (currentYPos >= lastYPos)
                {
                    pos.y =lastYPos = currentYPos;

                } else
                {
                    pos.y = lastYPos;
                }
            }

            if (lockZPos)
                pos.z = m_ZLockedPosition;

            state.RawPosition = pos;
        }
    }
}