namespace Archimedes.Common
{
	using System.Collections.Generic;

	public class BootConfiguration
	{
		public BootConfiguration()
		{
			this.AssemblySearchPatterns = new List<string>();
			this.CheckSanity = true;
			this.Verbose = false;
		}

		public static BootConfiguration DefaultConfiguration
		{
			get
			{
				return new BootConfiguration();
			}
		}

		public List<string> AssemblySearchPatterns { get; set; }

		public bool CheckSanity { get; set; }

		public bool Verbose { get; set; }

		public BootConfiguration SkipSanityCheck()
		{
			this.CheckSanity = false;
			return this;
		}

		public BootConfiguration AddAssemblySearchPattern(string searchPattern)
		{
			this.AssemblySearchPatterns.Add(searchPattern);
			return this;
		}

		public BootConfiguration BeVerbose()
		{
			this.Verbose = true;
			return this;
		}
	}
}