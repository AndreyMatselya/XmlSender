using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlSender.Attributes;

namespace XmlSender.Soap.Enums
{
	public enum ErrorType
	{
		[Description("01")] UnknownError = 1,
		[Description("02")] DataValidationError = 2,
		[Description("03")] WrongDateFormat = 3,
		[Description("04")] ValueClassifierNotFound = 4,
		[Description("05")] PersonDataNotFound = 5,
		[Description("06")] MissingRequiredData = 6,
		[Description("07")] DuplicationData = 7,
		[Description("08")] AuthorizationError = 8,
		[Description("10")] ErrorCheckingSignature = 10
	}
}
