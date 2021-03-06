﻿namespace Forum.App.Views
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Forum.App.UserInterface.Contracts;

	public class CategoryView : IView
	{
		private const int PrevButton = 1;
		private const int NextButton = 2;
		private const int NameMaxLength = 14;
		private const int WhiteSpaceCount = 27;
		private static int _centerTop = Console.WindowHeight / 2;
		private static int _centerLeft = Console.WindowWidth / 2;
		private string _categoryName;

		public CategoryView(string categoryName, string[] postNames, bool isFirstPage = false, bool isLastPage = false)
		{
			_categoryName = categoryName;
			PostTitles = postNames;

			IsFirstPage = isFirstPage;
			IsLastPage = isLastPage;
			InitializeLabels();
		}

		public ILabel[] Labels
		{
			get;
			private set;
		}

		public ILabel[] Buttons
		{
			get;
			private set;
		}

		public string[] PostTitles
		{
			get;
			private set;
		}

		public bool IsFirstPage
		{
			get;
			private set;
		}

		public bool IsLastPage
		{
			get;
			private set;
		}

		private void InitializeLabels()
		{
			Position consoleCenter = Position.ConsoleCenter();

			InitializeStaticLabels(consoleCenter);

			InitializeButtons(consoleCenter);
		}

		private void InitializeButtons(Position consoleCenter)
		{
			string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };

			Position[] defaultButtonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
				new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
			};

			Position[] categoryButtonPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 8),
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 6),
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 4),
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 2),
				new Position(consoleCenter.Left - 18, consoleCenter.Top),
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 2),
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 4),
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 6),
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 8),
				new Position(consoleCenter.Left - 18, consoleCenter.Top + 10),
			};

			IList<ILabel> buttons = new List<ILabel>();
			buttons.Add(new Label(defaultButtonContent[0], defaultButtonPositions[0]));

			for (int i = 0; i < categoryButtonPositions.Length; i++)
			{
				string currentCategoryName = string.Empty;

				if (i < PostTitles.Length)
				{
					currentCategoryName = PostTitles[i];
				}

				ILabel label = new Label(currentCategoryName, categoryButtonPositions[i], currentCategoryName == string.Empty);

				buttons.Add(label);
			}

			buttons.Add(new Label(defaultButtonContent[1], defaultButtonPositions[1], IsFirstPage));
			buttons.Add(new Label(defaultButtonContent[2], defaultButtonPositions[2], IsLastPage));

			Buttons = buttons.ToArray();
		}

		private void InitializeStaticLabels(Position consoleCenter)
		{
			string[] labelContent = new string[] { string.Format("CATEGORY: {0}", _categoryName), "Title", /*"Replies"*/ };
			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // CATEGORY: {0}
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
				//new Position(consoleCenter.Left + 14, consoleCenter.Top - 10), // Posts
			};

			IList<ILabel> labels = new List<ILabel>();

			for (int i = 0; i < labelContent.Length; i++)
			{
				labels.Add(new Label(labelContent[i], labelPositions[i]));
			}

			Labels = labels.ToArray();
		}
	}
}
