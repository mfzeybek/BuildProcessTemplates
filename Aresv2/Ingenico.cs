using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Aresv2
{
    public class Ingenico
    {
        #region degiskenler
        public delegate void dlgInvoke();
        public delegate void dlgYaz(string data);


        SerialPort port = new SerialPort();
        List<byte> readBuffer = new List<byte>();

        bool IsBekleniyor;
        MessageFlow messageflow;
        TextBox textboxlog = null;
        int beklenendata = 0;
        bool started;

        dlgInvoke del;
        dlgYaz yaz;


        string gelenData;
        string[] gelendatalist;
        MessageType beklenenmesajtype;
        int authreqsendcount = 0;
        #endregion

        #region constructor

        public Ingenico(string portno, int baudrate)
        {

            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            del = ActionTamData;
            yaz = ActionYaz;






            port.PortName = portno;
            port.BaudRate = baudrate;
            //port.DataBits = 8;
            //port.StopBits = StopBits.One;
            //port.Parity = Parity.None;
            //port.RtsEnable = true;
            //port.Handshake = Handshake.None;
            //port.ReadTimeout = 500;


            IsBekleniyor = true;

            beklenenmesajtype = MessageType.InfoMessage;


        }

        public Ingenico(string portno, int baudrate, TextBox _text)
            : this(portno, baudrate)
        {
            textboxlog = _text;

        }

        #endregion

        #region port open close
        public void PortClose()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }
        public void PortOpen()
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
        }

        #endregion

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {


            //okunacak data varsa oku
            while (port.BytesToRead > 0)
            {
                int indata = port.ReadByte();
                //yaz("Akış:"+indata.ToString());


                switch (beklenenmesajtype)
                {
                    case MessageType.InfoMessage:

                        if (indata == (int)SpecificChar.STX)//gelen data stx mi
                        {
                            yaz("info mesaj alınmaya başladı");
                            started = true;
                            readBuffer.Add((byte)indata);
                        }
                        else if (started && indata == (int)SpecificChar.ETX)
                        {
                            readBuffer.Add((byte)indata);

                            //auth response içinde 03'ler olabilir etx i garanti altına almak için
                            if (readBuffer.Count() > 30)
                            {

                                started = false;
                                indata = port.ReadByte(); //lrc
                                readBuffer.Add((byte)indata);
                                //
                                del();

                                if (readBuffer.Count > 0) readBuffer = new List<byte>();
                            }
                        }
                        else if (started) readBuffer.Add((byte)indata);
                        break;
                    case MessageType.AuthorizationRequest:
                        if (indata == (int)SpecificChar.ACK)
                        {
                            yaz("ack alındı");
                            beklenenmesajtype = MessageType.AuthorizationResponse;
                            del();
                        }
                        else
                        {
                            if (indata == 21)
                            {
                                yaz("nak alındı");
                            }
                            if (authreqsendcount < 3)
                            {
                                yaz(indata.ToString());
                                SendAuthorizationRequest();

                            }
                            else
                            {
                                if (indata == (int)SpecificChar.EOT)
                                {
                                    EOTGeldi();
                                }
                                else
                                {
                                    yaz("SendAuthorizationRequest 3 kez gönderildi sonuca ulaşılamadı eot gönderiliyor");
                                    SendEOT();
                                }
                            }

                        }
                        break;
                    case MessageType.AuthorizationResponse:

                        if (indata == (int)SpecificChar.STX)//gelen data stx mi
                        {
                            yaz("Authoriztion Response alınmaya başladı");
                            started = true;
                            readBuffer.Add((byte)indata);
                        }
                        else if (started && indata == (int)SpecificChar.ETX)
                        {
                            readBuffer.Add((byte)indata);

                            //auth response içinde 03'ler olabilir etx i garanti altına almak için
                            if (readBuffer.Count() > 80)
                            {
                                started = false;

                                del();

                                if (readBuffer.Count > 0) readBuffer = new List<byte>();
                            }
                        }
                        else if (started) readBuffer.Add((byte)indata);
                        break;
                    case MessageType.EOT:
                        EOTGeldi();
                        break;
                    default:
                        break;
                }






            }

        }

        private void EOTGeldi()
        {
            yaz("eot geldi");

        }

        private void SendEOT()
        {
            yaz("EOT sended");
            port.Write(((char)SpecificChar.EOT).ToString());
            Thread.Sleep(50);


        }


        private void ActionTamData()
        {
            MessageType gelenmesajtype = 0;

            gelenData = BitConverter.ToString(readBuffer.ToArray());

            gelendatalist = gelenData.Split('-');


            //3. eleman messageId olduğundan direk oraya bakıp mesaj tipini alacağım
            if (gelendatalist.Length >= 3)
            {
                gelenmesajtype = (MessageType)Convert.ToInt32(gelendatalist[3]);
            }


            if (gelenmesajtype == beklenenmesajtype)
            {

                switch (gelenmesajtype)
                {
                    case MessageType.InfoMessage:
                        yaz(gelenData);
                        yaz("info mesaj alındı.");
                        if (ParseInfoMessage(gelendatalist))
                        {
                            SendACK();
                            SendAuthorizationRequest();

                            beklenenmesajtype = MessageType.AuthorizationRequest;

                        }
                        else
                        {
                            yaz("NAK sended");
                            SendNAK();
                        }
                        break;

                    case MessageType.AuthorizationResponse:
                        yaz(gelenData);
                        yaz("AuthorizationResponse alındı.");
                        if (ParseAuthorizationResponse(gelendatalist).AuthorisationNumber != "")
                        {
                            SendACK();
                            beklenenmesajtype = MessageType.EOT;
                        }
                        else
                        {
                            SendNAK();
                        }
                        break;
                    default:
                        break;
                }
            }




        }

        private void ActionYaz(string data)
        {
            if (textboxlog == null) return;

            textboxlog.BeginInvoke(new Action(delegate
            {
                textboxlog.AppendText(data + "\n");
            }));

        }

        #region SendAuthorizationRequest ve yardımcı fonksiyonlar
        private void SendAuthorizationRequest()
        {

            yaz("AuthorizationRequest hazırlanıyor");
            byte[] req2 = new byte[100];

            //STX
            req2[0] = 0x02;

            //Message Len
            req2[1] = Convert.ToByte(0);
            req2[2] = Convert.ToByte(150);

            //Message ID
            req2[3] = Convert.ToByte(145);

            //trans type
            req2[4] = Convert.ToByte(0);

            //card input type
            req2[5] = 0x03;

            //card data
            //for (int i = 1; i < 40; i++)
            //{
            //    req2[i + 5] = Convert.ToByte(48);
            //}

            //byte[] a = new System.Text.ASCIIEncoding().GetBytes("123456789011223344552244668800113355779922");

            //for (int i = 0; i < a.Length; i++)
            //    req2[i + 6] = a[i];



            //currency type
            req2[6] = 0x04;

            //currency digits
            req2[7] = 0x02;

            //spend amount
            //string stramount = "00000123";
            //var a1 = new System.Text.UTF8Encoding().GetBytes("00000123");
            byte[] a1 = new byte[] { 0, 0, 0, 0, 0, 0, 0, 3 };

            for (int i = 0; i < a1.Length; i++)
            {
                req2[i + 8] = Convert.ToByte(a1[i]);
            }


            //spent bonus
            for (int i = 1; i < 8; i++)
            {
                req2[i + 15] = 0;
            }


            //Gained bonus
            for (int i = 1; i < 8; i++)
            {
                req2[i + 23] = 0;
            }


            //STAN
            for (int i = 1; i < 3; i++)
            {
                req2[i + 71] = 0;
            }

            //Auth number
            //for (int i = 1; i < 6; i++)
            //{
            //    req2[i + 74] = 48;
            //}

            byte[] a2 = new System.Text.ASCIIEncoding().GetBytes("000000");

            for (int i = 0; i < a2.Length; i++)
                req2[i + 72] = a2[i];




            //Installament count
            req2[81] = 0;

            //Installament number
            req2[82] = 0;

            //Installament amount
            for (int i = 1; i < 8; i++)
            {
                req2[i + 82] = 0;
            }

            //Installament gained bonus
            for (int i = 1; i < 8; i++)
            {
                req2[i + 90] = 0;
            }

            //ETX
            req2[99] = 0x03;




            var req3 = GetLRC(req2);

            var straut = BitConverter.ToString(req3);

            yaz(straut);
            yaz((authreqsendcount + 1).ToString() + "-Auth request yazıldı");

            ConfirmedWrite(req3);
            authreqsendcount++;
        }

        private byte[] GetLRC(byte[] b)
        {
            byte[] ret = new byte[b.Length + 1];
            ret[0] = b[0]; // STX
            byte lrc = 0;
            for (int i = 1; i < b.Length; i++)
            {
                lrc ^= b[i];
                ret[i] = b[i];
            }
            ret[b.Length] = lrc;

            return ret;
        }

        private byte[] last_message;

        private void ConfirmedWrite(byte[] b)
        {

            while (last_message != null)
                Thread.Sleep(20);

            Thread.Sleep(40);
            last_message = b;
            ByteWrite(b);
        }

        private void ByteWrite(byte[] b)
        {
            port.Write(b, 0, b.Length);
        }
        #endregion


        private void SendNAK()
        {
            Thread.Sleep(50);
            yaz("NAK sended");
            port.Write(((char)SpecificChar.NAK).ToString());
            Thread.Sleep(50);

        }

        private void SendACK()
        {
            Thread.Sleep(200);
            yaz("Ack sended");
            port.Write(((char)SpecificChar.ACK).ToString());
            Thread.Sleep(50);


        }

        private bool ParseInfoMessage(string[] gelendatalist)
        {
            //todo

            return true;
        }

        private AuthorizationResponse ParseAuthorizationResponse(string[] gelendatalist)
        {
            //todo

            string responsedesc = "";
            for (int i = 1; i < 20; i++)
            {
                responsedesc += gelendatalist[i + 6];
            }

            string responseauthnumber = "";
            for (int i = 1; i < 6; i++)
            {
                responseauthnumber += gelendatalist[i + 26];
            }

            string responsecardnumber = "";
            for (int i = 1; i < 20; i++)
            {
                responsecardnumber += gelendatalist[i + 50];
            }


            AuthorizationResponse response = new AuthorizationResponse()
            {
                MessageLen = gelendatalist[2],
                MessageID = gelendatalist[3],
                TransType = gelendatalist[4],
                ResponseCode = System.Text.Encoding.UTF8.GetString(ConvertHexStringToByteArray(gelendatalist[5] + gelendatalist[6])),
                ResponseDescription = System.Text.Encoding.UTF8.GetString(ConvertHexStringToByteArray(responsedesc)),
                AuthorisationNumber = System.Text.Encoding.UTF8.GetString(ConvertHexStringToByteArray(responseauthnumber)),
                AuthorisationAmount = gelendatalist[33] + gelendatalist[34] + gelendatalist[35] + gelendatalist[36] + gelendatalist[37] + gelendatalist[38] + gelendatalist[39] + gelendatalist[40],
                UsedBonus = gelendatalist[41] + gelendatalist[42] + gelendatalist[43] + gelendatalist[44] + gelendatalist[45] + gelendatalist[46] + gelendatalist[47] + gelendatalist[48],
                InstallmentCount = gelendatalist[49],
                TransactionFlag = gelendatalist[50],
                CardNumber = System.Text.Encoding.UTF8.GetString(ConvertHexStringToByteArray(responsecardnumber))
            };


            yaz(response.ResponseDescription + "\n");
            yaz("Provizyon:" + response.AuthorisationNumber + "\n");
            yaz("Tutar:" + response.AuthorisationAmount + "\n");
            yaz("Bonus:" + response.UsedBonus + "\n");
            yaz("Kart:" + response.CardNumber + "\n");
            yaz("Taksit:" + response.InstallmentCount + "\n");

            return response;
        }
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }




    }


    public enum MesajYonu
    {
        bekleniyor,
        gonderiliyor
    }

    public enum MessageType
    {

        InfoMessage = 89,
        AuthorizationRequest = 91,
        AuthorizationResponse = 92,
        EOT = 15

    }


    public enum MessageFlow
    {
        Start = 0,
        PosToKasaInfoMessage,
        KasaToPosACKorNAK,
        KasaToPosAuthorizationRequest,
        PosToKasaACKorNAK,
        PosToKasaAuthorizationResponse,
        KasaToPosACKorNAK2,
        PosToKasaEOT
    }

    public enum SpecificChar
    {
        STX = 0x02,
        ETX = 0x03,
        EOT = 0x04,
        ACK = 0x06,
        NAK = 0x15
    }


    class AuthorizationResponse
    {
        public string MessageLen { get; set; }
        public string MessageID { get; set; }
        public string TransType { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string AuthorisationNumber { get; set; }
        public string AuthorisationAmount { get; set; }
        public string UsedBonus { get; set; }
        public string InstallmentCount { get; set; }
        public string TransactionFlag { get; set; }
        public string CardNumber { get; set; }
        public string TerminalID { get; set; }
        public string BatchNumber { get; set; }
        public string SystemTraceNumber { get; set; }

    }
}

