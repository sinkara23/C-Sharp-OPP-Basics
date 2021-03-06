﻿namespace Forum.App.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.Views;
	using WorkShop.Controllers.Services;

	public class CategoryController : IController, IPaginationController
	{
		public const int PageOffset = 10;
		private const int CommandCount = PageOffset + 3;

		public CategoryController()
		{
			CurrentPage = 0;
			SetCategory(0);
		}

		public int CurrentPage
		{
			get;
			set;
		}

		private string[] PostTitles
		{
			get;
			set;
		}

		private int LastPage => PostTitles.Length / (PageOffset + 1);

		private bool IsFirstPage => CurrentPage == 0;

		private bool IsLastPage => CurrentPage == LastPage;

		public int CategoryId
		{
			get;
			private set;
		}

		private enum Command
		{
			Back = 0,
			ViewPost = 1,
			PreviousPage = 11,
			NextPage = 12
		}


		public MenuState ExecuteCommand(int index)
		{
			if (index > 1 && index < 11)
			{
				index = 1;
			}

			switch ((Command)index)
			{
				case Command.Back:
					return MenuState.Back;
				case Command.ViewPost:
					return MenuState.OpenCategory;
				case Command.PreviousPage:
					ChangePage(false);
					//to-do
					return MenuState.OpenCategory;
				case Command.NextPage:
					ChangePage();
					//to-do return MenuState.Rerender
					return MenuState.OpenCategory;
			}

			throw new InvalidOperationException();
		}

		public IView GetView(string userName)
		{
			GetPosts();
			string categoryName = PostService.GetCategory(CategoryId).Name;
			return new CategoryView(categoryName, PostTitles, IsFirstPage, IsLastPage);
		}

		public void SetCategory(int categoryId)
		{
			CategoryId = categoryId;
		}

		private void ChangePage(bool forward = true)
		{
			CurrentPage += forward ? 1 : -1;
			GetPosts();
		}

		private void GetPosts()
		{
			IEnumerable<Models.Post> allCategoryPosts = PostService.GetPostsByCategory(CategoryId);
			PostTitles = allCategoryPosts
				.Skip(CurrentPage * PageOffset)
				.Take(PageOffset)
				.Select(p => p.Title)
				.ToArray();
		}
	}
}
