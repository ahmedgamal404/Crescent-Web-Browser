using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WpfApp2.Ref.HTML;
using System.Threading.Tasks;
using CefSharp;

namespace WpfApp2.Ref
{
   public static class SafeSearch
    {
        #region Arabic Inappropriate Vocabs
        public static readonly string searchBarFilterWords_AR = "جنسي،جنسى،سكس،سكسي،سكسى،فاحش،فحش،فواحش،عاري،ميلف،شراميط،شرموطة،عارى،عارية،ملط،بيكيني" +
            "حلمة،حلمات،بكيني،مايوهات،لواط،سحاق،طيز،طياز، بز ،بزاز، نيك ، ناك ،باحي ،عاهر، شرجي ،قالع";
        public static readonly string pageFilterWords_AR = "نهد ،نهود،مومس،شرموط،عربد،طيز،طياز،بز،بزاز،متناكة،باحي،عاهر،شرجي،قالع";
        public static readonly string DMWords_AR = "صدر،صدور،كس،جنس،ساخن،فخذ،فخاذ،فخاد";
        public static readonly string filterWordsDefiner_AR= "بنت،بنات،ستات،مرأة،نساء،حريم،زوجة،شباب،رجل،رجال،صديق،عزباء،مطلق";
        #endregion

        #region English inappropriate Vocabs
        /// <summary>
        /// It's a String field which contains Many of words which are inappropriate to be searched as in ISLAM
        /// </summary>
        public static readonly string searchBarFilterWords_EN = "anal,arse,ass,blowjob,blow job,bollock,boob,boobs,butt,buttplug,buttlug,clitoris,cock,cum,cunnilingus" +
              "cunt,dick,dildo,doggy style,dyke,erotic,ejaculate,fellatio,felching,foreplay,fuck,f u c k,fudgepacker,fudge packer,gay,handjob,hand job,homo,jerk,jizz" +
              "knobend,labia,lesbian,lgbt,Libido,lmao,lmfao,love Bite,masturbat,milf,muff,naked,nipples,nigger,nigga,nude,oralsex,oral sex,orgasm,penis,piss" +
              "poop,prick,porn,pussy,queer,sex,shit,s hit,sh1t,slut,smegma,spunk,tit,tits,tribbing,tosser,vagina,wank" +
              "whore,carnal,erotic,passionate,venereal,vibrator,voluptuous,vulva,wanton,x-rated,x rated,xxx";
        /// <summary>
        /// It's a String field which contains Many of words which are inappropriate to be shown at web page
        /// </summary>
        public static readonly string pageFilterWords_EN = " anal , arse , ass ,blowjob,blow job,bollock,boobs, butt ,buttplug,buttlug,clitoris,cock ,cum ,cunnilingus" +
            "cunt,dick,dildo,doggy style,dyke,erotic,ejaculate,fellatio,felching,foreplay,fuck,f u c k,fudgepacker,fudge packer,gay,handjob,hand Job,homo " +
            "jerk,jizz,knobend,labia,lesbian,lgbt,Libido,lmao,lmfao,love Bite,masturbat,milf,muff ,naked,nipples,nigger,nigga,nude,oral sex,oralsex,orgasm,penis,piss " +
            "prick ,porn,pussy,queer,sex, shit ,s hit,sh1t, slut ,smegma,spunk,tit ,tits,tribbing,tosser,vagina,wank" +
            "whore,carnal,erotic,passionate,venereal,vibrator,voluptuous,vulva,wanton,x-rated,x rated";
        /// <summary>
        /// means Double Meaning Words
        /// </summary>
        public static readonly string DMWords_EN = " anal, arse ,bastard,biatch,bitch,bugger,fingering,g Spot,g-Spot,heterosexual,horny,homo,hot" +
            "kissing,licking Out,paedophilia,pansexual,penetrative,petting, rape ,rimming,shag,snog ,breast";
        /// <summary>
        /// Some Words to determine if the DMW is inappropriate or not
        /// </summary>
        public static readonly string filterWordsDefiner_EN = " man ,guy,woman,women,lady,femme, dame ,nymphet,young,girl, teen ,teenage,donn, mom ,wife,widow,daughter";
        #endregion

        private static bool goTo2ndFilter = false;
        private static bool goTo3rdFilter = false;
        private static bool goTo4thFilter = false;
        private static bool IsSafeSearch;

        //public static string NudityJS = "";

        public static bool SearchBarFilter(ComboBox urlComboBox)
        {
            for (int i = 0; i < searchBarFilterWords_EN.Split(',').Length; i++)
            {
                if (urlComboBox.Text.Contains(searchBarFilterWords_EN.Split(',')[i]))
                {
                    MessageBox.Show("Prohipted Searched Content !!!");
                    IsSafeSearch = false;
                }
                else 
                {
                    IsSafeSearch = true; 
                }
            }
            for (int i = 0; i < searchBarFilterWords_AR.Split('،').Length; i++)
            {
                if (urlComboBox.Text.Contains(searchBarFilterWords_AR.Split('،')[i]))
                {
                    MessageBox.Show("Prohipted Searched Content !!!");
                    IsSafeSearch = false;
                }
                else 
                {
                    IsSafeSearch = true;
                }
            }
            return IsSafeSearch;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabWebBrowser"></param>
        /// <param name="chromiumWebBrowser"></param>
        /// <param name="pageText"></param>
        public static void PageFilter(TabWebBrowser tabWebBrowser,IWebBrowser chromiumWebBrowser,string pageText)
        {
            tabWebBrowser.Dispatcher.BeginInvoke((Action)(async () =>
            {
                pageText = await chromiumWebBrowser.GetTextAsync();

                /// Basic Way
                //for (int i = 0; i < pageFilterWords_EN.Split(',').Length; i++)
                //{
                //    if (pageText.Contains(pageFilterWords_EN.Split(',')[i]))
                //    {
                //        MessageBox.Show("Prohipted Content!!");
                //        chromiumWebBrowser.Find(0, pageFilterWords_EN.Split(',')[i], false, false, false);
                //    }
                //}
                //for (int i = 0; i < pageFilterWords_AR.Split('،').Length; i++)
                //{
                //    if (pageText.Contains(pageFilterWords_AR.Split('،')[i]))
                //    {
                //        MessageBox.Show("Prohipted Content!!");
                //        chromiumWebBrowser.Find(0, pageFilterWords_AR.Split('،')[i], false, false, false);
                //        return;
                //    }

                //}

                //for (int i = 0; i < DMWords_EN.Split(',').Length; i++)
                //{
                //    if (pageText.Contains(DMWords_EN.Split(',')[i]))
                //    {
                //        for (int x = 0; x < filterWordsDefiner_EN.Split(',').Length; x++)
                //        {
                //            if (pageText.Contains(filterWordsDefiner_EN.Split(',')[x]))
                //            {
                //                MessageBox.Show("Prohipted Content!!");
                //                chromiumWebBrowser.Find(0, filterWordsDefiner_EN.Split(',')[x], false, false, false);
                //            }
                //        }
                //    }
                //}
                //for (int i = 0; i < DMWords_AR.Split('،').Length; i++)
                //{
                //    if (pageText.Contains(DMWords_AR.Split('،')[i]))
                //    {
                //        for (int x = 0; x < filterWordsDefiner_AR.Split('،').Length; x++)
                //        {
                //            if (pageText.Contains(filterWordsDefiner_AR.Split('،')[x]))
                //            {
                //                MessageBox.Show("Prohipted Content!!");
                //                chromiumWebBrowser.Find(0, filterWordsDefiner_AR.Split('،')[x], false, false, false);
                //            }
                //        }
                //    }
                //}
                //----------------------------------------------------------------------
                //----------------------------------------------------------------------

                // Advanced Way
                for (int i = 0; i < pageFilterWords_EN.Split(',').Length; i++)
                {
                    if (pageText.Contains(pageFilterWords_EN.Split(',')[i]))
                    {
                        //MessageBox.Show("Prohipted Content!");
                        chromiumWebBrowser.LoadHtml(HTMLPages.ErrorLoadingPage(tabWebBrowser.tempsearchBarTxt));
                        chromiumWebBrowser.Find(0, pageFilterWords_EN.Split(',')[i], false, false, false);
                        return;

                    }
                    goTo2ndFilter = true;
                }
                if (goTo2ndFilter)
                {
                    for (int i = 0; i < pageFilterWords_AR.Split('،').Length; i++)
                    {
                        if (pageText.Contains(pageFilterWords_AR.Split('،')[i]))
                        {
                            //MessageBox.Show("Prohipted Content!!");
                            chromiumWebBrowser.LoadHtml(HTMLPages.ErrorLoadingPage(tabWebBrowser.tempsearchBarTxt));
                            chromiumWebBrowser.Find(0, pageFilterWords_AR.Split('،')[i], false, false, false);
                            return;
                        }
                        goTo3rdFilter = true;
                    }
                }
                if (goTo3rdFilter)
                {
                    for (int i = 0; i < DMWords_EN.Split(',').Length; i++)
                    {
                        if (pageText.Contains(DMWords_EN.Split(',')[i]))
                        {
                            for (int x = 0; x < filterWordsDefiner_EN.Split(',').Length; x++)
                            {
                                if (pageText.Contains(filterWordsDefiner_EN.Split(',')[x]))
                                {
                                    //MessageBox.Show("Prohipted Content!!!");
                                    chromiumWebBrowser.LoadHtml(HTMLPages.ErrorLoadingPage(tabWebBrowser.tempsearchBarTxt));
                                    chromiumWebBrowser.Find(0, DMWords_EN.Split(',')[i], false, false, false);
                                    return;
                                }
                                goTo4thFilter = true;
                            }
                        }
                    }
                }
                if (goTo4thFilter)
                {
                    for (int i = 0; i < DMWords_AR.Split('،').Length; i++)
                    {
                        if (pageText.Contains(DMWords_AR.Split('،')[i]))
                        {
                            for (int x = 0; x < filterWordsDefiner_AR.Split('،').Length; x++)
                            {
                                if (pageText.Contains(filterWordsDefiner_AR.Split('،')[x]))
                                {
                                    //MessageBox.Show("Prohipted Content!!!!");
                                    chromiumWebBrowser.LoadHtml(HTMLPages.ErrorLoadingPage(tabWebBrowser.tempsearchBarTxt));
                                    chromiumWebBrowser.Find(0, filterWordsDefiner_AR.Split('،')[x], false, false, false);
                                    return;
                                }
                            }
                        }
                    }
                }
            }));

            goTo2ndFilter = false;
            goTo3rdFilter = false;
            goTo4thFilter = false;
        }

    }
}
