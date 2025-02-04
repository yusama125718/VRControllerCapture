using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class ControllerCapture : MonoBehaviour
{
    [SerializeField] private GameObject button_a;
    [SerializeField] private GameObject button_b;
    [SerializeField] private GameObject button_x;
    [SerializeField] private GameObject button_y;
    [SerializeField] private GameObject righttrigger_1;
    [SerializeField] private GameObject righttrigger_2;
    [SerializeField] private GameObject lefttrigger_1;
    [SerializeField] private GameObject lefttrigger_2;
    [SerializeField] private GameObject rightstick;
    [SerializeField] private GameObject leftstick;
    private Animator anime_righttrigger_1;
    private Animator anime_righttrigger_2;
    private Animator anime_lefttrigger_1;
    private Animator anime_lefttrigger_2;

    private CVRSystem vrSystem;

    void Start()
    {
        var error = EVRInitError.None;
        vrSystem = OpenVR.Init(ref error, EVRApplicationType.VRApplication_Other);
        anime_righttrigger_1 = righttrigger_1.GetComponent<Animator>();
        anime_righttrigger_2 = righttrigger_2.GetComponent<Animator>();
        anime_lefttrigger_1 = lefttrigger_1.GetComponent<Animator>();
        anime_lefttrigger_2 = lefttrigger_2.GetComponent<Animator>();
    }

    void Update()
    {
        if (SteamVR_Actions.default_A.GetStateDown(SteamVR_Input_Sources.Any))
        {
            button_a.SetActive(true);
        } 
        if (SteamVR_Actions.default_A.GetStateUp(SteamVR_Input_Sources.Any))
        {
            button_a.SetActive(false);
        }
        if (SteamVR_Actions.default_B.GetStateDown(SteamVR_Input_Sources.Any))
        {
            button_b.SetActive(true);
        } 
        if (SteamVR_Actions.default_B.GetStateUp(SteamVR_Input_Sources.Any))
        {
            button_b.SetActive(false);
        }
        if (SteamVR_Actions.default_X.GetStateDown(SteamVR_Input_Sources.Any))
        {
            button_x.SetActive(true);
        } 
        if (SteamVR_Actions.default_X.GetStateUp(SteamVR_Input_Sources.Any))
        {
            button_x.SetActive(false);
        }
        if (SteamVR_Actions.default_Y.GetStateDown(SteamVR_Input_Sources.Any))
        {
            button_y.SetActive(true);
        } 
        if (SteamVR_Actions.default_Y.GetStateUp(SteamVR_Input_Sources.Any))
        {
            button_y.SetActive(false);
        }

        anime_righttrigger_1.SetFloat("State", SteamVR_Actions.default_RightTrigger_1.GetAxis(SteamVR_Input_Sources.Any));
        anime_righttrigger_2.SetFloat("State", SteamVR_Actions.default_RightTrigger_2.GetAxis(SteamVR_Input_Sources.Any));

        anime_lefttrigger_1.SetFloat("State", SteamVR_Actions.default_LeftTrigger_1.GetAxis(SteamVR_Input_Sources.Any));
        anime_lefttrigger_2.SetFloat("State", SteamVR_Actions.default_LeftTrigger_2.GetAxis(SteamVR_Input_Sources.Any));

        Vector2 r_stickpos = SteamVR_Actions.default_RightStick.GetAxis(SteamVR_Input_Sources.Any);
        Vector3 r_stick3 = new Vector3(r_stickpos.x, r_stickpos.y, 0);
        rightstick.transform.position = rightstick.transform.parent != null ? rightstick.transform.parent.TransformPoint(r_stick3) : r_stick3;

        Vector2 l_stickpos = SteamVR_Actions.default_LeftStick.GetAxis(SteamVR_Input_Sources.Any);
        Vector3 l_stick3 = new Vector3(l_stickpos.x, l_stickpos.y, 0);
        leftstick.transform.position = leftstick.transform.parent != null ? leftstick.transform.parent.TransformPoint(l_stick3) : l_stick3;
    }
}
