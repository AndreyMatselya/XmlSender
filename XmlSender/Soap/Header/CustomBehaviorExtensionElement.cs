﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Soap.Header
{
	public class CustomBehaviorExtensionElement : BehaviorExtensionElement
	{
		protected override object CreateBehavior()
		{
			return new CustomBehavior();
		}

		public override Type BehaviorType
		{
			get
			{
				return typeof(CustomBehavior);
			}
		}
	} 
}
