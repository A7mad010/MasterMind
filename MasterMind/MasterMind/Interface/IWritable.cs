
namespace MasterMind.Interface
{
    /// <summary>
    /// Defines a contract for classes that can process or handle string input via the Write method.
    /// </summary>
    internal interface IWritable
    {
        /// <summary>
        /// Processes the given input string.
        /// </summary>
        /// <param name="input">The input string to be processed.</param>
        void Write(string input);
    }
}
