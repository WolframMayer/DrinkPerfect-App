using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
//using UnityEngine.iOS;
//using Unity.Notifications.iOS;
using Unity.Notifications.Android;

public class PushMessage : MonoBehaviour
{
    void Start()
    {
        // Create channel for notification
        AndroidNotificationChannel c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(c);

        // Set information
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "DrinkPerfect";
        notification.Text = "Dein Getränk wartet auf dich!";

        // send notification
        AndroidNotificationCenter.SendNotification(notification, "channel_id");


        // For iOS Notification

        //IEnumerator RequestAuthorization()
        //{
        //    using (var req = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge, true))
        //    {
        //        while (!req.IsFinished)
        //        {
        //            yield return null;
        //        };

        //        string res = "\n RequestAuthorization: \n";
        //        res += "\n finished: " + req.IsFinished;
        //        res += "\n granted :  " + req.Granted;
        //        res += "\n error:  " + req.Error;
        //        res += "\n deviceToken:  " + req.DeviceToken;
        //        Debug.Log(res);
        //    }
        //}

        ////var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        ////{
        ////    TimeInterval = new TimeSpan(0, minutes, seconds),
        ////    Repeats = false
        ////};

        //var notification = new iOSNotification()
        //{
        //    // You can optionally specify a custom identifier which can later be 
        //    // used to cancel the notification, if you don't set one, a unique 
        //    // string will be generated automatically.
        //    Identifier = "_notification_01",
        //    Title = "DrinkPerfect",
        //    //Body = "Scheduled at: " + DateTime.Now.ToShortDateString() + " triggered in 5 seconds",
        //    Subtitle = "Prost!! Dein Getränk wartet auf dich",
        //    ShowInForeground = true,
        //    ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
        //    CategoryIdentifier = "category_a",
        //    ThreadIdentifier = "thread1",
        //    //Trigger = timeTrigger,
        //};

        //iOSNotificationCenter.ScheduleNotification(notification);
    }
}


