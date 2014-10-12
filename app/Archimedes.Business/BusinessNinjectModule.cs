namespace Archimedes.Business
{
	using System.Collections.Generic;

	using Archimedes.Business.BusinessObjects;
	using Archimedes.Business.Commands.JournalCommands;
	using Archimedes.Business.Commands.ManuscriptCommands;
	using Archimedes.Business.Contracts;
	using Archimedes.Business.Services;
	using Archimedes.Common.Commands;

	using Ninject.Modules;

	/// <summary>
	/// The business ninject module.
	/// </summary>
	public class BusinessNinjectModule : NinjectModule
	{
		/// <summary>
		/// The load.
		/// </summary>
		public override void Load()
		{
			this.Bind<IBusinessServices>().To<BusinessServices>();
			this.Bind<IUserActivityLog>().To<UserActivityLog>();

			// Register commands!
			this.RegisterCommand<GetUserEntriesRequest, List<JournalEntry>,  GetUserEntriesCommand>();
			this.RegisterCommand<AddJournalEntryRequest, JournalEntry, AddJournalEntryCommand>();
			this.RegisterCommand<SaveJournalEntryChangesRequest, JournalEntry, SaveJournalEntryChangesCommand>();
			this.RegisterCommand<DeleteJournalEntryRequest, bool, DeleteJournalEntryCommand>();

			this.RegisterCommand<GetAllManuscriptsRequest, List<Manuscript>, GetAllManuscriptsCommand>();
			this.RegisterCommand<CreateManuscriptRequest, Manuscript, CreateManuscriptCommand>();
		}

		/// <summary>
		/// The register command.
		/// </summary>
		/// <typeparam name="TRequest">
		/// The Type of the request
		/// </typeparam>
		/// <typeparam name="TResult">
		/// The Type of the Result
		/// </typeparam>
		/// <typeparam name="TCommand">
		/// The Type of the command
		/// </typeparam>
		private void RegisterCommand<TRequest, TResult, TCommand>() where TRequest : Request where TCommand : BaseCommand<TRequest, TResult>
		{
			this.Bind<BaseCommand<TRequest, TResult>>().To<TCommand>();
		}
	}
}
