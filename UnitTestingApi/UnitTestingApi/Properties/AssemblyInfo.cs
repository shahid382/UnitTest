using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//[assembly: AssemblyConfiguration("")]
//[assembly: AssemblyCompany("")]
//[assembly: AssemblyProduct("UnitTestingApi.Properties")]
//[assembly: AssemblyTrademark("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ec373c38-e1e8-4eee-9938-502db6bfbf51")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
