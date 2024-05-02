
- You can check the Notes.txt file to get a better picture of what went on.

__
What you need to do, at the very minimum, to get this project to compile in your system:


1) Modify the "Header Search Paths" and "Library Search Paths" in the project "Build Settings" (not in the target "Build Settings"), to fit your system paths.

Example: Change  /opt/homebrew/opt/gmp/include  to  my_system_path_to_gmp/include

Note: You can double-click the value in "Header Search Paths" to get a better editor for the paths.

If you installed all libraries, that this project depends on, using Homebrew, then run the following commands to check their install paths, so that then you can mod "... Search Paths" accordingly:

brew --prefix cgal
brew --prefix boost
brew --prefix gmp
brew --prefix mpfr
brew --prefix eigen


2) To create the dynamic-linked library, select the scheme with sufix "dynamic" not "dynamic debug". Either "Run" it or "Archive" it.

2.1) Optionally, to the same for suffix "static " to create the static-linked library.


--
Optionally,
You may need to configure "Architectures" in "Build Settings". Its default value is $(ARCHS_STANDARD).
We have set it to arm64, for both our libgmp and libmpfr are only compatible with arm64, and we only need compatibility with arm64 for our M1 mac.


You can check the architectures a given library supports (e.g: mpfr).
   run: "file libmpfr.dylib" or "lipo -info libmpfr.dylib"
You can extract one of the architectures.
   run: "lipo -extract arm64 -output libmpfr_arm64.dylib libmpfr.dylib"
Reinstall any libraries that don't support your architeture.
   run: "brew reinstall mpfr"



__
TO USE THIS LIBRARY:
(do the following outside this project)


Modify class CGALGlobal of the project CGALDotNet:
from
private const string DLL_NAME = "CGALWrapper.dll";
to
public const string DLL_NAME = "CgalForCgalDotnet";


note: You should not include the prefix "lib" of the library nor its file extension.
See: https://docs.unity3d.com/Manual/PluginsForDesktop.html


Modify class CGALObject of the project CGALDotNet:
from
protected const string DLL_NAME = "CGALWrapper.dll";
to
protected const string DLL_NAME = CGALGlobal.DLL_NAME;


Modify class CGALObjectKernel of the project CGALDotNet:
from
protected const string DLL_NAME = "CGALWrapper.dll";
to
protected const string DLL_NAME = CGALGlobal.DLL_NAME;


Modify class CGALIntersections of the project CGALDotNet:
from
public const string DLL_NAME = "CGALWrapper.dll";
to
public const string DLL_NAME = CGALGlobal.DLL_NAME;


