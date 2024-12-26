﻿using System;
using SDUI;
using SDUI.Renderers;
using SkiaSharp;

namespace Outlaw
{
    class Program
    {
        [STAThread]
        public static void Main (string[] args)
        {
            Theme.BorderLowColor = new SKColor (237, 235, 233);

            var form = new MainForm ();

            if (args.Length > 0)
                form.Shown += (o, e) => {
                    var launch = DateTime.Parse (args[0]);
                    var now = DateTime.Now;
                    Console.WriteLine (args[0]);
                    Console.WriteLine (now.ToLongTimeString ());
                    Console.WriteLine (now.Subtract (launch).TotalMilliseconds);
                };

            Application.Run (form);
        }
    }
}
