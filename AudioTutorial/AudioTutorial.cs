using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using Screen = GTA.UI.Screen;

namespace Audio_Tutorial
{
    public class AudioTutorial : Script
    {
        private bool alarm = false;
        private bool customStaticEmitter = false;
        private string alarmName = "alarm_name";
        private string staticEmmiterName = "emitter_name";
        public AudioTutorial()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            Function.Call(Hash.PREPARE_ALARM, alarmName);
        }
        private void onTick(object sender, EventArgs e)
        {
            if (customStaticEmitter)
            {
                StartMusic();
            }
            else
            {
                StopMusic();
            }
            if (alarm)
            {
                StartAlarm();
            }
            else
            {
                StopAlarm();
            }
        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J)
            {
                alarm = !alarm;
                if (alarm)
                {
                    Screen.ShowHelpText($"{alarmName}" + " ~g~ENABLED", -1, true, false);
                }
                else
                {
                    Screen.ShowHelpText($"{alarmName}" + " ~r~DISABLED", -1, true, false);
                }
            };
            if (e.KeyCode == Keys.K)
            {
                customStaticEmitter = !customStaticEmitter;
                if (customStaticEmitter)
                {
                    Screen.ShowHelpText($"{staticEmmiterName}" + " ~g~activated", -1, true, false);
                }
                else
                {
                    Screen.ShowHelpText($"{staticEmmiterName}" + " ~r~deactivated", -1, true, false);
                }
            };
        }
        private void StartAlarm()
        {
            Function.Call(Hash.START_ALARM, alarmName, 0);
        }
        private void StopAlarm()
        {
            Function.Call(Hash.STOP_ALARM, alarmName, 1);
        }
        private void StartMusic()
        {
            Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, staticEmmiterName, true);
        }
        private void StopMusic()
        {
            Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, staticEmmiterName, false);
        }

    }
}