﻿namespace XXRead.Views.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupChaptersPage : CommunityToolkit.Maui.Views.Popup
	{
		public PopupChaptersPage(ViewModels.PopupViewModels.PopupChaptersPageViewModel viewModel)
		{
			InitializeComponent();

			this.BindingContext = viewModel;
		}
	}
}