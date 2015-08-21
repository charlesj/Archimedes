﻿namespace Archimedes.Business.Tests.Commands.JournalCommandTests
{
	using System;
	using System.Linq;

	using Business.Commands.JournalCommands;
	using Common.Commands;

	using Xunit;

	public class AddJournalEntryCommandTests : BusinessIntegrationTest<AddJournalEntryCommand>
	{
		[Fact]
		public void CanExecuteCommand()
		{
			var user = this.Data.Users.GetAll().First();
			var request = new AddJournalEntryRequest
				              {
					              UserId = user.Id,
					              Content = "Dear Diary, This is my first entry.  Now I'm done.",
					              EntryDate = DateTime.Now
				              };
			var result = this.SystemUnderTest.Execute(request);

			Assert.Equal(result.ResultType, ResponseTypes.Success);
		}

		[Fact]
		public void AddsJournalEntryToTheCollection()
		{
			var user = this.Data.Users.GetAll().First();
			var currEntries = this.Data.JournalEntries.GetUsersEntries(user.Id).ToList();
			var request = new AddJournalEntryRequest
			{
				UserId = user.Id,
				Content = "Dear Diary, This is my second entry.  Now I'm done.",
				EntryDate = DateTime.Now
			};
			this.SystemUnderTest.Execute(request);
			var newEntries = this.Data.JournalEntries.GetUsersEntries(user.Id);
			Assert.Equal(currEntries.Count + 1, newEntries.Count());
		}

		[Fact]
		public void AddsActivityLog()
		{
			var user = this.Data.Users.GetAll().First();
			var request = new AddJournalEntryRequest
			{
				UserId = user.Id,
				Content = "Dear Diary, This is my first entry.  Now I'm done.",
				EntryDate = DateTime.Now
			};

			var currentAcivityCount = this.Data.UserActivities.GetUserActivity(user.Id).ToList().Count;
			var result = this.SystemUnderTest.Execute(request);

			var newActivityCount = this.Data.UserActivities.GetUserActivity(user.Id).ToList().Count;

			Assert.Equal(currentAcivityCount + 1, newActivityCount);
		}
	}
}
