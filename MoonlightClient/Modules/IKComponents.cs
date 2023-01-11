using Moonlight_Client.IK;
using RootMotion.FinalIK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Moonlight_Client.IKHandler
{
    public class IKComponent : MonoBehaviour
    {
        public IKComponent(IntPtr ptr) : base(ptr) { }
        VRIK vrik;


        void Update()
        {
            if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null) return;

            if (vrik == null) vrik = gameObject.GetComponentInChildren<VRIK>();

            // lmfao >> 
            if (RuntimeConfig.tPose)
                vrik.animator.enabled = false;

            if (RuntimeConfig.twist)
            {
                vrik.fixTransforms = false;
                vrik.animator.enabled = false;
            }

            if (RuntimeConfig.noNeck)
                vrik.solver.hasNeck = false;

            if (RuntimeConfig.noChest)
                vrik.solver.hasChest = false;

            if (RuntimeConfig.leftArm)
                vrik.solver.leftArm.positionWeight = 1f;

            if (RuntimeConfig.rightArm)
                vrik.solver.rightArm.positionWeight = 1f;
        }
    }
}