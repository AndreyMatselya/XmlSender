using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.ServiceModel;
using XmlSender.Exceptions;
using XmlSender.Extensions;
using XmlSender.ServiceReference3;
using XmlSender.Soap.Enums;

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

		internal WsReturnCode PostData(insurance_data_request idr)
		{
			if (_insuranceClient.State == CommunicationState.Closed)
			{
				CreateNewConection();
			}
			try
			{
				return _insuranceClient.postInsuranceData(idr);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		internal void Authenticate()
		{
			if (_insuranceClient.State == CommunicationState.Closed)
			{
				CreateNewConection();
			}
			WsReturnCode response;
			using (_insuranceClient)
			{
				response = _insuranceClient.postInsuranceData(new insurance_data_request());
			}
			if (response.error_list.Any(x => x.error_code.code == ErrorType.AuthorizationError.GetDescription()))
			{
				throw new System.Security.Authentication.AuthenticationException(
					response.error_list.FirstOrDefault(x => x.error_code.code == ErrorType.AuthorizationError.GetDescription())
						.description);
			}
			User.CurrentUser.IsAuthenticated = true;
		}

		public void Dispose()
		{
			_insuranceClient.Close();
		}
	}
}
