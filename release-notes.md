# Release Notes

## Development

## v1.1.1 - May 27th, 2018
	- Updated vsixmanifest information.
	- Added release-notes.md
	- Updated README.md
	- Added response type information for Swagger UI.

## v1.1.2 - May 31st, 2018
	- Added log for VSIX template.

## v1.2.0 - September 15th, 2018
	- Upgraded following packages:
		- Autofac.WebApi2 4.2.0
		- Microsoft.CodeDom.Providers.DotNetCompilerPlatform - 2.0.1
		- Microsoft.Net.Compilers 2.9.0
		- Swashbuckle 5.6.0
		- Swashbuckle.Core 5.6.0
	- Reinstalled nuget packages so that all target .Net 4.7.1
	- Implemented request/response predefined examples for Swagger using Swashbuckle.Examples
	- Setup XML documentation usage for Swagger.

## v1.3.0 - November 11th, 2018
	- Fixed the instal path for the template so not it's nested under: Web -> Previous Versions
	- Fixed the XML documentation path resolving
