using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.UI;

public enum HandState
{
    NONE =0,
    RIGHT,
    LEFT
};

public class CustomController : MonoBehaviour // ����Ʈ + �ٸ� ��Ʈ�ѷ�
{
    public InputDeviceCharacteristics characteristics;// ��Ʈ�ѷ� ����� ���� ������� �Լ��� ������
    [SerializeField]
    private List<GameObject> controllerModels; // ��ŧ���� ����Ʈ �ܿ� ��ġ�� ���̺� Model�� �������� ���� ����Ʈ
    private GameObject controllerInstance; // ������� ��Ʈ�ѷ� ����
    private InputDevice availableDevice; // �̿����� ����̽�

    public bool renderController; // Hand�� Controller ���̸� ������ ����
    public GameObject handModel; // �ڵ� ��
    private GameObject handinstance;  // �ڵ� �ν��Ͻ�

    private Animator handModelAnimator; // �ڵ� �� �ִϸ��̼� ����

    public GameObject HandGun;

    bool triggerButton;

    public HandState currentHand;

    void Start()
    {
        TryInitialize();
    }

    void Update()
    {
        // �ʱ� ��ŧ���� ����Ʈ�� ������ �ȵȴ� ��� �ٽ� �ʱ�ȭ����
        if (!availableDevice.isValid) 
        {
            TryInitialize();
            return;
        }

        if(renderController)
        {
            handinstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handinstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation(); // �ڵ� �ִϸ��̼��� ���⼭�� ����
        }

        if(HandGun != null)
        {
            bool menuButtonValue;
            if(availableDevice.TryGetFeatureValue(CommonUsages.triggerButton, out menuButtonValue) && menuButtonValue)
            {
                if(triggerButton == false && currentHand == HandGun.GetComponent<SimpleShoot>().currentGrab)
                {
                    HandGun.GetComponent<SimpleShoot>().Shoot();
                    triggerButton = true;
                }                
            }
            else
            {
                triggerButton = false;
            }
        }

        if(FindObjectOfType<GameManger>().isGameOver)
        {
            bool menuButtonValue;
            if(availableDevice.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonValue) && menuButtonValue)
            {
                FindObjectOfType<GameManger>().RestartGame();
            }
        }
    }

    private void TryInitialize() // ���۽� ����ȭ�� �Լ�
    {
        List<InputDevice> devices = new List<InputDevice>(); // devices��� ����Ʈ�� ���� 

        InputDevices.GetDevicesWithCharacteristics(characteristics, devices); // �ڵ� �󿡼� ����� devices �־���

        foreach(var device in devices)
        {
            // �ݺ������� devices�� ����̽� �̸��� ���� ������ Characteristic�� ����׷ε� �ؼ� ������
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }

        if(devices.Count > 0) // ����̽��� ������
        {
            availableDevice = devices[0]; // ù��° ����̽��� availbleDevice�� �־���
            GameObject currentControllerModel;

            if(availableDevice.name.Contains("Left"))
            {
                currentControllerModel = controllerModels[1];
                currentHand = HandState.LEFT;

            }
            else if(availableDevice.name.Contains("Right"))
            {
                currentControllerModel = controllerModels[2];
                currentHand = HandState.RIGHT;
            }
            else
            {
                currentControllerModel = null;
                currentHand = HandState.NONE;
            }      

            if(currentControllerModel) // currentControllerModel�� ������
            {
                controllerInstance = Instantiate(currentControllerModel, transform); // controllerInstance�� �ν��Ͻ��� ��
            }
            else
            {
                Debug.LogError("Didn't get suitable controller model"); // ����������
                controllerInstance = Instantiate(controllerModels[0], transform); // ù��° ��Ʈ�ѷ����� �ν��Ͻ��� ��
            }

            handinstance = Instantiate(handModel, transform); // �ڵ� �ν��Ͻ� �߰�
            handModelAnimator = handinstance.GetComponent<Animator>();
            
        }
    }

    private void UpdateHandAnimation()
    {
        if(availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) // CommonUseages�� ��ġ�Է� �Ǵ� ���̽�ƽ �� �׸�� ��ġ �� ȸ���� �������
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
