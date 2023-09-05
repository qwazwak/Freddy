using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QLib.Extensions;
/// <summary>
/// A set of extension methods for working with Streams
/// </summary>
public static class StreamExtensions
{

    private static ArgumentException StreamNotReadable(string ArgumentName)
    {
        string Message = $"{ArgumentName} is not readable";
        return new ArgumentException(Message, ArgumentName, new NotSupportedException(Message));
    }

    /// <summary>
    /// Reads all lines, from <paramref name="stream"/> exposed as an <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Asynchronously returns the lines read from the stream</returns>
    public static IAsyncEnumerable<string> ReadAllLinesAsync(this Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));
        if (!stream.CanRead) throw StreamNotReadable(nameof(stream));

        return Enumerate(stream, cancellationToken);

        static async IAsyncEnumerable<string> Enumerate(Stream stream, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using StreamReader reader = new(stream);
            await foreach (string line in ReadAllLinesAsync(reader, cancellationToken))
                yield return line;
        }
        // return new ReadLinesAsyncEnumerable(stream, cancellationToken);
    }

    public static IAsyncEnumerable<string> ReadAllLinesAsync(this Stream stream, out Encoding encoding, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));
        if (!stream.CanRead) throw StreamNotReadable(nameof(stream));

        StreamReader reader = null!;
        try
        {
            reader = new(stream);

            reader.Peek();
            encoding = reader.CurrentEncoding;
            return Enumerate(reader, cancellationToken);
        }
        catch
        {
            reader?.Dispose();
            throw;
        }

        static async IAsyncEnumerable<string> Enumerate(StreamReader reader, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            try
            {
                await foreach (string line in ReadAllLinesAsync(reader, cancellationToken))
                    yield return line;
            }
            finally
            {
                reader.Dispose();
            }
        }
        // return new ReadLinesAsyncEnumerable(stream, cancellationToken);
    }

    /// <summary>
    /// Reads all lines, from <paramref name="reader"/> exposed as an <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Asynchronously returns the lines read from the stream</returns>
    public static async IAsyncEnumerable<string> ReadAllLinesAsync(this StreamReader reader, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(reader, nameof(reader));
        string? lastLine;
        ValueTask<string?> lastTask;

        if (reader.EndOfStream)
            yield break;

        lastTask = reader.ReadLineAsync(cancellationToken);
        while ((lastLine = await lastTask.ConfigureAwait(false)) != null)
        {
            if (reader.EndOfStream || cancellationToken.IsCancellationRequested)
            {
                yield return lastLine;
                yield break;
            }

            lastTask = reader.ReadLineAsync(cancellationToken);
            yield return lastLine;
        }
    }
    public static IAsyncEnumerable<string> ReadAllLinesAsync(this StreamReader reader, out Encoding encoding, CancellationToken cancellationToken = default)
    {
        reader.Peek();
        encoding = reader.CurrentEncoding;
        return ReadAllLinesAsync(reader, cancellationToken);
    }

    public static async Task WriteAllLinesAsync(this IAsyncEnumerable<string> lines, StreamWriter writer)
    {
        ArgumentNullException.ThrowIfNull(lines);
        ArgumentNullException.ThrowIfNull(writer);

        await foreach (string line in lines)
            await writer.WriteLineAsync(line);
    }
}
