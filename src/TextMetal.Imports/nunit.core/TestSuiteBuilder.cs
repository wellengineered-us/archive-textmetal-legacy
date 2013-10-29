// ****************************************************************
// This is free software licensed under the NUnit license. You
// may obtain a copy of the license as well as information regarding
// copyright ownership at http://nunit.org.
// ****************************************************************

using System.Collections;

using NUnit.Core.Builders;

namespace NUnit.Core
{
	/// <summary>
	/// 	This is the master suite builder for NUnit. It builds a test suite from
	/// 	one or more assemblies using a list of internal and external suite builders 
	/// 	to create fixtures from the qualified types in each assembly. It implements
	/// 	the ISuiteBuilder interface itself, allowing it to be used by other classes
	/// 	for queries and suite construction.
	/// </summary>
	/// D:\Dev\NUnit\nunit20\src\NUnitFramework\core\TestBuilderAttribute.cs
	public class TestSuiteBuilder
	{
		#region Fields/Constants

		private ArrayList builders = new ArrayList();

		#endregion

		#region Properties/Indexers/Events

		public IList Assemblies
		{
			get
			{
				ArrayList assemblies = new ArrayList();
				foreach (TestAssemblyBuilder builder in this.builders)
					assemblies.Add(builder.Assembly);
				return assemblies;
			}
		}

		public IList AssemblyInfo
		{
			get
			{
				ArrayList info = new ArrayList();
				foreach (TestAssemblyBuilder builder in this.builders)
					info.Add(builder.AssemblyInfo);

				return info;
			}
		}

		#endregion

		#region Methods/Operators

		/// <summary>
		/// 	Build a suite based on a TestPackage
		/// </summary>
		/// <param name="package"> The TestPackage </param>
		/// <returns> A TestSuite </returns>
		public TestSuite Build(TestPackage package)
		{
			bool autoNamespaceSuites = package.GetSetting("AutoNamespaceSuites", true);
			bool mergeAssemblies = package.GetSetting("MergeAssemblies", false);
			TestExecutionContext.CurrentContext.TestCaseTimeout = package.GetSetting("DefaultTimeout", 0);

			if (package.IsSingleAssembly)
				return this.BuildSingleAssembly(package);
			string targetAssemblyName = null;
			if (package.TestName != null && package.Assemblies.Contains(package.TestName))
			{
				targetAssemblyName = package.TestName;
				package.TestName = null;
			}

			TestSuite rootSuite = new ProjectRootSuite(package.FullName);
			NamespaceTreeBuilder namespaceTree =
				new NamespaceTreeBuilder(rootSuite);

			this.builders.Clear();
			foreach (string assemblyName in package.Assemblies)
			{
				if (targetAssemblyName == null || targetAssemblyName == assemblyName)
				{
					TestAssemblyBuilder builder = new TestAssemblyBuilder();
					this.builders.Add(builder);

					Test testAssembly = builder.Build(assemblyName, package.TestName, autoNamespaceSuites && !mergeAssemblies);

					if (testAssembly != null)
					{
						if (!mergeAssemblies)
							rootSuite.Add(testAssembly);
						else if (autoNamespaceSuites)
						{
							namespaceTree.Add(testAssembly.Tests);
							rootSuite = namespaceTree.RootSuite;
						}
						else
						{
							foreach (Test test in testAssembly.Tests)
								rootSuite.Add(test);
						}
					}
				}
			}

			ProviderCache.Clear();

			if (rootSuite.Tests.Count == 0)
				return null;

			return rootSuite;
		}

		private TestSuite BuildSingleAssembly(TestPackage package)
		{
			TestAssemblyBuilder builder = new TestAssemblyBuilder();
			this.builders.Clear();
			this.builders.Add(builder);

			TestSuite suite = (TestSuite)builder.Build(
				package.FullName,
				package.TestName, package.GetSetting("AutoNamespaceSuites", true));

			ProviderCache.Clear();

			return suite;
		}

		#endregion
	}
}