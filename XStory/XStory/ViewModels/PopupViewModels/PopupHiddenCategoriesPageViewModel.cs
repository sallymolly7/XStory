﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XStory.DTO;
using XStory.Helpers;

namespace XStory.ViewModels.PopupViewModels
{
	public class PopupHiddenCategoriesPageViewModel : BasePopupViewModel
	{
		#region --- Fields ---

		private BL.SQLite.Contracts.IServiceCategory _serviceCategorySQLite;
		private BL.Common.Contracts.IServiceCategory _elServiceCategorySQLite;

		private ObservableCollection<DTO.Category> _categories;
		public ObservableCollection<DTO.Category> Categories
		{
			get { return _categories; }
			set { SetProperty(ref _categories, value); }
		}

		public DelegateCommand<DTO.Category> CategoriesItemTappedCommand { get; set; }
		#endregion

		public PopupHiddenCategoriesPageViewModel(INavigationService navigationService,
			BL.Common.Contracts.IServiceCategory elServiceCategorySQLite,
			BL.SQLite.Contracts.IServiceCategory serviceCategorySQLite) : base(navigationService)
		{
			_serviceCategorySQLite = serviceCategorySQLite;
			_elServiceCategorySQLite = elServiceCategorySQLite;

			ClosePopupCommand = new DelegateCommand(ExecuteClosePopupCommand);
			CategoriesItemTappedCommand = new DelegateCommand<DTO.Category>((category) => ExecuteCategoriesItemTappedCommand(category));
		}

		private async void ExecuteCategoriesItemTappedCommand(Category category)
		{
			bool baseState = category.IsEnabled;

			category.IsEnabled = baseState ? false : true;
			int result = await _elServiceCategorySQLite.Save(category);

			if (result >= 0)
			{
				List<Category> categoriesUpdated = Categories.OrderBy(c => c.Title).ToList();

				Categories.Clear();
				Categories = new ObservableCollection<Category>(categoriesUpdated);

				await _elServiceCategorySQLite.InitHiddenCategories();
				AppSettings.HiddenCategoriesChanged = true;
			}
			else
			{
				// rollback value
				category.IsEnabled = baseState;
			}

		}

		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			try
			{
				List<DTO.Category> categs = parameters.GetValue<List<DTO.Category>>("categories");
				if (categs != null)
				{
					Categories = new ObservableCollection<DTO.Category>(categs);
				}
			}
			catch (Exception ex)
			{
				Logger.ServiceLog.Error(ex);
				Categories = null;
			}
		}
	}
}
