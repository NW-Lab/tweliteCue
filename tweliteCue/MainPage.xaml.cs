using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System.Diagnostics;
// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace tweliteCue
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        twelite _twelite;
        public MainPage()
        {
            this.InitializeComponent();
            _twelite=new twelite("COM6");
            _twelite.DataRcv += DataRcv;
        }
        void tb(String text) {
            textBlock.Text = text;
        }
        delegate void tb_del(String text);
       async void  DataRcv(object sender, DataRcvEventArgs e) {
          await  Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,()=>textBlock.Text=e.RcvData.センサーデータ5_Z軸.ToString());
          
        }
    }
}
