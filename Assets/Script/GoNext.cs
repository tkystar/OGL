using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoNext : MonoBehaviour
{
    public int a = 0;
    public GameObject sliderObj;             /////�X���C�_�I�u�W�F�N�g
    Slider sensitivitySlider;
    public static float sensitivity;
    public GameObject parameterTextObj;     ////�X���C�_UI�̉��ɕ\��������p�����[�^�[
    Text parameterText;

    public GameObject sliderObj2;             /////�X���C�_�I�u�W�F�N�g
    Slider sensitivitySlider2;
    public static float sensitivity2;
    public GameObject parameterTextObj2;     ////�X���C�_UI�̉��ɕ\��������p�����[�^�[
    Text parameterText2;

    public GameObject sliderObj3;             /////�X���C�_�I�u�W�F�N�g
    Slider sensitivitySlider3;
    public static float sensitivity3;
    public GameObject parameterTextObj3;     ////�X���C�_UI�̉��ɕ\��������p�����[�^�[
    Text parameterText3;
    // Start is called before the first frame update
    void Start()
    {
        sensitivitySlider = sliderObj.GetComponent<Slider>();
        parameterText = parameterTextObj.GetComponent<Text>();

        sensitivitySlider2 = sliderObj2.GetComponent<Slider>();
        parameterText2 = parameterTextObj2.GetComponent<Text>();

        sensitivitySlider3 = sliderObj3.GetComponent<Slider>();
        parameterText3 = parameterTextObj3.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sensitivity = sensitivitySlider.value;
        parameterText.text = sensitivity.ToString("f2");  ///"f2"�́A�����_���ʂ܂ŕ\���Ƃ����Ӗ��B���R�ɕύX�B

        sensitivity2 = sensitivitySlider2.value;
        parameterText2.text = sensitivity2.ToString("f2");

        sensitivity3 = sensitivitySlider3.value;
        parameterText3.text = sensitivity3.ToString("f2");

        if (Input.GetKeyDown(KeyCode. Space)){
            SceneManager.LoadScene("MainScene");
            Debug.Log("#");
        }
    }

    public static float getSensitivity()          ///�ʃX�N���v�g����Ăяo���֐��B�֐����͔C�ӁB�^�͕ϐ��̌^�ɂ���B
    {
        return sensitivity;     ////���������ϐ���߂�l�ɂ���B
    }

    public static float getSensitivity2()          ///�ʃX�N���v�g����Ăяo���֐��B�֐����͔C�ӁB�^�͕ϐ��̌^�ɂ���B
    {
        return sensitivity2;     ////���������ϐ���߂�l�ɂ���B
    }

    public static float getSensitivity3()          ///�ʃX�N���v�g����Ăяo���֐��B�֐����͔C�ӁB�^�͕ϐ��̌^�ɂ���B
    {
        return sensitivity3;     ////���������ϐ���߂�l�ɂ���B
    }

}
