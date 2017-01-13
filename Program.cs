// THIS SOFTWARE IS PROVIDED ``AS IS'' AND WITHOUT ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.

using System;
using System.Collections.Generic;
using System.IO;

namespace UpdateACH
{
	internal class Program
	{
		private static int Main(string[] args)
		{
			try
			{
				Console.WriteLine("Usage: UpdateACH.exe <Source File> <New Company ID> <New Company Name> [<Destination File>]");
				Console.WriteLine("  THIS SOFTWARE IS PROVIDED ``AS IS'' AND WITHOUT ANY EXPRESS OR");
				Console.WriteLine("  IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE IMPLIED");
				Console.WriteLine("  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.");

				var source = args[0];
				var companyid = args[1];
				var companyname = args[2];
				var dest = args.Length == 3 ? source : args[3];

				companyname = (companyname.Length > 16)
					? companyname = companyname.Substring(0, 16)
					: companyname = companyname.PadRight(16, ' ');

				companyid = (companyid.Length > 10)
					? companyid = companyid.Substring(0, 10)
					: companyid = companyid.PadLeft(10, ' ');

				var lines = File.ReadAllLines(source);
				var newlines = new List<string>(lines.Length);

				foreach (var line in lines)
				{
					if (line[0] == '5')
						newlines.Add(line.Substring(0, 4) + companyname + line.Substring(20, 20) + companyid + line.Substring(50, 44));
					else
						newlines.Add(line);
				}

				File.WriteAllLines(dest, newlines);

				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.WriteLine("**** An error occurred! *****");
				return -1;
			}
		}
	}
}
