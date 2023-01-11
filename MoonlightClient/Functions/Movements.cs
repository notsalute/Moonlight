using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
using VRC;
using VRC.DataModel;
using System.Collections;
using UnityEngine.XR;
using VRC.Animation;
using Photon.Realtime;

namespace Moonlight_Client.Functions
{
    internal class Movements
    {
        public static float NewSpeedValue = 10;

        public static float FlySpeedValue = 6f;

        public static void FastWalk()
        {
            Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() * NewSpeedValue);
            Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() * NewSpeedValue);
            Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetStrafeSpeed() * NewSpeedValue);
        }

        public static void NormalWalk()
        {
            Networking.LocalPlayer.SetWalkSpeed(2);
            Networking.LocalPlayer.SetRunSpeed(4);
            Networking.LocalPlayer.SetStrafeSpeed(2);
        }

        public static void NoClipperOn()
        {
            //This is broken for some reason

            var Colliders = Resources.FindObjectsOfTypeAll<Collider>();
            foreach (var Collider in Colliders) if (Collider.name.Contains("VRCPlayer")) Collider.enabled = false;
            Networking.LocalPlayer.SetWalkSpeed(5);
            Networking.LocalPlayer.SetRunSpeed(5);
            Networking.LocalPlayer.SetStrafeSpeed(5);
        }

        public static void NoClipperOff()
        {
            //This is broken for some reason

            var Colliders = Resources.FindObjectsOfTypeAll<Collider>();
            foreach (var Collider in Colliders) if (Collider.name.Contains("VRCPlayer")) Collider.enabled = true;
            Networking.LocalPlayer.SetWalkSpeed(2);
            Networking.LocalPlayer.SetRunSpeed(4);
            Networking.LocalPlayer.SetStrafeSpeed(2);
        }

        public static void infjump()
        {
            if (VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").prop_Boolean_0 && !Networking.LocalPlayer.IsPlayerGrounded())
            {
                var Jump = Networking.LocalPlayer.GetVelocity();
                Jump.y = Networking.LocalPlayer.GetJumpImpulse();
                Networking.LocalPlayer.SetVelocity(Jump);
            }
        }

        

        public static void infjumpoff()
        {
            var Jump = Networking.LocalPlayer.GetVelocity();
            Jump.y = Networking.LocalPlayer.GetJumpImpulse();
            Networking.LocalPlayer.SetVelocity(Jump);
        }

        //flying lmao
        public static bool flycontrol = false;

        public static void flynigga()
        {
            flycontrol = true;
        }

        public static void Dontflynigga()
        {
            flycontrol = false;
        }

        internal static VRCMotionState _motionState;
        //Flying Controls
        public static void HandleFly()
        {
            var player = VRCPlayer.field_Internal_Static_VRCPlayer_0;
            if (player == null)
                return;

            if (_motionState == null)
                _motionState = player.GetComponent<VRCMotionState>();


            if (flycontrol == false) return;

            var playerTransform = player.transform;

            if (XRDevice.isPresent)
            {
                playerTransform.position += playerTransform.forward * Time.deltaTime * Input.GetAxis("Vertical") * FlySpeedValue;
                playerTransform.position += playerTransform.right * Time.deltaTime * Input.GetAxis("Horizontal") * FlySpeedValue;
                playerTransform.position += new Vector3(0f, Time.deltaTime * Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") * FlySpeedValue);
            }
            else
            {
                var speed = Input.GetKey(KeyCode.LeftShift) ? FlySpeedValue * 2 : FlySpeedValue;
                var camera = Camera.main.transform;
                playerTransform.position += camera.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed;
                playerTransform.position += camera.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed;

                if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Q))
                    playerTransform.position -= new Vector3(0f, Time.deltaTime * speed, 0f);

                if (!Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.E))
                    playerTransform.position += new Vector3(0f, Time.deltaTime * speed, 0f);

            }

            _motionState?.Reset();
        }

    }
}
