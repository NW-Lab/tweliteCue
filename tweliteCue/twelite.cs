using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
namespace tweliteCue
{
    public struct tweliteData
    {
        public UInt32 中継機シリアルID;
        public Byte LQI;
        public UInt16 続き番号;
        public UInt32 送信元シリアルID;
        public Byte 送信元LID;
        public Byte センサー種別;
        public Byte PAL_IDとPAL_Ver;
        public Byte センサーデータ数;
        public twe_lite_cue_packet_data センサーデータ0;
        public twe_lite_cue_event センサーデータ1;
        public UInt32 センサーデータ2_ヘッダ; //4  1300802 2バイト、拡張ビット有 電圧(電源電圧)
        public UInt16 センサーデータ2;//2 0D16 3350ｍV
        public UInt32 センサーデータ3_ヘッダ;//4 11300102 2バイト、拡張ビット有 電圧(ADC1)
        public UInt16 センサーデータ3;//2 0598 1432mV
        public UInt32 センサーデータ4_ヘッダ;//4 00000001 1バイト拡張ビットなし ホールIC
        public Byte センサーデータ4;//1 00 オープン
        public UInt32 センサーデータ5_ヘッダ;//4 15044006 符号あり2バイト、拡張ビット有 加速度(1サンプル目)
        public Int16 センサーデータ5_X軸;//2 0188 X = 392mg
        public Int16 センサーデータ5_Y軸;//2 FCE0 Y = -800mg
        public Int16 センサーデータ5_Z軸;//2 00F0 Z = 240mg
        public UInt32 センサーデータ6_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ6_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ6_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ6_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ7_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ7_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ7_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ7_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ8_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ8_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ8_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ8_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ9_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ9_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ9_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ9_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ10_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ10_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ10_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ10_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ11_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ11_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ11_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ11_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ12_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ12_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ12_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ12_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ13_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ13_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ13_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ13_Z軸;//2 FFA0 Z = -96mg
        public UInt32 センサーデータ14_ヘッダ;//4 15044106 符号あり2バイト、拡張ビット有 加速度(2サンプル目)
        public Int16 センサーデータ14_X軸;//2 00B0 X = 176mg
        public Int16 センサーデータ14_Y軸;//2 FB20 Y = -1248mg
        public Int16 センサーデータ14_Z軸;//2 FFA0 Z = -96mg
        public Byte チェックサム1;//1 9A 1～pの1つ前までのCRC8
        public Byte チェックサム2;//1 69 1～pまでのLRC
        public Single 電源電圧mV;
        public Single ADC1mV;
        public twe_lite_cue_磁石 磁気センサー;
    };
    public enum twelite_cue_起床要因センサー : Byte
    {
        磁気センサー = 0x00,
        温度 = 0x01,
        湿度 = 0x02,
        照度 = 0x03,
        加速度 = 0x04,
        DIO = 0x31,
        タイマー = 0x35
    }
    public enum twelite_cue_起床要因 : Byte
    {
        イベントが発生した = 0x00,
        値が変化した = 0x01,
        値が閾値を超えた = 0x02,
        閾値を下回った = 0x03,
        閾値の範囲に入った = 0x04
    }
    public struct twe_lite_cue_packet_data
    {
        public Byte 各種情報ビット値; //1 0 拡張バイトなし、符号なしChar
        public Byte データソース;// 1 起床要因
        public Byte 拡張バイト;//1 00
        public Byte データ長;//1 03
        public Byte パケットID;//1 81 0～127、MSBはイベントがあるかどうか 0もしくは0x80はADC1と電源電圧、イベント以外はデータがないことを示す
        public twelite_cue_起床要因センサー 起床要因センサー;//1 04 磁気センサー:0x00 温度:0x01 湿度:0x02 照度:0x03 加速度:0x04 DIO:0x31 タイマー:0x35
        public twelite_cue_起床要因 起床要因;//1 02 送信要因 イベントが発生した:0x00 値が変化した:0x01 値が閾値を超えた:0x02 閾値を下回った:0x03 閾値の範囲に入った:0x04
    }
    public enum twe_lite_cue_event_イベントの発生要因 : Byte
    {
        磁気センサー = 0x00,
        温度 = 0x01,
        湿度 = 0x02,
        照度 = 0x03,
        加速度 = 0x04
    }
    public enum twe_lite_cue_磁石 : Byte
    {
        磁石がない = 0x00,
        N極 = 0x01,
        S極 = 0x02,
        定期送信 = 0x80
    }
    public struct twe_lite_cue_event
    {
        public Byte 各種情報ビット値;//1 12 拡張バイトあり、符号なしLong
        public Byte データソース;//1 05 イベント
        public Byte 拡張バイト;//1 04 イベントの発生要因
        public twe_lite_cue_event_イベントの発生要因 イベントの発生要因;//磁気センサー:0x00 温度:0x01 湿度:0x02 照度:0x03 加速度:0x04 MSBが1の場合はデータ2にデータが存在する。
        public Byte データ長;//1 04
        public Byte データ1;//1 10
        /**
           イベント発生要因が磁気センサーの場合
              0x00(0):近くに磁石がない
              0x01(1):磁石のN極が近くにある
              0x02(2):磁石のS極が近くにある
​
           イベント発生要因が加速度の場合
              0x01(1)～0x06(6)：さいころ
              0x08(8)：シェイク
              0x10(16)：ムーブ
        **/
        public Int32 データ2;//3 000000 未使用
    }
    class twelite : IDisposable
    {
        SerialPort _port;
        string _com;
        bool _isInitialize = false;
        tweliteData _TweliteData;
        bool isIntialize
        {
            get => _isInitialize;
        }

        tweliteData TweliteData
        {
            get => _TweliteData;
        }

        public twelite(string com)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;
                _com = com;
                _port = new SerialPort(_com, 115200, Parity.None, 8);
                _port.DataReceived += new SerialDataReceivedEventHandler(rcv);
                _port.Open();
                _TweliteData = new tweliteData();
                _TweliteData.中継機シリアルID = 10;

            }
        }
        ~twelite()
        {
            if (_port.IsOpen) { _port.Close(); }
        }
        void IDisposable.Dispose()
        {
            if (_port.IsOpen) { _port.Close(); }
        }
        private void rcv(object sender, SerialDataReceivedEventArgs e)
        {
            // System.Threading.Thread.Sleep(2000);
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();
            Debug.WriteLine("Data Received:");
            //string indata = sp.ReadExisting();
            if (indata.StartsWith(":") == false) return;

            Debug.WriteLine(indata);
            Debug.WriteLine("indata Length=" + indata.Length);
            if (indata.Length != 300) return;
            //CRC8
            byte crc = 0;
            byte crc8 = 0x31;
            for (int j = 1; j < 295; j = j + 2)
            {
                crc ^= Convert.ToByte(indata.Substring(j, 2), 16);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x80) > 0)
                    {
                        crc <<= 1; crc ^= crc8;
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }
            Debug.WriteLine("CRC CHECK " + indata.Substring(295, 2) + " :" + crc.ToString("x2"));
            if (Convert.ToByte(indata.Substring(295, 2), 16) != crc) return;
            //LRC
            byte lrc = 0;
            for (int j = 1; j < 297; j = j + 2)
            {
                lrc += Convert.ToByte(indata.Substring(j, 2), 16);
            }
            lrc = (byte)(~lrc);
            lrc += 1;
            Debug.WriteLine("LRC CHECK " + indata.Substring(297, 2) + " :" + lrc.ToString("x2"));
            if (Convert.ToByte(indata.Substring(297, 2), 16) != lrc) return;

            _TweliteData.中継機シリアルID = Convert.ToUInt32(indata.Substring(1, 8), 16);
            //Debug.WriteLine("中継機シリアルID=" + _TweliteData.中継機シリアルID.ToString("x8")); 
            _TweliteData.LQI = Convert.ToByte(indata.Substring(9, 2), 16);
            //Debug.WriteLine("LQI=" + _TweliteData.LQI.ToString("x2"));
            _TweliteData.続き番号 = Convert.ToUInt16(indata.Substring(11, 4), 16);
            //Debug.WriteLine("続き番号=" + _TweliteData.続き番号.ToString("x4"));
            _TweliteData.送信元シリアルID = Convert.ToUInt32(indata.Substring(15, 8), 16);
            //Debug.WriteLine("送信元シリアルID=" + _TweliteData.送信元シリアルID.ToString("x8"));
            _TweliteData.送信元LID = Convert.ToByte(indata.Substring(23, 2), 16);
            //Debug.WriteLine("送信元LID=" + _TweliteData.送信元LID.ToString("x2"));
            _TweliteData.センサー種別 = Convert.ToByte(indata.Substring(25, 2), 16);
            //Debug.WriteLine("センサー種別=" + _TweliteData.センサー種別.ToString("x2"));
            _TweliteData.PAL_IDとPAL_Ver = Convert.ToByte(indata.Substring(27, 2), 16);
            Debug.WriteLine("PAL IDとPAL Ver=" + _TweliteData.PAL_IDとPAL_Ver.ToString("x2"));
            _TweliteData.センサーデータ数 = Convert.ToByte(indata.Substring(29, 2), 16);
            Debug.WriteLine("センサーデータ数=" + _TweliteData.センサーデータ数.ToString("x2"));

            //センサーデータ0
            if (_TweliteData.センサーデータ数 > 0)
            {
                _TweliteData.センサーデータ0.各種情報ビット値 = Convert.ToByte(indata.Substring(31, 2), 16);
                Debug.WriteLine("センサーデータ0.各種情報ビット値" + _TweliteData.センサーデータ0.各種情報ビット値.ToString("x2"));
                _TweliteData.センサーデータ0.データソース = Convert.ToByte(indata.Substring(33, 2), 16);
                Debug.WriteLine("センサーデータ0.データソース" + _TweliteData.センサーデータ0.データソース.ToString("x2"));
                _TweliteData.センサーデータ0.拡張バイト = Convert.ToByte(indata.Substring(35, 2), 16);
                Debug.WriteLine("センサーデータ0.拡張バイト" + _TweliteData.センサーデータ0.拡張バイト.ToString("x2"));
                _TweliteData.センサーデータ0.データ長 = Convert.ToByte(indata.Substring(37, 2), 16);
                Debug.WriteLine("センサーデータ0.データ長" + _TweliteData.センサーデータ0.データ長.ToString("x2"));
                _TweliteData.センサーデータ0.パケットID = Convert.ToByte(indata.Substring(39, 2), 16);
                Debug.WriteLine("センサーデータ0.パケットID" + _TweliteData.センサーデータ0.パケットID.ToString("x2"));
                _TweliteData.センサーデータ0.起床要因センサー = (twelite_cue_起床要因センサー)Convert.ToByte(indata.Substring(41, 2), 16);
                Debug.WriteLine("センサーデータ0.起床要因センサー" + _TweliteData.センサーデータ0.起床要因センサー.ToString());// "x2"));
                _TweliteData.センサーデータ0.起床要因 = (twelite_cue_起床要因)Convert.ToByte(indata.Substring(43, 2), 16);
                Debug.WriteLine("センサーデータ0.起床要因" + _TweliteData.センサーデータ0.起床要因.ToString());// "x2"));
            }
            //センサーデータ1
            if (_TweliteData.センサーデータ数 > 1)
            {
                _TweliteData.センサーデータ1.各種情報ビット値 = Convert.ToByte(indata.Substring(45, 2), 16);
                Debug.WriteLine("センサーデータ1.各種情報ビット値" + _TweliteData.センサーデータ1.各種情報ビット値.ToString("x2"));
                _TweliteData.センサーデータ1.データソース = Convert.ToByte(indata.Substring(47, 2), 16);
                Debug.WriteLine("センサーデータ1.データソース" + _TweliteData.センサーデータ1.データソース.ToString("x2"));
                _TweliteData.センサーデータ1.拡張バイト = Convert.ToByte(indata.Substring(49, 2), 16);
                Debug.WriteLine("センサーデータ1.拡張バイト" + _TweliteData.センサーデータ1.拡張バイト.ToString("x2"));
                Byte temp = (byte)((byte)0x7F & _TweliteData.センサーデータ1.拡張バイト);
                _TweliteData.センサーデータ1.イベントの発生要因 = (twe_lite_cue_event_イベントの発生要因)temp;
                Debug.WriteLine("センサーデータ1.イベントの発生要因" + _TweliteData.センサーデータ1.イベントの発生要因.ToString());// "x2"));
                _TweliteData.センサーデータ1.データ長 = Convert.ToByte(indata.Substring(51, 2), 16);
                Debug.WriteLine("センサーデータ1.データ長" + _TweliteData.センサーデータ1.データ長.ToString("x2"));
                _TweliteData.センサーデータ1.データ1 = Convert.ToByte(indata.Substring(53, 2), 16);
                Debug.WriteLine("センサーデータ1.データ1" + _TweliteData.センサーデータ1.データ1.ToString("x2"));
                /**
                   イベント発生要因が磁気センサーの場合
                      0x00(0):近くに磁石がない
                      0x01(1):磁石のN極が近くにある
                      0x02(2):磁石のS極が近くにある
​
                   イベント発生要因が加速度の場合
                      0x01(1)～0x06(6)：さいころ
                      0x08(8)：シェイク
                      0x10(16)：ムーブ
                **/
                _TweliteData.センサーデータ1.データ2 = Convert.ToInt32(indata.Substring(55, 6), 16);
                Debug.WriteLine("センサーデータ1.データ2" + _TweliteData.センサーデータ1.データ2.ToString("x2"));
            }
            //センサーデータ2 電源電圧
            if (_TweliteData.センサーデータ数 > 2)
            {
                _TweliteData.センサーデータ2_ヘッダ = 0x11300802;//Header4Byteは固定 2バイト、拡張ビット有 電圧(電源電圧)
                _TweliteData.センサーデータ2 = Convert.ToUInt16(indata.Substring(69, 4), 16);
                //Debug.WriteLine("センサーデータ2(電源電圧)" + _TweliteData.センサーデータ2.ToString("x4"));
                _TweliteData.電源電圧mV = (Single)_TweliteData.センサーデータ2;
                Debug.WriteLine("電源電圧" + _TweliteData.電源電圧mV + "[mV]");
            }
            //センサーデータ3　ADC1
            if (_TweliteData.センサーデータ数 > 3)
            {
                _TweliteData.センサーデータ3_ヘッダ = 0x11300102;//Header4Byteは固定　2バイト、拡張ビット有　電圧(ADC1)
                _TweliteData.センサーデータ3 = Convert.ToUInt16(indata.Substring(81, 4), 16);
                _TweliteData.ADC1mV = (Single)_TweliteData.センサーデータ3;
                Debug.WriteLine("ADC1" + _TweliteData.ADC1mV + "[mV]");
            }
            //センサーデータ4　ホールIC
            if (_TweliteData.センサーデータ数 > 4)
            {
                _TweliteData.センサーデータ4_ヘッダ = 0x00000001;//Header4Byteは固定　1バイト拡張ビットなし
                _TweliteData.センサーデータ4 = Convert.ToByte(indata.Substring(93, 2), 16);
                _TweliteData.磁気センサー = (twe_lite_cue_磁石)(_TweliteData.センサーデータ4 & 0x7f);
                Debug.WriteLine("磁気センサー" + _TweliteData.磁気センサー);
            }
            //センサーデータ5　加速度(1サンプル目)
            if (_TweliteData.センサーデータ数 > 5)
            {
                //Header4Byteは固定　符号あり2バイト、拡張ビット有
                //センサーデータ2(ヘッダ)　95，8  
                _TweliteData.センサーデータ5_ヘッダ = 0x15044006;
                _TweliteData.センサーデータ5_X軸 = Convert.ToInt16(indata.Substring(103, 4), 16);
                _TweliteData.センサーデータ5_Y軸 = Convert.ToInt16(indata.Substring(107, 4), 16);
                _TweliteData.センサーデータ5_Z軸 = Convert.ToInt16(indata.Substring(111, 4), 16);
                Debug.WriteLine("センサーデータ5=" + _TweliteData.センサーデータ5_X軸 + "," +
                    _TweliteData.センサーデータ5_Y軸 + "," +
                    _TweliteData.センサーデータ5_Z軸 + "(" +
                    _TweliteData.センサーデータ5_X軸.ToString("x4")
                    + "," + _TweliteData.センサーデータ5_Y軸.ToString("x4") + "," +
                    _TweliteData.センサーデータ5_Z軸.ToString("x4") + ")");
            }
            //センサーデータ6　加速度(2サンプル目)
            if (_TweliteData.センサーデータ数 > 6)
            {
                _TweliteData.センサーデータ6_ヘッダ = 0x15044006; //Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ6_X軸 = Convert.ToInt16(indata.Substring(123, 4), 16);
                _TweliteData.センサーデータ6_Y軸 = Convert.ToInt16(indata.Substring(127, 4), 16);
                _TweliteData.センサーデータ6_Z軸 = Convert.ToInt16(indata.Substring(131, 4), 16);
                Debug.WriteLine("センサーデータ6=" + _TweliteData.センサーデータ6_X軸 + "," +
                   _TweliteData.センサーデータ6_Y軸 + "," + _TweliteData.センサーデータ6_Z軸);
            }
            //センサーデータ7　加速度(3サンプル目)
            if (_TweliteData.センサーデータ数 > 7)
            {
                _TweliteData.センサーデータ7_ヘッダ = 0x15044006;//Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ7_X軸 = Convert.ToInt16(indata.Substring(143, 4), 16);
                _TweliteData.センサーデータ7_Y軸 = Convert.ToInt16(indata.Substring(147, 4), 16);
                _TweliteData.センサーデータ7_Z軸 = Convert.ToInt16(indata.Substring(151, 4), 16);
                Debug.WriteLine("センサーデータ7=" + _TweliteData.センサーデータ7_X軸 + "," +
                  _TweliteData.センサーデータ7_Y軸 + "," + _TweliteData.センサーデータ7_Z軸);
            }
            //センサーデータ8　加速度(4サンプル目)
            if (_TweliteData.センサーデータ数 > 8)
            {
                _TweliteData.センサーデータ8_ヘッダ = 0x15044006;//Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ8_X軸 = Convert.ToInt16(indata.Substring(163, 4), 16);
                _TweliteData.センサーデータ8_Y軸 = Convert.ToInt16(indata.Substring(167, 4), 16);
                _TweliteData.センサーデータ8_Z軸 = Convert.ToInt16(indata.Substring(171, 4), 16);
                Debug.WriteLine("センサーデータ8=" + _TweliteData.センサーデータ8_X軸 + "," +
                  _TweliteData.センサーデータ8_Y軸 + "," + _TweliteData.センサーデータ8_Z軸);
            }
            //センサーデータ9　加速度(5サンプル目)
            if (_TweliteData.センサーデータ数 > 9)
            {
                _TweliteData.センサーデータ9_ヘッダ = 0x15044006; //Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ9_X軸 = Convert.ToInt16(indata.Substring(183, 4), 16);
                _TweliteData.センサーデータ9_Y軸 = Convert.ToInt16(indata.Substring(187, 4), 16);
                _TweliteData.センサーデータ9_Z軸 = Convert.ToInt16(indata.Substring(191, 4), 16);
                Debug.WriteLine("センサーデータ9=" + _TweliteData.センサーデータ9_X軸 + "," +
                  _TweliteData.センサーデータ9_Y軸 + "," + _TweliteData.センサーデータ9_Z軸);
            }
            //センサーデータ10　加速度(6サンプル目)
            if (_TweliteData.センサーデータ数 > 10)
            {
                _TweliteData.センサーデータ10_ヘッダ = 0x15044006;//Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ10_X軸 = Convert.ToInt16(indata.Substring(203, 4), 16);
                _TweliteData.センサーデータ10_Y軸 = Convert.ToInt16(indata.Substring(207, 4), 16);
                _TweliteData.センサーデータ10_Z軸 = Convert.ToInt16(indata.Substring(211, 4), 16);
                Debug.WriteLine("センサーデータ10=" + _TweliteData.センサーデータ10_X軸 + "," +
                  _TweliteData.センサーデータ10_Y軸 + "," + _TweliteData.センサーデータ10_Z軸);
            }
            //センサーデータ11　加速度(7サンプル目)
            if (_TweliteData.センサーデータ数 > 11)
            {
                _TweliteData.センサーデータ11_ヘッダ = 0x15044006;  //Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ11_X軸 = Convert.ToInt16(indata.Substring(223, 4), 16);
                _TweliteData.センサーデータ11_Y軸 = Convert.ToInt16(indata.Substring(227, 4), 16);
                _TweliteData.センサーデータ11_Z軸 = Convert.ToInt16(indata.Substring(231, 4), 16);
                Debug.WriteLine("センサーデータ11=" + _TweliteData.センサーデータ11_X軸 + "," +
                  _TweliteData.センサーデータ11_Y軸 + "," + _TweliteData.センサーデータ11_Z軸);
            }
            //センサーデータ12　加速度(8サンプル目)
            if (_TweliteData.センサーデータ数 > 12)
            {
                _TweliteData.センサーデータ12_ヘッダ = 0x15044006; //Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ12_X軸 = Convert.ToInt16(indata.Substring(243, 4), 16);
                _TweliteData.センサーデータ12_Y軸 = Convert.ToInt16(indata.Substring(247, 4), 16);
                _TweliteData.センサーデータ12_Z軸 = Convert.ToInt16(indata.Substring(251, 4), 16);
                Debug.WriteLine("センサーデータ12=" + _TweliteData.センサーデータ12_X軸 + "," +
                  _TweliteData.センサーデータ12_Y軸 + "," + _TweliteData.センサーデータ12_Z軸);
            }
            //センサーデータ13　加速度(9サンプル目)
            if (_TweliteData.センサーデータ数 > 13)
            {
                _TweliteData.センサーデータ13_ヘッダ = 0x15044006; //Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ13_X軸 = Convert.ToInt16(indata.Substring(263, 4), 16);
                _TweliteData.センサーデータ13_Y軸 = Convert.ToInt16(indata.Substring(267, 4), 16);
                _TweliteData.センサーデータ13_Z軸 = Convert.ToInt16(indata.Substring(271, 4), 16);
                Debug.WriteLine("センサーデータ13=" + _TweliteData.センサーデータ13_X軸 + "," +
                  _TweliteData.センサーデータ13_Y軸 + "," + _TweliteData.センサーデータ13_Z軸);
            }
            //センサーデータ14　加速度(10サンプル目)
            if (_TweliteData.センサーデータ数 > 14)
            {
                _TweliteData.センサーデータ14_ヘッダ = 0x15044006;//Header4Byteは固定　符号あり2バイト、拡張ビット有
                _TweliteData.センサーデータ14_X軸 = Convert.ToInt16(indata.Substring(283, 4), 16);
                _TweliteData.センサーデータ14_Y軸 = Convert.ToInt16(indata.Substring(287, 4), 16);
                _TweliteData.センサーデータ14_Z軸 = Convert.ToInt16(indata.Substring(291, 4), 16);
                Debug.WriteLine("センサーデータ14=" + _TweliteData.センサーデータ14_X軸 + "," +
                  _TweliteData.センサーデータ14_Y軸 + "," + _TweliteData.センサーデータ14_Z軸);
            }
            DataRcvEventArgs args = new DataRcvEventArgs();
            args.RcvData = _TweliteData;
            OnDataRcv(args);
        }
        protected virtual void OnDataRcv(DataRcvEventArgs e)
        {
            EventHandler<DataRcvEventArgs> handler = DataRcv;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<DataRcvEventArgs> DataRcv;
    }
    public class DataRcvEventArgs : EventArgs
    {
        public tweliteData RcvData { get; set; }
    }
}
