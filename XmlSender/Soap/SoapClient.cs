using System;
using System.Collections.Generic;
using System.ServiceModel;
using XmlSender.ServiceReference3;

namespace XmlSender.Soap
{
	public class SoapClient : IDisposable
	{
		private InsuranceWSClient _insuranceClient;

		public SoapClient()
		{
			_insuranceClient = new InsuranceWSClient("InsuranceWS");
		}

		private void CreateNewConection()
		{
			_insuranceClient = new InsuranceWSClient("InsuranceWS");
		}

		internal void PostData(IEnumerable<insurance_data_request> idrs)
		{
			if (_insuranceClient.State == CommunicationState.Closed)
			{
				CreateNewConection();
			}
			using (_insuranceClient)
			{
				foreach (var idr in idrs)
				{
					try
					{
						_insuranceClient.postInsuranceData(idr);
					}
					catch (Exception ex)
					{
						throw ex;
					}

				}
			}
		}

		internal void Authenticate()
		{
			if (_insuranceClient.State == CommunicationState.Closed)
			{
				CreateNewConection();
			}
			using (_insuranceClient)
			{
				var response = _insuranceClient.postInsuranceData(new insurance_data_request());
			}
		}

		public void Dispose()
		{
			_insuranceClient.Close();
		}
	}
}
