﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BT_COMMONS.Helpers;

public class Ticker : INotifyPropertyChanged
{
    public Ticker()
    {
        Timer timer = new Timer();
        timer.Interval = 1000; // 1 second updates
        timer.Elapsed += timer_Elapsed;
        timer.Start();
    }

    public DateTime Now
    {
        get { return DateTime.Now; }
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs("Now"));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
