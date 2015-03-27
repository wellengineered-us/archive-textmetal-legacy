﻿/*
	Copyright ©2002-2015 Daniel Bullington (dpbullington@gmail.com)
	Distributed under the MIT license: http://www.opensource.org/licenses/mit-license.php
*/

using System.Reflection;
using System.Runtime.InteropServices;

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("textmetal.com")]
[assembly: AssemblyProduct("TextMetal")]
[assembly: AssemblyCopyright("©2002-2015 Daniel Bullington (dpbullington@gmail.com)")]
[assembly: AssemblyDescription("Distributed under the MIT license:\r\nhttp://www.opensource.org/licenses/mit-license.php")]
[assembly: AssemblyTrademark("π")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("7.1.0.*")]
[assembly: AssemblyFileVersion("7.1.0.0")]
[assembly: AssemblyInformationalVersion("2015.03.27/alpha")]
[assembly: AssemblyDelaySign(false)]
[assembly: ComVisible(false)]

/*#if DEFINE_CLR_VERSION_20
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

#if DEFINE_CLR_VERSION_40
[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level2)]
#endif*/