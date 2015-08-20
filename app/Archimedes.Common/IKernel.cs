namespace Archimedes.Common
{
	using ServiceLocater;

	public interface IKernel
	{
		IServiceLocator ServiceLocator { get; }
		void CheckSanity();
		void WriteIfVerbose(string format, params object[] args);
	}
}