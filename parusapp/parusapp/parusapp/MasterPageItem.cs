using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using parusapp.Services;
using parusapp.Views;

namespace parusapp.MasterDetailPageNavigation
{
	public class MasterPageItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}
}
