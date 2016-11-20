using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using Ozeki.Network.Nat;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;

namespace Aresv2.SoftPhone
{
	public partial class frmNetTelefonv2 : DevExpress.XtraEditors.XtraForm
	{
		public frmNetTelefonv2(string TelefonNo)
		{
			InitializeComponent();
			_TelefonNo = TelefonNo;
		}

		string _TelefonNo = "";

		ISoftPhone softPhone;
		IPhoneLine phoneLine;
        ////////////PhoneLineState phoneLineInformation;
		IPhoneCall call;
		Microphone microphone = Microphone.GetDefaultDevice();
		Speaker speaker = Speaker.GetDefaultDevice();
		MediaConnector connector = new MediaConnector();
		PhoneCallAudioSender mediaSender = new PhoneCallAudioSender();
		PhoneCallAudioReceiver mediaReceiver = new PhoneCallAudioReceiver();
		bool inComingCall;

		private void frmNetTelefonv2_Load(object sender, EventArgs e)
		{
			InitializeSoftPhone();
			labelDialingNumber.Text = _TelefonNo;
		}

		#region Ozeki VoIP-SIP SDK's events

		/// <summary>
		/// Hattın durumunun değiştiği zaman çalışan fonksiyon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        ////////////private void phoneLine_PhoneLineInformation(object sender, VoIPEventArgs<PhoneLineState> e)
        ////////////{
        ////////////    phoneLineInformation = e.Item;
        ////////////    InvokeGUIThread(() =>
        ////////////    {
        ////////////        labelIdentifier.Text = ((IPhoneLine)sender).SIPAccount.RegisterName;
        ////////////        if (e.Item == PhoneLineState.RegistrationSucceeded)
        ////////////        {
        ////////////            labelRegStatus.Text = "Online";
        ////////////            labelCallStateInfo.Text = "Kayıt Başarılı.";
        ////////////        }
        ////////////        else
        ////////////            labelCallStateInfo.Text = e.Item.ToString();
        ////////////    });
        ////////////}

		/// <summary>
		/// Çağrı geldiği zaman çalışır.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void softPhone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
		{
			InvokeGUIThread(() =>
			{
				labelCallStateInfo.Text = "Incoming call";
				labelDialingNumber.Text = String.Format("from {0}", e.Item.DialInfo);
				call = e.Item;
				WireUpCallEvents();
				inComingCall = true;
			});
		}

		/// <summary>
		/// Occurs when the phone call state has changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void call_CallStateChanged(object sender, VoIPEventArgs<CallState> e)
		{
			InvokeGUIThread(() => { labelCallStateInfo.Text = e.Item.ToString(); });

			switch (e.Item)
			{
				case CallState.InCall:
					if (microphone != null)
						microphone.Start();
					connector.Connect(microphone, mediaSender);

					if (speaker != null)
						speaker.Start();
					connector.Connect(mediaReceiver, speaker);

					mediaSender.AttachToCall(call);
					mediaReceiver.AttachToCall(call);

					break;
				case CallState.Completed:
					if (microphone != null)
						microphone.Stop();
					connector.Disconnect(microphone, mediaSender);
					if (speaker != null)
						speaker.Stop();
					connector.Disconnect(mediaReceiver, speaker);

					mediaSender.Detach();
					mediaReceiver.Detach();

					WireDownCallEvents();
					call = null;

					InvokeGUIThread(() => { labelDialingNumber.Text = string.Empty; });
					break;
				case CallState.Cancelled:
					WireDownCallEvents();
					call = null;
					break;
			}
		}

		/// <summary>
		/// Displays DTMF signals
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void call_DtmfReceived(object sender, VoIPEventArgs<DtmfInfo> e)
		{
			DtmfInfo dtmfInfo = e.Item;

			InvokeGUIThread(() =>
			{
				labelCallStateInfo.Text = String.Format("DTMF signal received: {0} ", dtmfInfo.Signal.Signal);
			});
		}

		/// <summary>
		/// There are certain situations when the call cannot be created, for example the dialed number is not available 
		/// or maybe there is no endpoint to the dialed PBX, or simply the telephone line is busy. 
		/// This event handling is for displaying these events.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void call_CallErrorOccured(object sender, VoIPEventArgs<CallError> e)
		{
			InvokeGUIThread(() =>
			{
				//labelCallStateInfo.Text = e.Item.ToString();
			});
		}

		#endregion

		#region Helper Functions
		/// <summary>
		///It initializes a softphone object with a SIP BPX, and it is for requisiting a SIP account that is nedded for a SIP PBX service. It registers this SIP
		///account to the SIP PBX through an ’IphoneLine’ object which represents the telephoneline. 
		///If the telephone registration is successful we have a call ready softphone. In this example the softphone can be reached by dialing the number 891.
		/// </summary>
		private void InitializeSoftPhone()
		{
			try
			{
				softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750, 5700);
				softPhone.IncomingCall += new EventHandler<VoIPEventArgs<IPhoneCall>>(softPhone_IncomingCall); // arama geldiğinde çalışan fonksiyon.
				phoneLine = softPhone.CreatePhoneLine(new SIPAccount(true, frmKullaniciGiris.DisplayName, frmKullaniciGiris.UserName, frmKullaniciGiris.RegisterName, frmKullaniciGiris.RegisterPassword, frmKullaniciGiris.DomainServerHost, Convert.ToInt32(frmKullaniciGiris.DomainServerPort)), new NatConfiguration(NatTraversalMethod.None));
				//phoneLine = softPhone.CreatePhoneLine(new SIPAccount(true, "7134", "7134", "7134", "123456", "sip.kobikom.com", 5060), new NatConfiguration(NatTraversalMethod.None));
				//phoneLine = softPhone.CreatePhoneLine(new SIPAccount(true, "oz875", "oz875", "oz875", "oz875", "192.168.112.100", 5060), new NatConfiguration(NatTraversalMethod.None));
				phoneLine.PhoneLineStateChanged += new EventHandler<VoIPEventArgs<PhoneLineState>>(phoneLine_PhoneLineInformation);

				softPhone.RegisterPhoneLine(phoneLine);
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("You didn't give your local IP adress, so the program won't run properly.\n {0}", ex.Message), string.Empty, MessageBoxButtons.OK,
				MessageBoxIcon.Error);

				var sb = new StringBuilder();
				sb.AppendLine("Some error happened.");
				sb.AppendLine();
				sb.AppendLine("Exception:");
				sb.AppendLine(ex.Message);
				sb.AppendLine();
				if (ex.InnerException != null)
				{
					sb.AppendLine("Inner Exception:");
					sb.AppendLine(ex.InnerException.Message);
					sb.AppendLine();
				}
				sb.AppendLine("StackTrace:");
				sb.AppendLine(ex.StackTrace);

				MessageBox.Show(sb.ToString());
			}
		}

		/// <summary>
		///  It signs up to the necessary events of a call transact.
		/// </summary>
		private void WireUpCallEvents()
		{
			call.CallStateChanged += (call_CallStateChanged);
			call.DtmfReceived += (call_DtmfReceived);
			call.CallErrorOccured += (call_CallErrorOccured);
		}

		/// <summary>
		/// It signs down from the necessary events of a call transact.
		/// </summary>
		private void WireDownCallEvents()
		{
			if (call != null)
			{
				call.CallStateChanged -= (call_CallStateChanged);
				call.DtmfReceived -= (call_DtmfReceived);
				call.CallErrorOccured -= (call_CallErrorOccured);
			}
		}

		/// <summary>
		/// The controls of the Windows Form applications can only be modified on the GUI thread. This method grants access to the GUI thread.
		/// </summary>
		/// <param name="action"></param>
		private void InvokeGUIThread(Action action)
		{
			Invoke(action);
		}
		#endregion

		/// <summary>
		/// It starts a call with the dialed number or in case of an incoming call it accepts, picks up the call.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAramaYap_Click(object sender, EventArgs e)
		{
			if (inComingCall)
			{
				inComingCall = false;
                ////////////call.Accept();
				return;
			}

			if (call != null)
				return;

			if (string.IsNullOrEmpty(labelDialingNumber.Text))
				return;

            ////////////if (phoneLineInformation != PhoneLineState.RegistrationSucceeded && phoneLineInformation != PhoneLineState.NoRegNeeded)
            ////////////{
            ////////////    MessageBox.Show("Telefon hattı açılamadı.");
            ////////////    return;
            ////////////}

			call = softPhone.CreateCallObject(phoneLine, labelDialingNumber.Text);
			WireUpCallEvents();
			call.Start();
		}

		/// <summary>
		/// In case a call is in progress, it breaks the call.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBitir_Click(object sender, EventArgs e)
		{
			if (call != null)
			{
				if (inComingCall && call.CallState == CallState.Ringing)
					call.Reject();
				else
					call.HangUp();
				inComingCall = false;
				call = null;
			}
			labelDialingNumber.Text = string.Empty;
			this.Dispose();
		}

		private void frmNetTelefonv2_FormClosed(object sender, FormClosedEventArgs e)
		{
			softPhone.Close();
		}
	}
}