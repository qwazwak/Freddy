using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace QLib;
internal static class MiscTools
{
    /// <summary>
    /// Determines a text file's encoding by analyzing its byte order mark (BOM).
    /// Defaults to ASCII when detection of the text file's endianness fails.
    /// </summary>
    /// <param name="filename">The text file to analyze.</param>
    /// <returns>The detected encoding.</returns>
    private static bool TryGetEncoding(string filename, [NotNullWhen(true), MaybeNullWhen(false)] out Encoding encoding, bool allowUTF7 = true)
    {
        // Read the BOM
        Span<byte> bom = stackalloc byte[4];
        int bytesRead;
        using (FileStream file = new(filename, FileMode.Open, FileAccess.Read))
        {
            bytesRead = file.Read(bom);
        }
        Debug.Assert(bytesRead == 4);

        encoding = null!;
        // Analyze the BOM
        //if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) encoding = allowUTF7 ? Encoding.UTF7 : null;
        //else
        if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) encoding = Encoding.UTF8;
        else if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0) encoding = Encoding.UTF32; //UTF-32LE
        else if (bom[0] == 0xff && bom[1] == 0xfe) encoding = Encoding.Unicode; //UTF-16LE
        else if (bom[0] == 0xfe && bom[1] == 0xff) encoding = Encoding.BigEndianUnicode; //UTF-16BE
        else if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) encoding = new UTF32Encoding(true, true);  //UTF-32BE

        // We actually have no idea what the encoding is if we reach this point, so
        // you may wish to return null instead of defaulting to ASCII
        return encoding != null;
    }
}