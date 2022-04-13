using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using CefSharp;

namespace WpfApp2
{
   public static class ExtraFuncs
    {
        //public static readonly string MaxFilterWord = "anal,anus,arse,ass,ballsack,balls,bastard,bitch,biatch,bloody,blowjob,blow job,bollock," +
        //    "bollok,boner,boob,bugger,bum,butt,buttplug,clitoris,cock,coon,crap,cunt,damn,dick,dildo,dyke,erotic,fag,feck,fellate,fellatio," +
        //    "felching,fuck,f u c k,fudgepacker,fudge packer,gay,homo,jerk,jizz,knobend,knob end,labia,lesbian,lmao,lmfao,milf,muff,naked,nigger" +
        //    ",nigga,nude,penis,piss,poop,prick,porn,pube,pussy,queer,scrotum,sex,shit,s hit,sh1t,slut,smegma,spunk,tit,tosser,turd,twat,vagina,wank," +
        //    "whore,wtf,carnal,erotic,intimate,passionate,reproductive,sensual,animalistic,bestial,fleshly,generative,genital,genitive,procreative" +
        //    ",venereal,voluptuous,wanton";


       
        public static void SafeSearch(IWebBrowser chromiumWebBrowser)
        {
            
        }


        /// <summary>
        /// A Function to Adjust Ui control by it's Margin through a WPF window
        /// </summary>
        /// <param name="window">the WPF Window itselfe</param>
        /// <param name="control">the UI Control which will be Adjusted</param>
        /// <param name="marginMazmize">thickness of the control when the window is Maxmized</param>
        /// <param name="marginNormal">thickness of the control when the window is Normal</param>
        public static void Adjust_UIElements_On_WindowState(Window window ,Control control, Thickness marginMazmize, Thickness marginNormal)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                control.Margin = marginMazmize;
            }
            else 
            {
                control.Margin = marginNormal;
            }
        }

        /// <summary>
        /// A Function to Adjust Ui control by it's Margin with help of a Row Height through a WPF window 
        /// </summary>
        /// <param name="window">the WPF Window itselfe</param>
        /// <param name="control">the UI Control which will be Adjusted</param>
        /// <param name="marginMazmize">thickness of the control when the window is Maxmized</param>
        /// <param name="marginNormal">thickness of the control when the window is Minimaized</param>
        /// <param name="row">the Row of the Grid</param>
        /// <param name="rowHeightOnMaxmize"> the height of Row when window is Maxmized</param>
        /// <param name="rowHeightOnNormal">the height of Row when window is Normal</param>
        public static void Adjust_UIElements_On_WindowState(Window window, Control control, Thickness marginMazmize, Thickness marginNormal, RowDefinition row, double rowHeightOnMaxmize, double rowHeightOnNormal)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                row.Height = new GridLength(rowHeightOnMaxmize);
                control.Margin = marginMazmize;
            }
            else
            {
                row.Height = new GridLength(rowHeightOnNormal);
                control.Margin = marginNormal;
            }
        }



        /// <summary>
        /// A Function to Adjust winFormHost by it's Margin through a WPF window
        /// </summary>
        /// <param name="window">the WPF Window itselfe</param>
        /// <param name="host">the UI Control which will be Adjusted</param>
        /// <param name="marginMazmize">thickness of the control when the window is Maxmized</param>
        /// <param name="marginNormal">thickness of the control when the window is Normal</param>
        public static void Adjust_WinFormHost_On_WindowState(Window window, WindowsFormsHost host, Thickness marginMazmize, Thickness marginNormal)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                host.Margin = marginMazmize;
            }
            else
            {
                host.Margin = marginNormal;
            }
        }

        /// <summary>
        /// A Function to Adjust winFormHost by it's Margin with help of a Row Height through a WPF window 
        /// </summary>
        /// <param name="window">the WPF Window itselfe</param>
        /// <param name="host">the UI Control which will be Adjusted</param>
        /// <param name="marginMazmize">thickness of the control when the window is Maxmized</param>
        /// <param name="marginNormal">thickness of the control when the window is Minimaized</param>
        /// <param name="row">the Row of the Grid</param>
        /// <param name="rowHeightOnMaxmize"> the height of Row when window is Maxmized</param>
        /// <param name="rowHeightOnNormal">the height of Row when window is Normal</param>
        public static void Adjust_WinFormHost_On_WindowState(Window window, WindowsFormsHost host, Thickness marginMazmize, Thickness marginNormal, RowDefinition row, double rowHeightOnMaxmize, double rowHeightOnNormal)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                row.Height = new GridLength(rowHeightOnMaxmize);
                host.Margin = marginMazmize;
            }
            else
            {
                row.Height = new GridLength(rowHeightOnNormal);
                host.Margin = marginNormal;
            }
        }

        
    }
}
