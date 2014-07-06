using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlSender
{
	public partial class ProgressBarForm : Form
	{
		public ProgressBarForm()
		{
			InitializeComponent();
		}

		public void SetUpperBoundPrBar(int count)
		{
			this.progressBar1.Maximum = count;
			this.progressBar1.Value = 0;
		}

		public void SetValuePrBar(int value)
		{
			this.progressBar1.Value = value;
		}
	}

	public class Progress
	{
		private Thread thrd;

		private ProgressBarForm _progressForm;

		public Progress()
		{
			thrd = new Thread(new ThreadStart(this.ThreadEntryPoint));
			thrd.Priority = ThreadPriority.Highest;
			thrd.Start();
			while (thrd.ThreadState != System.Threading.ThreadState.Running) Thread.Sleep(50);
			// 2) ждем пока создастся форма
			while (_progressForm == null) Thread.Sleep(50);
			// 3) ждем пока проинициализируется instance формы
			while ((!_progressForm.IsHandleCreated)) Thread.Sleep(10);
		}

		private void ThreadEntryPoint()
		{
			// создаем экземпляр формы прогресса
			_progressForm = new ProgressBarForm();
			// запускаем для него цикл обработки сообщений
			Application.Run(_progressForm);
		}

		public void SetMaximumProgress(int count)
		{
			_progressForm.SetUpperBoundPrBar(count);
		}

		public void SetValueProgress(int value)
		{
			_progressForm.SetValuePrBar(value);
		}
	}
}
