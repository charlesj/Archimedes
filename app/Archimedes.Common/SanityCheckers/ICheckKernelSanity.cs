namespace Archimedes.Common.SanityCheckers
{
	/// <summary>
	/// The CheckSanity interface defines how to check sanity of the kernel.
	/// </summary>
	public interface ICheckKernelSanity
	{
		/// <summary>
		/// Runs the check.  Expects an exception to get thrown if someone fails sanity check.
		/// </summary>
		/// <param name="kernel">
		/// The kernel.
		/// </param>
		void Check(IKernel kernel);
	}
}