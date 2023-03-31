using ModModels;
using System;

internal interface IModCompiler : IDisposable
{
	CompilerConfig Config
	{
		get;
		set;
	}

	void Start();

	void Stop();

	CompilerReply RequestCompilationSynchronous(ModCompileInstructions instructions);
}
