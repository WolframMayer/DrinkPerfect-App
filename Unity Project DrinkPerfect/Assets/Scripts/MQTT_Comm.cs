using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MQTT_Comm : MonoBehaviour
{
    public Text tempText;           // Output of actual temperature
    private byte[] ReceiveMessage;  // All received bytes of the mqtt - frame
    private string RecMessage;      // Received string with the actual temperature
    private int RecValue;           // Temperature string converted into integer value
    
    // Start is called before the first frame update
    void Start()
    {
        // Open communication channel
        MqttClient client = new MqttClient("broker.losant.com");
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        client.MqttMsgSubscribed += client_MqttMsgSubscribed;
        client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;
        // Connect(IP, Usernam, Password)
        client.Connect("5e1b6cc5e1059d0006bd921c","a4bc3725-a330-464e-a2ac-73e58f9cbadf","71e67bb064a06e80e94133319f4f494aefdb13ced3d068d4e62914a4d94e42f4");
        string[] topic = { "losant/5dd93b900ac5cc0007fbfdb7/state" };
        // Qualita of Service level
        byte[] qosLevel = {0};
        // Subscribe to a topic
        client.Subscribe(topic, qosLevel);
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        // Access data bytes throug e.Message
        ReceiveMessage = e.Message;

        //Debug.Log("Message received");
        //Debug.Log("Message Length:" + ReceiveMessage.Length);
        //for(int i = 0; i < ReceiveMessage.Length; i++)
        //{
        //    Debug.Log(ReceiveMessage[i]);
        //}

        DecodeBytes();       
    }

    void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
    {

    }

    void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
    {
        //Debug.Log(e);
    }
    private void DecodeBytes()
    {
        // Decode data UTF8 data bytes into a string
        RecMessage = Encoding.UTF8.GetString(ReceiveMessage, 0, ReceiveMessage.Length);
        //Debug.Log(RecMessage);

        // Get string with temperature value and convert it into integer
        RecValue = int.Parse(SearchString());
        CompareValue();       
    }

    private String SearchString()
    {
        // Search string for the temperature value and receive it 
        string message;
        int start, end, indexTempC;
        indexTempC = RecMessage.IndexOf("tempC", 0);     // Get part with temperature value
        start = RecMessage.IndexOf(":", indexTempC) + 1; // Start of temperature value
        end = RecMessage.IndexOf("}", start);            // End of temperature value
        message = RecMessage.Substring(start, end - start);
        tempText.text = message;                        // Output actual temperature value
        //Debug.Log(message);
        return message;
    }

    private void CompareValue()
    {
        // Compare the received value with the temperature value
        int temp = ButtonList.Instance.GetIndexTemp();
        if (RecValue > (temp-2))
        {
            if(RecValue < (temp + 2))
            {               
                //Debug.Log("Temperature reached");

                // If temperature range of +2/-2 is reached set startPush to true
                ButtonList.Instance.SetStartPush(true);
                
            }
            /*else
            {
                Debug.Log("Temperature too high");
            }*/
        }
        /*else
        {
            Debug.Log("Temperature too low");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
