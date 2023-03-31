public struct ModCompilationResult
{
	public bool Success;

	public string Errors;

	public ModCompilationResult(bool success, string errors)
	{
		Success = success;
		Errors = errors;
	}
}
