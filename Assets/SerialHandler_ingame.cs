using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.IO.Ports;
using System.Threading;

namespace iwashi
{
public class SerialHandler_ingame : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceivedd;


    //ポート名
    //例
    //Linuxでは/dev/ttyUSB0
    //windowsではCOM1
    //Macでは/dev/tty.usbmodem1421など
    public string portName;
    public int baudRate;
    public SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    public string message_;
    public bool isNewMessageReceived_ = false;
    
    

    void Awake()
    {
        Open();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (isNewMessageReceived_) {
            OnDataReceivedd(message_);
        }
        isNewMessageReceived_ = false;
       
       
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        Debug.Log("##");
        //serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
         //または
         serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();

        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive) {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen) {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
            try {
               message_ = serialPort_.ReadLine();
                //message_ = serialPort_.ReadChar();  ///readexistig
               
                
                isNewMessageReceived_ = true;
            } catch (System.Exception e) {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try {
            serialPort_.Write(message);
        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }

    
        
    
}

}